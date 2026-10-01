# PostgreSQL

La aplicación utiliza conexiones manuales mediante `Npgsql`; no utiliza Entity Framework ni otro ORM.

## Paquete NuGet

El proyecto referencia `Npgsql` versión `8.0.6`. No es necesario instalar Entity Framework. La versión del servidor PostgreSQL debe ser 16.0 o superior; el esquema proporcionado también es compatible con PostgreSQL 18.0.

## Configuración local

`PostgresConnection` lee la cadena `ConnectionStrings:TechService` desde `appsettings.json`. La configuración actual apunta a `localhost:5432`, base `techservice`, usuario `postgres` y contraseña `PostSQL2026`.

El archivo se copia automáticamente a la carpeta de salida. El servidor PostgreSQL debe estar iniciado antes de ejecutar la aplicación:

```powershell
dotnet run --project Apps_TechService/Apps_TechService.csproj
```

## Uso desde la aplicación

```csharp
using Apps_TechService.Database;

PostgresConnection connectionFactory = new();

using NpgsqlConnection connection = connectionFactory.OpenConnection();
```

Para operaciones SQL, usa siempre parámetros de `NpgsqlCommand`; no concatentes valores recibidos de la interfaz de usuario. Libera las conexiones con `using` y mantén las transacciones explícitas cuando una operación modifique varias tablas.

## Esquema

El script de creación de la base de datos debe ejecutarse con `psql` o una herramienta PostgreSQL conectada a `techservice`, antes de que la aplicación intente consultar tablas. No se ejecuta automáticamente al iniciar la aplicación.

El script fuente del esquema entregado para este proyecto debe conservarse como `Database/Scripts/001_initial_schema.sql`. Las futuras modificaciones deben añadirse como scripts numerados y ejecutarse en orden; no se introducirá un sistema de migraciones ORM.
