using Apps_TechService.Models.Enums;

namespace Apps_TechService.Models.Entities
{
    public class CorrectiveMaintenance : MaintenanceTask
    {

        public string DiagnosedFault { get; private set; }
        public string ReplacedComponents { get; private set; }
        public decimal ReplacementPartsCost { get; private set; }

        public CorrectiveMaintenance(
            string maintenanceId,
            string serviceCode,
            string technicianId,
            string diagnosedFault,
            decimal laborCost)
            : base(maintenanceId, serviceCode, technicianId, MaintenanceType.Corrective, laborCost)
        {
            diagnosedFault = ValidateRequiredValue(diagnosedFault, nameof(diagnosedFault));
            
            DiagnosedFault = diagnosedFault.Trim();
            ReplacedComponents = "Ninguno";
            ReplacementPartsCost = 0.0m; //m esta indicando que es un decimal
        }

        public void SetSpareParts(string components, decimal partsCost)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(components, nameof(components));

            if (partsCost < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(partsCost),
                    "El costo de repuestos no puede ser negativo.");
            }
                
            ReplacedComponents = components.Trim();
            ReplacementPartsCost = partsCost;
        }

       // public override decimal CalculateTotalCost() => LaborCost + ReplacementPartsCost;

        public decimal CalculateTotalCost()
        {
            decimal totalCost = LaborCost + ReplacementPartsCost;
            return totalCost;
        }
        public void FinalizeCorrective(string workDetails, string? observations = null)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(workDetails, nameof(workDetails));
            MarkCompleted($"{workDetails}. Observación: {observations}".Trim());
        }

    } // end class
} // end namespace
