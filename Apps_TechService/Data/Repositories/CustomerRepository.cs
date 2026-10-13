using Apps_TechService.Database;
using Apps_TechService.Models.Entities;
using Npgsql;
using NpgsqlTypes;

namespace Apps_TechService.Data.Repositories;

public sealed class CustomerRepository
{
    private readonly PostgresConnection _connectionFactory;

    public CustomerRepository(PostgresConnection connectionFactory)
    {
        _connectionFactory = connectionFactory;
    }

    /// <summary>
    /// Inserta la persona y el cliente en una sola transacción.
    /// </summary>
    public Customer Create(Customer customer)
    {
        using NpgsqlConnection connection = _connectionFactory.OpenConnection();
        using NpgsqlTransaction transaction = connection.BeginTransaction();

        const string individualSql = """
            INSERT INTO individuals
                (identification_number, first_name, last_name, email, phone)
            VALUES
                (@identification_number, @first_name, @last_name, @email, @phone)
            RETURNING individual_id;
            """;
        using NpgsqlCommand individualCommand = new(individualSql, connection, transaction);
        AddIndividualParameters(individualCommand, customer);
        long individualId = Convert.ToInt64(individualCommand.ExecuteScalar());

        const string customerSql = """
            INSERT INTO customers (individual_id, address)
            VALUES (@individual_id, @address)
            RETURNING customer_id;
            """;
        using NpgsqlCommand customerCommand = new(customerSql, connection, transaction);
        customerCommand.Parameters.AddWithValue("individual_id", individualId);
        customerCommand.Parameters.AddWithValue("address", (object?)customer.Address ?? DBNull.Value);
        long customerId = Convert.ToInt64(customerCommand.ExecuteScalar());

        transaction.Commit();
        customer.IndividualId = individualId;
        customer.CustomerId = customerId;
        return customer;
    }

    /// <summary>
    /// Busca un cliente por su identificador.
    /// </summary>
    public Customer? GetById(long customerId)
    {
        using NpgsqlConnection connection = _connectionFactory.OpenConnection();
        const string sql = """
            SELECT c.customer_id, i.individual_id, i.identification_number,
                   i.first_name, i.last_name, i.phone, i.email, c.address, c.is_active
            FROM customers c
            INNER JOIN individuals i ON i.individual_id = c.individual_id
            WHERE c.customer_id = @customer_id;
            """;
        using NpgsqlCommand command = new(sql, connection);
        command.Parameters.AddWithValue("customer_id", customerId);
        using NpgsqlDataReader reader = command.ExecuteReader();
        return reader.Read() ? MapCustomer(reader) : null;
    }

    /// <summary>
    /// Obtiene una página de clientes y el total que coincide con los filtros.
    /// </summary>
    public IReadOnlyList<Customer> Search(
        bool disabledOnly,
        string? nationalId,
        string? name,
        int pageNumber,
        int pageSize,
        out int totalCount)
    {
        using NpgsqlConnection connection = _connectionFactory.OpenConnection();
        const string countSql = """
            SELECT COUNT(*)
            FROM customers c
            INNER JOIN individuals i ON i.individual_id = c.individual_id
            WHERE c.is_active = @is_active
              AND (@national_id IS NULL OR i.identification_number = @national_id)
              AND (@name IS NULL OR i.first_name ILIKE @name_pattern
                   OR i.last_name ILIKE @name_pattern
                   OR CONCAT(i.first_name, ' ', i.last_name) ILIKE @name_pattern);
            """;
        using NpgsqlCommand countCommand = new(countSql, connection);
        AddSearchParameters(countCommand, disabledOnly, nationalId, name);
        totalCount = Convert.ToInt32(countCommand.ExecuteScalar());

        const string sql = """
            SELECT c.customer_id, i.individual_id, i.identification_number,
                   i.first_name, i.last_name, i.phone, i.email, c.address, c.is_active
            FROM customers c
            INNER JOIN individuals i ON i.individual_id = c.individual_id
            WHERE c.is_active = @is_active
              AND (@national_id IS NULL OR i.identification_number = @national_id)
              AND (@name IS NULL OR i.first_name ILIKE @name_pattern
                   OR i.last_name ILIKE @name_pattern
                   OR CONCAT(i.first_name, ' ', i.last_name) ILIKE @name_pattern)
            ORDER BY i.last_name, i.first_name
            LIMIT @page_size OFFSET @offset;
            """;
        using NpgsqlCommand command = new(sql, connection);
        AddSearchParameters(command, disabledOnly, nationalId, name);
        command.Parameters.AddWithValue("page_size", pageSize);
        command.Parameters.AddWithValue("offset", (pageNumber - 1) * pageSize);
        using NpgsqlDataReader reader = command.ExecuteReader();
        List<Customer> customers = [];
        while (reader.Read())
        {
            customers.Add(MapCustomer(reader));
        }

        return customers;
    }

    private static void AddSearchParameters(
        NpgsqlCommand command,
        bool disabledOnly,
        string? nationalId,
        string? name)
    {
        command.Parameters.AddWithValue("is_active", !disabledOnly);
        NpgsqlParameter nationalIdParameter = command.Parameters.Add("national_id", NpgsqlDbType.Varchar);
        nationalIdParameter.Value = string.IsNullOrWhiteSpace(nationalId)
            ? DBNull.Value
            : nationalId.Trim();
        NpgsqlParameter nameParameter = command.Parameters.Add("name", NpgsqlDbType.Varchar);
        nameParameter.Value = string.IsNullOrWhiteSpace(name) ? DBNull.Value : name.Trim();
        NpgsqlParameter namePatternParameter = command.Parameters.Add("name_pattern", NpgsqlDbType.Varchar);
        namePatternParameter.Value = string.IsNullOrWhiteSpace(name)
            ? DBNull.Value
            : $"%{name.Trim()}%";
    }

    /// <summary>
    /// Actualiza los datos de la persona y del cliente.
    /// </summary>
    public bool Update(Customer customer)
    {
        using NpgsqlConnection connection = _connectionFactory.OpenConnection();
        using NpgsqlTransaction transaction = connection.BeginTransaction();
        const string individualSql = """
            UPDATE individuals i
            SET identification_number = @identification_number,
                first_name = @first_name, last_name = @last_name,
                email = @email, phone = @phone, updated_at = CURRENT_TIMESTAMP
            FROM customers c
            WHERE c.customer_id = @customer_id AND i.individual_id = c.individual_id;
            """;
        using NpgsqlCommand individualCommand = new(individualSql, connection, transaction);
        AddIndividualParameters(individualCommand, customer);
        individualCommand.Parameters.AddWithValue("customer_id", customer.CustomerId);
        if (individualCommand.ExecuteNonQuery() == 0)
        {
            transaction.Rollback();
            return false;
        }

        const string customerSql = """
            UPDATE customers SET address = @address, updated_at = CURRENT_TIMESTAMP
            WHERE customer_id = @customer_id;
            """;
        using NpgsqlCommand customerCommand = new(customerSql, connection, transaction);
        customerCommand.Parameters.AddWithValue("address", (object?)customer.Address ?? DBNull.Value);
        customerCommand.Parameters.AddWithValue("customer_id", customer.CustomerId);
        customerCommand.ExecuteNonQuery();
        transaction.Commit();
        return true;
    }

    /// <summary>
    /// Desactiva lógicamente el cliente y su persona relacionada.
    /// </summary>
    public bool Deactivate(long customerId)
    {
        using NpgsqlConnection connection = _connectionFactory.OpenConnection();
        using NpgsqlTransaction transaction = connection.BeginTransaction();
        const string customerSql = """
            UPDATE customers SET is_active = FALSE, updated_at = CURRENT_TIMESTAMP
            WHERE customer_id = @customer_id;
            """;
        using NpgsqlCommand customerCommand = new(customerSql, connection, transaction);
        customerCommand.Parameters.AddWithValue("customer_id", customerId);
        if (customerCommand.ExecuteNonQuery() == 0)
        {
            transaction.Rollback();
            return false;
        }

        const string individualSql = """
            UPDATE individuals SET is_active = FALSE, updated_at = CURRENT_TIMESTAMP
            WHERE individual_id = (SELECT individual_id FROM customers WHERE customer_id = @customer_id);
            """;
        using NpgsqlCommand individualCommand = new(individualSql, connection, transaction);
        individualCommand.Parameters.AddWithValue("customer_id", customerId);
        individualCommand.ExecuteNonQuery();
        transaction.Commit();
        return true;
    }

    private static void AddIndividualParameters(NpgsqlCommand command, Individuo individual)
    {
        command.Parameters.AddWithValue("identification_number", individual.NationalID);
        command.Parameters.AddWithValue("first_name", individual.FirstName);
        command.Parameters.AddWithValue("last_name", individual.LastName);
        command.Parameters.AddWithValue("email", individual.Email);
        command.Parameters.AddWithValue("phone", (object?)individual.Phone ?? DBNull.Value);
    }

    private static Customer MapCustomer(NpgsqlDataReader reader)
    {
        Customer customer = new(
            reader.GetString(2),
            reader.GetString(3),
            reader.GetString(4),
            reader.GetString(6),
            reader.IsDBNull(5) ? null : reader.GetString(5),
            reader.IsDBNull(7) ? null : reader.GetString(7));
        customer.CustomerId = reader.GetInt64(0);
        customer.IndividualId = reader.GetInt64(1);
        customer.IsActive = reader.GetBoolean(8);
        return customer;
    }
}
