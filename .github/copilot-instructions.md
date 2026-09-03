# GitHub Copilot Repository Instructions — TechService

> **Ubicación obligatoria en el repositorio:** `.github/copilot-instructions.md`  
> **Proyecto:** TechService  
> **Tipo de aplicación:** Desktop  
> **Tecnología principal:** C# + .NET 8 + Windows Forms  
> **Paradigma principal:** Programación Orientada a Objetos (POO)

---

## 1. Propósito de estas instrucciones

Actúa como un asistente de desarrollo senior para el proyecto **TechService**.

TechService es una aplicación de escritorio para una empresa dedicada al soporte técnico y mantenimiento de equipos tecnológicos. La aplicación debe facilitar la gestión básica de clientes, equipos, servicios, mantenimientos, recepción y entrega de equipos.

Estas instrucciones son de alcance para todo el repositorio y deben utilizarse como contexto base al generar, revisar, modificar o explicar código.

Prioriza siempre:

1. Corrección funcional.
2. Diseño orientado a objetos.
3. Seguridad.
4. Mantenibilidad.
5. Legibilidad.
6. Simplicidad.
7. Consistencia con la arquitectura existente.
8. Compatibilidad con C# y .NET 8.
9. Buenas prácticas de Windows Forms.
10. Cambios mínimos y controlados.

No generes código innecesariamente complejo.

---

# 2. Contexto tecnológico obligatorio

La solución se desarrolla con:

- Lenguaje: **C#**
- Framework: **.NET 8**
- Tipo de aplicación: **Windows Forms**
- Entorno principal: **Visual Studio Community**
- Paradigma: **Programación Orientada a Objetos**
- Control de versiones: **Git**
- Repositorio remoto: **GitHub**

Todo código nuevo debe ser compatible con .NET 8 y con la estructura actual del proyecto.

No introducir tecnologías, frameworks, patrones o dependencias adicionales sin una justificación técnica clara.

---

# 3. Contexto funcional del dominio

La empresa **TechService** presta servicios de:

- Soporte técnico.
- Diagnóstico de equipos.
- Mantenimiento preventivo.
- Mantenimiento correctivo.
- Optimización de equipos.
- Limpieza de componentes.
- Reparación de equipos tecnológicos.
- Recepción de equipos.
- Entrega de equipos.

El sistema puede manejar, según las necesidades del proyecto:

- Usuarios.
- Clientes.
- Equipos tecnológicos.
- Servicios.
- Mantenimientos.
- Recepciones de equipos.
- Entregas de equipos.
- Actividades o historial de operaciones.
- Estados del dominio mediante enumeraciones.

Antes de crear una nueva clase, identifica si el concepto representa:

- Una entidad del negocio.
- Un objeto de valor.
- Un estado.
- Una opción limitada que debe ser un `enum`.
- Una responsabilidad que pertenece a una clase existente.
- Una responsabilidad de la interfaz de usuario.

No crear clases únicamente porque existe un formulario.

---

# 4. Estructura conocida del proyecto

Utiliza las siguientes rutas como referencia primaria:

```text
/
├── Models/
│   ├── Entities/        # Clases entidad del dominio
│   └── Enums/           # Enumeraciones del dominio
│
├── UI/                  # Formularios y componentes de interfaz Windows Forms
│
└── .github/
    └── copilot-instructions.md
```

## Reglas de ubicación

### Entidades

Las clases que representan entidades del dominio deben ubicarse en:

```text
Models/Entities
```

Ejemplos posibles:

```text
Models/Entities/Cliente.cs
Models/Entities/Equipo.cs
Models/Entities/Servicio.cs
Models/Entities/Mantenimiento.cs
Models/Entities/Usuario.cs
Models/Entities/RecepcionEquipo.cs
Models/Entities/EntregaEquipo.cs
```

No crear entidades del dominio dentro de `UI`.

---

### Enumeraciones

Todos los `enum` del dominio deben ubicarse en:

```text
Models/Enums
```

Ejemplos posibles:

```text
Models/Enums/EstadoServicio.cs
Models/Enums/TipoMantenimiento.cs
Models/Enums/EstadoEquipo.cs
```

No declarar enumeraciones de dominio dentro de formularios si deben reutilizarse en otras partes de la aplicación.

---

### Interfaz de usuario

Los formularios y artefactos de interfaz se encuentran en:

```text
UI/
```

Los formularios deben centrarse principalmente en:

- Mostrar información.
- Capturar información.
- Validar datos de entrada a nivel de interfaz.
- Invocar operaciones del dominio o de las capas correspondientes.
- Mostrar mensajes y resultados al usuario.

Evitar que un formulario concentre toda la lógica del negocio.

---

# 5. Arquitectura y diseño orientado a objetos

Al generar o modificar código, respeta los principios fundamentales de la POO.

## Encapsulación

No exponer campos internos innecesariamente.

Preferir propiedades y comportamientos explícitos.

Ejemplo preferido:

```csharp
public class Cliente
{
    public int IdCliente { get; set; }
    public string Nombre { get; set; } = string.Empty;
}
```

Evitar:

```csharp
public int idCliente;
public string nombre;
```

---

## Responsabilidad única

Una clase debe tener una responsabilidad principal claramente identificable.

Evitar clases que:

- Validan.
- Persisten.
- Calculan.
- Actualizan la UI.
- Registran archivos.
- Y además representan una entidad.

Si una clase comienza a concentrar responsabilidades no relacionadas, proponer una separación razonable.

---

## Composición antes que herencia

No utilizar herencia únicamente para reutilizar código.

Utilizar herencia cuando exista una relación real del tipo:

> "es un"

Utilizar composición cuando la relación sea:

> "tiene un"  
> "utiliza un"

---

## Abstracciones

No introducir interfaces, clases abstractas, patrones de diseño o capas adicionales si no resuelven un problema real del proyecto.

Evitar sobreingeniería.

Antes de introducir un patrón, evaluar:

1. Qué problema resuelve.
2. Si el proyecto realmente lo necesita.
3. Si mejora la mantenibilidad.
4. Si agrega complejidad innecesaria.

---

# 6. Convenciones obligatorias para identificadores C#

Aplicar las convenciones modernas de nomenclatura de C# y .NET.

## Clases

Usar `PascalCase`.

Correcto:

```csharp
public class Cliente
public class ServicioTecnico
public class MantenimientoPreventivo
```

Incorrecto:

```csharp
public class cliente
public class servicio_tecnico
public class SERVICIOTECNICO
```

---

## Interfaces

Deben comenzar con `I` y utilizar `PascalCase`.

Ejemplo:

```csharp
public interface IClienteRepository
```

No crear interfaces innecesarias.

---

## Métodos

Utilizar `PascalCase` y nombres que expresen una acción.

Correcto:

```csharp
RegistrarCliente();
BuscarServicio();
CalcularCosto();
ActualizarEstado();
```

Evitar nombres ambiguos:

```csharp
Hacer();
Proceso();
Ejecutar1();
Metodo();
```

---

## Propiedades públicas

Utilizar `PascalCase`.

```csharp
public string Nombre { get; set; }
public DateTime FechaRegistro { get; set; }
public decimal Costo { get; set; }
```

---

## Variables locales y parámetros

Utilizar `camelCase`.

```csharp
var clienteEncontrado = BuscarCliente(idCliente);
```

```csharp
public Cliente BuscarCliente(int idCliente)
```

---

## Campos privados

Utilizar `camelCase` con prefijo `_`.

```csharp
private string _nombre;
private readonly List<Cliente> _clientes;
```

---

## Constantes

Utilizar `PascalCase`.

```csharp
private const int MaximoCaracteresNombre = 100;
```

---

## Enumeraciones

Utilizar `PascalCase`.

Para enumeraciones normales, utilizar nombres singulares cuando represente un único valor.

```csharp
public enum EstadoServicio
{
    Pendiente,
    EnProceso,
    Finalizado,
    Cancelado
}
```

No almacenar estados como cadenas libres si el conjunto de valores es limitado y estable.

---

## Nombres

Los identificadores deben:

- Ser descriptivos.
- Expresar intención.
- Evitar abreviaturas ambiguas.
- Evitar nombres de una sola letra, excepto contadores simples.
- Evitar nombres genéricos como `Data`, `Info`, `Manager`, `Helper` o `Utils` cuando no describen una responsabilidad concreta.
- Evitar palabras reservadas.
- No utilizar prefijos húngaros.

Priorizar claridad sobre brevedad.

---

# 7. Reglas para entidades del dominio

Las entidades deben representar conceptos reales del negocio.

Una entidad normalmente:

- Tiene identidad.
- Posee estado.
- Puede tener comportamiento.
- Mantiene información relacionada con el dominio.

No convertir las entidades en simples contenedores de datos cuando el dominio requiera comportamiento.

Ejemplo conceptual:

```csharp
public class Servicio
{
    public int IdServicio { get; private set; }
    public EstadoServicio Estado { get; private set; }

    public void Iniciar()
    {
        if (Estado != EstadoServicio.Pendiente)
        {
            throw new InvalidOperationException(
                "Solo los servicios pendientes pueden iniciarse.");
        }

        Estado = EstadoServicio.EnProceso;
    }
}
```

Aplicar este enfoque solo cuando la regla pertenezca realmente al dominio.

No agregar lógica de negocio artificial para cumplir un patrón.

---

# 8. Reglas para Windows Forms

Los formularios ubicados en `UI/` deben:

- Ser responsables de la interacción con el usuario.
- Evitar contener reglas de negocio extensas.
- Evitar acceso directo innecesario a estructuras internas.
- Validar entradas antes de procesarlas.
- Mostrar mensajes claros.
- Manejar errores esperados adecuadamente.
- Mantener los eventos pequeños y legibles.

Evitar métodos de eventos extensos como:

```csharp
private void btnGuardar_Click(object sender, EventArgs e)
{
    // cientos de líneas de código
}
```

Preferir delegar operaciones a métodos con responsabilidades claras.

Ejemplo:

```csharp
private void btnGuardar_Click(object sender, EventArgs e)
{
    if (!ValidarDatos())
    {
        return;
    }

    RegistrarCliente();
}
```

No modificar manualmente archivos generados por el diseñador de Windows Forms, salvo que exista una razón técnica clara y controlada.

No mezclar innecesariamente código generado por el diseñador con lógica de negocio.

---

# 9. Validación y manejo de errores

## Validación

Validar los datos antes de procesarlos.

Considerar:

- Valores nulos.
- Cadenas vacías.
- Espacios en blanco.
- Longitudes inválidas.
- Rangos numéricos.
- Fechas inválidas.
- Estados inválidos.
- Objetos requeridos inexistentes.

Usar métodos apropiados como:

```csharp
string.IsNullOrWhiteSpace(valor)
```

Evitar validaciones frágiles.

---

## Excepciones

No utilizar excepciones como mecanismo normal de control de flujo.

No usar bloques vacíos:

```csharp
try
{
}
catch
{
}
```

No ocultar errores silenciosamente.

Evitar:

```csharp
catch (Exception)
{
}
```

a menos que exista una justificación técnica y se realice un manejo seguro y apropiado.

Capturar excepciones específicas cuando sea posible.

No mostrar al usuario:

- Trazas internas.
- Detalles técnicos sensibles.
- Cadenas de conexión.
- Rutas internas innecesarias.
- Información de seguridad.

Los mensajes para el usuario deben ser claros y seguros.

---

# 10. Seguridad obligatoria

Toda sugerencia de código debe priorizar la seguridad.

## Nunca sugerir

- Contraseñas almacenadas en texto plano.
- Secretos dentro del código fuente.
- Tokens o claves API hardcodeadas.
- Cadenas de conexión con credenciales en repositorios.
- Desactivación de validaciones de seguridad.
- Ignorar excepciones críticas.
- Concatenación insegura para consultas.
- Uso de datos de usuario como código o comandos sin validación.

---

## Datos sensibles

Nunca incluir datos sensibles reales en:

- Código fuente.
- Ejemplos de producción.
- Commits.
- Archivos de configuración versionados públicamente.

Usar mecanismos adecuados de configuración y secretos según el entorno.

Si una implementación requiere almacenamiento de credenciales, no almacenar contraseñas en texto plano.

Utilizar mecanismos criptográficos y APIs de seguridad apropiadas de .NET para el escenario correspondiente.

---

## Persistencia

Cuando exista acceso a una base de datos:

- No concatenar directamente datos del usuario en consultas.
- Utilizar consultas parametrizadas o mecanismos seguros equivalentes.
- Validar datos antes de persistirlos.
- No exponer mensajes internos de la base de datos directamente al usuario.
- Manejar correctamente errores de acceso a datos.

---

# 11. Calidad del código

El código generado debe:

- Compilar en .NET 8.
- Ser legible.
- Ser consistente con el código existente.
- Evitar duplicación innecesaria.
- Mantener métodos razonablemente pequeños.
- Tener responsabilidades claras.
- Evitar efectos secundarios inesperados.
- Evitar estado global innecesario.
- Preferir inmutabilidad cuando sea apropiada.
- Usar tipos adecuados.
- Evitar conversiones implícitas confusas.
- Inicializar referencias de forma segura.

No generar código solo para aumentar la cantidad de código.

---

# 12. Nullability

Mantener la seguridad frente a valores nulos.

No utilizar el operador de supresión `!` para ocultar advertencias sin comprender la causa.

No usar `null` como sustituto ambiguo de múltiples estados.

Cuando una propiedad pueda no tener valor, modelar claramente esa posibilidad.

---

# 13. Uso de colecciones

Seleccionar la colección según la necesidad.

Ejemplos:

- `List<T>` para colecciones ordenadas y modificables.
- `Dictionary<TKey, TValue>` para búsqueda por clave.
- Interfaces de solo lectura cuando corresponda.

No exponer colecciones internas modificables si la clase debe controlar sus invariantes.

---

# 14. Código asincrónico

Si se requiere código asíncrono:

- Utilizar `async` y `await` correctamente.
- Evitar bloquear la interfaz de usuario.
- No utilizar `.Result` o `.Wait()` en escenarios que puedan bloquear el hilo de UI.
- Propagar correctamente la cancelación y los errores cuando el caso lo requiera.

No convertir métodos en asíncronos sin necesidad real.

---

# 15. Comentarios y documentación

Los comentarios deben explicar:

- El motivo de una decisión.
- Una regla no evidente.
- Una restricción del negocio.
- Una razón técnica importante.

No agregar comentarios que simplemente repitan el código.

Evitar:

```csharp
// Incrementa el contador
contador++;
```

Preferir nombres expresivos y comentarios útiles.

---

# 16. Generación de código por el asistente

Antes de generar código:

1. Revisar la estructura existente del proyecto.
2. Identificar la ubicación correcta del nuevo archivo.
3. Reutilizar convenciones existentes.
4. Evitar crear duplicados.
5. Identificar dependencias.
6. Verificar si existe una clase o `enum` equivalente.
7. Aplicar cambios mínimos necesarios.

Cuando se solicite una implementación:

- Explicar brevemente qué archivos se crearán o modificarán.
- Respetar las rutas definidas.
- No inventar arquitectura existente.
- No asumir nombres de clases que no existan sin indicarlo.
- No modificar archivos no relacionados.
- No eliminar código existente sin una justificación clara.

---

# 17. Protocolo ante ambigüedad o información faltante

Cuando falte información técnica:

1. Revisar primero el código y los artefactos disponibles en el repositorio.
2. Revisar estas instrucciones.
3. Inferir únicamente lo que sea consistente con el proyecto.
4. Si se trata de información técnica actualizable o una duda de plataforma, consultar fuentes oficiales.
5. Si continúa existiendo ambigüedad funcional importante, solicitar aclaración en lugar de inventar requisitos.

No presentar suposiciones como hechos.

Indicar explícitamente:

- Qué se conoce.
- Qué se está infiriendo.
- Qué requiere confirmación.

---

# 18. Fuentes técnicas externas

Para dudas relacionadas con:

- Sintaxis de C#.
- .NET 8.
- Windows Forms.
- Excepciones.
- APIs de .NET.
- Seguridad.
- Convenciones del lenguaje.
- Herramientas de Visual Studio.

Priorizar documentación oficial de Microsoft Learn y documentación oficial de .NET.

Para dudas relacionadas con:

- GitHub Copilot.
- Git.
- Pull Requests.
- Branches.
- GitHub Actions.
- Configuración de repositorios.

Priorizar documentación oficial de GitHub.

Para estándares o prácticas profesionales no cubiertas por la documentación oficial, recurrir a fuentes reconocidas y actuales de la industria.

No inventar APIs, métodos, opciones de configuración, paquetes NuGet, sintaxis o comportamientos.

Cuando una respuesta técnica dependa de una versión, verificar que sea compatible con **.NET 8**.

---

# 19. Control de versiones con Git y GitHub

El proyecto utiliza Git y GitHub.

Al proponer cambios:

- Mantener cambios pequeños y coherentes.
- Evitar mezclar cambios funcionales con refactorizaciones masivas.
- No incluir secretos en commits.
- Respetar la rama actual.
- No sobrescribir cambios del usuario.
- No ejecutar operaciones destructivas sin confirmación.
- No sugerir `git push --force` salvo una situación excepcional y explícitamente aprobada.
- No eliminar ramas, etiquetas o historial sin autorización.

Sugerir nombres de ramas descriptivos cuando sea necesario.

Ejemplos:

```text
feature/gestion-clientes
feature/registro-equipos
fix/validacion-servicio
refactor/modelo-servicio
```

Los mensajes de commit deben expresar claramente el cambio.

Ejemplo:

```text
feat: agregar entidad Cliente
fix: validar campos obligatorios del cliente
refactor: separar validación del formulario
```

---

# 20. Ubicación y disponibilidad de este archivo entre ramas

Este archivo debe permanecer versionado en:

```text
.github/copilot-instructions.md
```

La ubicación es repository-wide y está soportada por GitHub Copilot para instrucciones del repositorio, incluyendo Visual Studio.

Para que las instrucciones estén disponibles en cualquier rama de trabajo:

1. Crear el archivo en la rama principal del repositorio.
2. Confirmarlo mediante Git.
3. Fusionarlo o incorporarlo a las ramas activas mediante la estrategia de ramas del equipo.
4. Evitar eliminarlo o modificarlo de forma incompatible entre ramas.

Importante:

Git no comparte automáticamente un archivo entre ramas. Copilot solo puede utilizar la versión de las instrucciones disponible en el árbol de trabajo de la rama actualmente consultada.

Por lo tanto, `.github/copilot-instructions.md` debe tratarse como un archivo base del repositorio y mantenerse sincronizado entre ramas.

---

# 21. Verificación antes de finalizar una sugerencia

Antes de proponer una solución, comprobar:

## Arquitectura

- ¿El archivo se encuentra en la carpeta correcta?
- ¿La responsabilidad pertenece a esa clase?
- ¿Se está rompiendo la separación entre UI y dominio?

## C#

- ¿Los identificadores siguen las convenciones?
- ¿El código es compatible con .NET 8?
- ¿Se manejan correctamente los valores nulos?
- ¿Las excepciones tienen un manejo razonable?

## POO

- ¿La clase tiene una responsabilidad clara?
- ¿Se respeta la encapsulación?
- ¿La herencia está justificada?
- ¿Existe una solución más simple?

## Seguridad

- ¿Existen secretos hardcodeados?
- ¿Hay validación de entradas?
- ¿Se evita mostrar información sensible?
- ¿La persistencia evita consultas inseguras?

## Control de cambios

- ¿El cambio afecta solo lo necesario?
- ¿Se modifican archivos no relacionados?
- ¿Existe riesgo de romper funcionalidad existente?

---

# 22. Respuesta esperada del asistente

Cuando se solicite código, el asistente debe responder de manera estructurada:

1. Objetivo de la implementación.
2. Archivos que se crearán o modificarán.
3. Ubicación de cada archivo.
4. Código propuesto.
5. Explicación breve de las decisiones importantes.
6. Riesgos o supuestos, si existen.
7. Recomendaciones de prueba.

No generar una explicación extensa cuando el usuario solicite únicamente una modificación puntual.

---

# 23. Regla de oro del proyecto

Antes de escribir código, comprender:

> **Qué problema del negocio se está resolviendo, qué objeto del dominio representa la solución y cuál es la responsabilidad correcta de cada clase.**

La interfaz Windows Forms debe servir al dominio de TechService.

La interfaz no debe definir incorrectamente el modelo de objetos.

Las clases deben surgir principalmente de los conceptos, responsabilidades y reglas del negocio, y no únicamente de la existencia de formularios o controles visuales.

---

# 24. Contexto inicial de entidades y enumeraciones

Como punto de partida conceptual, el proyecto puede requerir entidades relacionadas con:

```text
Models/Entities/
    Cliente
    Equipo
    Servicio
    Mantenimiento
    Usuario
    RecepcionEquipo
    EntregaEquipo
```

Y enumeraciones relacionadas con:

```text
Models/Enums/
    EstadoServicio
    TipoMantenimiento
    EstadoEquipo
```

Esta lista representa un contexto inicial y no obliga a crear todas las clases.

Antes de agregar, eliminar o modificar entidades, validar la necesidad contra el requerimiento funcional y el diseño existente.

---

# 25. Prioridad final

Cuando existan varias alternativas, priorizar:

1. Requisitos del proyecto.
2. Corrección.
3. Seguridad.
4. Documentación oficial vigente.
5. Convenciones de C# y .NET.
6. Diseño orientado a objetos.
7. Simplicidad y mantenibilidad.
8. Consistencia con el repositorio existente.

No sacrificar seguridad, claridad o corrección por generar código rápidamente.
