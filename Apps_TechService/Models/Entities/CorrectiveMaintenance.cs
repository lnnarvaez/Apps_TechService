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
            ArgumentException.ThrowIfNullOrWhiteSpace(diagnosedFault, nameof(diagnosedFault));

            DiagnosedFault = diagnosedFault.Trim();
            ReplacedComponents = "None";
            ReplacementPartsCost = 0.0m;
        }

        public void SetSpareParts(string components, decimal partsCost)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(components, nameof(components));
            if (partsCost < 0)
                throw new ArgumentOutOfRangeException(nameof(partsCost), "El costo de repuestos no puede ser negativo.");

            ReplacedComponents = components.Trim();
            ReplacementPartsCost = partsCost;
        }

        public override decimal CalculateTotalCost() => LaborCost + ReplacementPartsCost;

        public void FinalizeCorrective(string workDetails, string? observations = null)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(workDetails, nameof(workDetails));
            MarkCompleted($"{workDetails}. Obs: {observations}".Trim());
        }






    }
}
