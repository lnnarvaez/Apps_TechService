# Instrucciones del repositorio

## Proyecto y verificación

- Es una aplicación Windows Forms para Windows, escrita en C# sobre .NET 8.
- La solución contiene un único proyecto: `Apps_TechService/Apps_TechService.csproj`.
- `Apps_TechService/Program.cs` inicia `MainContainerForm`.
- Ejecuta desde la raíz: `dotnet build Apps_TechService.slnx` y `dotnet run --project Apps_TechService/Apps_TechService.csproj`.
- No hay tests, linter, formatter ni CI; `dotnet build` es la verificación disponible.
- No edites ni referencies `bin/`, `obj/` o `.vs/`; son artefactos generados.
- Respeta `CRLF`, `end_of_line = crlf` y `eol=crlf` de `.editorconfig` y `.gitattributes`.

## Estructura y arquitectura

- `UI/` contiene los formularios actuales; `View/` conserva el formulario legado `Form1`.
- `Models/Entities/` es la única ubicación autorizada para entidades que representan tablas del dominio; no introduzcas DTOs paralelos para reemplazarlas.
- `Models/Enums/` contiene enums reutilizables; no los declares dentro de formularios.
- `Database/PostgresConnection.cs` abre conexiones manuales; `Data/Repositories/` ejecuta SQL parametrizado y `Services/` concentra validaciones y reglas de negocio.
- `MainContainerForm` carga `NewCustomerForm` dentro de `splitContainer1.Panel2` al pulsar `mnuCustomers`.
- `mnuCustomers` carga `ListcustomersForm`; `ListcustomersForm` abre `NewCustomerForm` desde `BtnNewCustomer`.
- No implementes MVP, presenters ni vistas adicionales: los eventos deben manejarse directamente en los formularios.
- Este es un proyecto demostrativo; evita patrones, abstracciones o dependencias nuevas sin una necesidad concreta.
- El rol permanente es desarrollar con criterio senior y enfoque orientado a objetos, manteniendo una curva de aprendizaje adecuada para un desarrollador junior.

## PostgreSQL

- Se usa `Npgsql` 8.0.6, sin Entity Framework ni otro ORM.
- `PostgresConnection` lee `ConnectionStrings:TechService` desde `Apps_TechService/appsettings.json`, que el proyecto copia a la salida.
- PostgreSQL debe estar iniciado y el esquema aplicado antes de ejecutar la aplicación.
- La persistencia de clientes usa `Customer` de `Models/Entities/`, una transacción para `individuals` y `customers`, SQL parametrizado, `using` y borrado lógico.
- El listado de clientes filtra, cuenta y pagina en PostgreSQL; devuelve solo 10 filas por página mediante `LIMIT`/`OFFSET` y no carga todos los clientes en memoria.
- Los filtros vacíos del listado deben enviarse como `NULL`; no uses texto de máscara de `mskNationalId` como cédula durante la carga inicial.
- Antes de crear CRUD, contrasta tablas, columnas, claves foráneas e índices con `techservice_v2.sql`; los repositorios deben operar sobre entidades autorizadas.
- `individuals` es la supertabla de personas; `customers` y `technicians` son especializaciones. `system_accounts` y `account_roles` son seguridad separada.
- `appsettings.json` usa actualmente la base `techservice`; no asumas que coincide con `techservice_dev` de `techservice_v2.sql`.

## Reglas de código

- El código nuevo debe ser compatible con .NET 8 y usar nombres en inglés.
- Respeta `.editorconfig`: tipos, métodos y propiedades en `PascalCase`; campos privados en `_camelCase`; parámetros y locales en `camelCase`.
- `Nullable` está habilitado: maneja nulos explícitamente y no uses `!` sin comprender el warning.
- Para este proyecto usa código síncrono convencional; no introduzcas `Task`, `async`, `await` ni hilos salvo necesidad explícita.
- No edites `*.Designer.cs` para cambios de comportamiento; los cambios visuales los realiza manualmente el desarrollador.
- Mantén los formularios centrados en interacción; no pongas SQL ni reglas de negocio extensas en ellos.
- No ocultes excepciones con `catch` vacío o silencioso.
- Aplica herencia solo cuando exista una relación real del dominio y la base de datos; las clases derivadas reutilizan atributos heredados y agregan solo su especialización.
- `Technician : Individuo` es válido porque `technicians.individual_id` referencia `individuals.individual_id`; `Technician` agrega solo `TechnicianId` y `Specialty`.
- No repitas propiedades de `Individuo` en sus derivados ni crees jerarquías artificiales; usa polimorfismo solo de forma simple y justificada.
- No reintroduzcas `SystemUser : Individuo`; no es una entidad autorizada ni tiene usos actuales. Las cuentas se representan separadamente mediante `UserAccount`/`system_accounts`.
- No uses `UserAccount` como derivado de `Individuo`.
- Añade comentarios breves en español o `summary` solo cuando aclaren una responsabilidad no evidente.

Consulta `.github/copilot-instructions.md` para las directrices extensas de dominio y diseño; prevalecen la estructura real del código y estas restricciones explícitas.
