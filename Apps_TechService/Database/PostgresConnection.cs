using Microsoft.Extensions.Configuration;
using Npgsql;

namespace Apps_TechService.Database;

/// <summary>
/// Abre conexiones manuales a PostgreSQL usando appsettings.json.
/// </summary>
public sealed class PostgresConnection
{
    private readonly string _connectionString;

    public PostgresConnection()
    {
        IConfiguration configuration = new ConfigurationBuilder()
            .SetBasePath(AppContext.BaseDirectory)
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: false)
            .Build();

        _connectionString = configuration.GetConnectionString("TechService")
            ?? throw new InvalidOperationException(
                "No se encontró ConnectionStrings:TechService en appsettings.json.");
    }

    /// <summary>
    /// Crea y abre una conexión sincrónica.
    /// </summary>
    public NpgsqlConnection OpenConnection()
    {
        NpgsqlConnection connection = new(_connectionString);

        try
        {
            connection.Open();
            return connection;
        }
        catch
        {
            connection.Dispose();
            throw;
        }
    }
}
