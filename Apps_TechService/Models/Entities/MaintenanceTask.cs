using Apps_TechService.Models.Enums;

namespace Apps_TechService.Models.Entities
{
    public class MaintenanceTask
    {
        #region Properties
        public string MaintenanceId { get; private set; }
        public string ServiceCode { get; private set; }
        public string TechnicianId { get; private set; }
        public MaintenanceType Type { get; }
        public DateOnly StartDate { get; private set; }
        public DateOnly? EndDate { get; private set; }
        public decimal LaborCost { get; private set; }
        public string? Observations { get; private set; }

        //public bool IsCompleted => EndDate.HasValue;
        /// <summary>
        /// Indica si la tarea de mantenimiento ha sido completada.
        /// </summary>
        public bool IsCompleted
        {
            get { return EndDate.HasValue; }
        }

        #endregion Properties

        protected MaintenanceTask(
            string maintenanceId,
            string serviceCode,
            string technicianId,
            MaintenanceType type,
            decimal laborCost)
        {
            MaintenanceId = ValidateRequiredValue(maintenanceId, nameof(maintenanceId));
            ServiceCode = ValidateRequiredValue(serviceCode, nameof(serviceCode));
            TechnicianId = ValidateRequiredValue(technicianId, nameof(technicianId));

            if (laborCost < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(laborCost),
                    "El costo de mano de obra no puede ser negativo.");
            } 
             
            MaintenanceId = maintenanceId.Trim();
            ServiceCode = serviceCode.Trim();
            TechnicianId = technicianId.Trim();
            Type = type;
            LaborCost = laborCost;
            StartDate = DateOnly.FromDateTime(DateTime.UtcNow);
        }

        //public abstract decimal CalculateTotalCost();
        // Método polimórfico para calcular el costo total
        public decimal CalculateTotalCost()
        {
            return LaborCost;
        }

        private static string ValidateRequiredValue(
            string value,
            string parameterName)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(
                value,
                parameterName);
            return value;
        }

        // Método plantilla (Template Method Pattern) para cierre coherente
        protected void MarkCompleted(string? observations)
        {
            if (IsCompleted)
            { 
                throw new InvalidOperationException("Este mantenimiento ya se encuentra finalizado.");
            }

            Observations = observations?.Trim();
            EndDate = DateOnly.FromDateTime(DateTime.UtcNow);
        }

    } //end class
} //end namespace
