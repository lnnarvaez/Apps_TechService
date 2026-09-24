using Apps_TechService.Models.Enums;
/// <summary>
/// Registra las labores técnicas y diagnósticos aplicados sobre un equipo.
/// </summary>
/*
 * Regla de construcción: Representa el acto de recibir el hardware. 
 * Exige el código del equipo, el receptor y las condiciones físicas en las que ingresa.
 * Los accesorios u observaciones son complementarios.
 * Lo que NO debe ir en el constructor: WorkPerformed, Observations, 
 * FinalCost ni EndDate (no tienen sentido al iniciar el mantenimiento).
 */
namespace Apps_TechService.Models.Entities
{
    //Registro de Mantenimiento Técnico
    public class MaintenanceRecord
    {
        public string MaintenanceId { get; private set; }
        public string ServiceCode { get; private set; }
        public string TechnicianId { get; private set; }
        public MaintenanceType Type { get; private set; }
        public string Diagnosis { get; private set; }
        public DateTime StartDate { get; private set; }

        // Propiedades que se poblarán durante o al finalizar el trabajo
        public string? WorkPerformed { get; private set; }
        public string? Observations { get; private set; }
        public decimal FinalCost { get; private set; }
        public DateTime? EndDate { get; private set; }
        public bool IsCompleted => EndDate.HasValue;

        public MaintenanceRecord(
            string maintenanceId,
            string serviceCode,
            string technicianId,
            MaintenanceType type,
            string diagnosis)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(maintenanceId, nameof(maintenanceId));
            ArgumentException.ThrowIfNullOrWhiteSpace(serviceCode, nameof(serviceCode));
            ArgumentException.ThrowIfNullOrWhiteSpace(technicianId, nameof(technicianId));
            ArgumentException.ThrowIfNullOrWhiteSpace(diagnosis, nameof(diagnosis));

            MaintenanceId = maintenanceId.Trim();
            ServiceCode = serviceCode.Trim();
            TechnicianId = technicianId.Trim();
            Type = type;
            Diagnosis = diagnosis.Trim();

            StartDate = DateTime.UtcNow;
            FinalCost = 0.0m;
        }

        // El resultado técnico se establece al concluir la labor
        public void FinalizeWork(string workPerformed, decimal finalCost, string? observations = null)
        {
            if (IsCompleted)
                throw new InvalidOperationException("Este mantenimiento ya ha sido completado previamente.");

            ArgumentException.ThrowIfNullOrWhiteSpace(workPerformed, nameof(workPerformed));

            if (finalCost < 0)
                throw new ArgumentOutOfRangeException(nameof(finalCost), "El costo final no puede ser menor a 0.");

            WorkPerformed = workPerformed.Trim();
            FinalCost = finalCost;
            Observations = observations?.Trim();
            EndDate = DateTime.UtcNow;
        }
    } //end class
} //end namespace
