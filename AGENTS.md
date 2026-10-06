# Instrucciones del repositorio

## Proyecto y comandos

- Es una aplicación Windows Forms para Windows, escrita en C# sobre .NET 8.
- La solución contiene un único proyecto: `Apps_TechService/Apps_TechService.csproj`.
- El punto de entrada es `Apps_TechService/Program.cs`; inicia `MainContainerForm`.
- Ejecuta desde la raíz: `dotnet build Apps_TechService.slnx` y `dotnet run --project Apps_TechService/Apps_TechService.csproj`.
- No hay tests, linter, formatter ni CI configurados; `dotnet build` es la verificación disponible.
- No edites ni referencies `bin/`, `obj/` o `.vs/`; son artefactos generados.
- Respeta los finales de línea `CRLF` definidos por `.editorconfig` y `.gitattributes`; conserva esta configuración al crear o modificar archivos de texto.

## Estructura y flujo

- `UI/` contiene los formularios actuales; `View/` conserva el formulario legado `Form1`.
- `Models/Entities/` contiene entidades existentes y `Models/Enums/` contiene enums reutilizables.
- `Models/Entities/` es la única ubicación autorizada para entidades que representan tablas del dominio; no introduzcas DTOs paralelos para reemplazarlas.
- `Database/PostgresConnection.cs` abre conexiones manuales con Npgsql; `Data/Repositories/` ejecuta SQL parametrizado y `Services/` concentra validaciones y reglas de negocio.
- `MainContainerForm` carga `NewCustomerForm` dentro de `splitContainer1.Panel2` al pulsar `mnuCustomers`.
- No implementes MVP ni crees presenters o vistas adicionales: los eventos deben manejarse directamente en los formularios.
- No introduzcas patrones o abstracciones adicionales sin una necesidad concreta; este es un proyecto sencillo.
- El enfoque permanente es desarrollo senior orientado a objetos, manteniendo una curva de aprendizaje adecuada para un desarrollador junior.

## PostgreSQL

- El proyecto usa `Npgsql` 8.0.6; no usa Entity Framework ni otro ORM.
- `PostgresConnection` lee `ConnectionStrings:TechService` desde `appsettings.json`, copiado a la salida; actualmente apunta a `localhost:5432`, base `techservice`, usuario `postgres` y la contraseña configurada allí.
- PostgreSQL debe estar iniciado antes de ejecutar la aplicación y el esquema debe haberse aplicado previamente con `Database/Scripts/001_initial_schema.sql`.
- La persistencia de clientes usa una transacción para insertar o actualizar `individuals` y `customers`; conserva consultas parametrizadas, `using` y borrado lógico.
- Si se cambia el nombre de la base en el código, actualiza también la documentación SQL relacionada; no asumas que `techservice_dev` coincide con la configuración ejecutable actual.
- `techservice_v2.sql` define la referencia del dominio: `individuals` es la supertabla de personas; `customers` y `technicians` son especializaciones; `system_accounts` y `account_roles` son seguridad separada.

## Convenciones

- El código nuevo debe ser compatible con .NET 8 y usar nombres en inglés.
- El rol permanente para este repositorio es desarrollar con criterio senior y enfoque orientado a objetos, manteniendo la solución comprensible para un desarrollador junior.
- Respeta `.editorconfig`: tipos, métodos y propiedades en `PascalCase`; campos privados en `_camelCase`; parámetros y variables locales en `camelCase`.
- `Nullable` está habilitado: maneja los nulos explícitamente y no uses `!` sin entender el warning que silencia.
- No edites archivos `*.Designer.cs` para cambios de comportamiento; los cambios visuales los realiza manualmente el desarrollador.
- Mantén los formularios centrados en interacción y evita SQL o reglas de negocio extensas dentro de ellos.
- No ocultes excepciones con `catch` vacío o silencioso.
- Para este proyecto demostrativo usa código síncrono convencional; no introduzcas `Task`, `async`, `await` ni manejo de hilos salvo una necesidad explícita.
- No guardes otra cadena de conexión en código: modifica `appsettings.json` y conserva la clave `ConnectionStrings:TechService`.
- Aplica herencia solo cuando exista una relación real del dominio y de la base de datos; las clases derivadas deben reutilizar los atributos heredados y agregar únicamente su especialización.
- Usa polimorfismo de forma simple y justificada; no repitas propiedades de la clase base en `Technician` ni crees jerarquías artificiales.
- `SystemUser` no es una entidad autorizada ni tiene usos actuales; no lo reintroduzcas como derivado de `Individuo`. Las cuentas se representan separadamente mediante `UserAccount`/`system_accounts`.
- `Technician : Individuo` es válido porque `technicians.individual_id` referencia a `individuals.individual_id`; `Technician` solo agrega `TechnicianId` y `Specialty`.
- No uses `UserAccount` como derivado de `Individuo`: `system_accounts` es seguridad separada y se vincula mediante `account_roles`.
- Antes de crear CRUD, contrasta nombres, claves foráneas y relaciones con `techservice_v2.sql`; los repositorios deben operar sobre entidades de `Models/Entities/` y conservar SQL parametrizado, transacciones y borrado lógico.

Consulta `.github/copilot-instructions.md` para las directrices extensas de dominio y diseño, pero prevalecen la estructura real del código y estas restricciones explícitas.
