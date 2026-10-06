using Apps_TechService.Database;
using Apps_TechService.Models.Entities;
using Npgsql;

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
    /// Obtiene todos los clientes activos.
    /// </summary>
    public IReadOnlyList<Customer> GetAll()
    {
        using NpgsqlConnection connection = _connectionFactory.OpenConnection();
        const string sql = """
            SELECT c.customer_id, i.individual_id, i.identification_number,
                   i.first_name, i.last_name, i.phone, i.email, c.address, c.is_active
            FROM customers c
            INNER JOIN individuals i ON i.individual_id = c.individual_id
            WHERE c.is_active = TRUE AND i.is_active = TRUE
            ORDER BY i.last_name, i.first_name;
            """;
        using NpgsqlCommand command = new(sql, connection);
        using NpgsqlDataReader reader = command.ExecuteReader();
        List<Customer> customers = [];
        while (reader.Read())
        {
            customers.Add(MapCustomer(reader));
        }

        return customers;
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
