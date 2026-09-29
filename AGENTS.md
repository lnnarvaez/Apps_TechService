# AGENTS.md

Aplicación de escritorio **Windows Forms (.NET 8, C#)**. Proyecto pequeño, sin
tests automatizados ni CI configurados todavía.

## Comandos

```powershell
dotnet build Apps_TechService.slnx      # compilar
dotnet run --project Apps_TechService/Apps_TechService.csproj  # ejecutar (requiere Windows)
```

No hay proyecto de pruebas, ni linter/formatter separado, ni pipelines en
`.github/` más allá del archivo de instrucciones. `dotnet build` es la única
verificación disponible: compílalo antes de dar por terminado un cambio.

## Estructura real (¡difiere de lo documentado en copilot-instructions.md!)

```text
Apps_TechService/
├── IU/                  # Formularios WinForms  (NO "UI/" como dice copilot-instructions.md)
└── Models/
    ├── Entities/         # Entidades de dominio, en INGLÉS (Customer, Device, Technician,
    │                     #   CorrectiveMaintenance, PreventiveMaintenance, MaintenanceTask...)
    │                     #   excepto "Individuo" (clase base de Customer/Technician), que quedó en español.
    └── Enums/            # Enums en inglés (ServiceStatus, MaintenanceType, UserRole)
```

- `.github/copilot-instructions.md` (930 líneas) ya fue actualizado para exigir nombres
  **en inglés** (sección 6, regla "Establecer los nombres en inglés") y sus ejemplos de
  entidades (sección 4) coinciden con el código real (`Customer`, `Device`, `Technician`,
  etc.). Solo quedan ejemplos ilustrativos sueltos en español en otras secciones (5, 7,
  24) que son conceptuales, no reglas de ubicación.
- **Discrepancia que persiste:** las secciones 4 y 8 de `copilot-instructions.md` siguen
  diciendo que los formularios van en `UI/`, pero el código real usa `IU/`. Sigue la
  carpeta ya existente en el código (`IU/`) salvo que el usuario pida explícitamente
  renombrarla; no renombres nada por tu cuenta sin confirmarlo.
- No crear entidades de dominio dentro de `IU/`; no crear enums nuevos dentro de un
  formulario si se reutilizan en otras partes.
- `bin/` y `obj/` son artefactos generados por el build: nunca editarlos ni referenciarlos.

## Convenciones de código (de `.github/copilot-instructions.md` y `.editorconfig`)

- PascalCase para clases, métodos, propiedades públicas y constantes; camelCase con
  prefijo `_` para campos privados; camelCase para variables locales/parámetros.
- Un formulario (`*_Click`, etc.) debe delegar a métodos con responsabilidad clara, no
  contener lógica de negocio extensa.
- No usar bloques `try {} catch {}` vacíos ni `catch (Exception)` silencioso.
- No usar el operador `!` de supresión de nulos sin entender la causa del warning.
- No introducir patrones/abstracciones/dependencias adicionales sin justificación clara
  (evitar sobreingeniería); cambios mínimos y acotados al problema pedido.
- `Nullable` está habilitado (`<Nullable>enable</Nullable>` en el .csproj): maneja los
  nulos explícitamente.

## Notas del dominio

TechService gestiona clientes, equipos, mantenimientos (preventivo/correctivo) y su
recepción/entrega. Antes de crear una clase nueva, evalúa si el concepto ya existe
como entidad, enum o responsabilidad de una clase existente (ver sección 3 y 24 de
`.github/copilot-instructions.md` para el detalle completo de reglas de POO,
seguridad y manejo de errores; ese archivo es la fuente extensa, este `AGENTS.md`
es el resumen operativo).
