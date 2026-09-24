using Apps_TechService.Models.Enums;

namespace Apps_TechService.Models.Entities
{
    public class PreventiveMaintenance : MaintenanceTask
    {
        //Rutinas de protocolos de limpieza: Limpieza de ventiladores, cambio de pasta térmica y optimización",
        //Optimización de sistema operativo y limpieza de archivos" o "Revisión de hardware, limpieza
        //y verificación de servicios"
        public string ChecklistProtocol { get; private set; } 
        public decimal ConsumablesCost { get; private set; }

        public PreventiveMaintenance(
            string maintenanceId,
            string serviceCode,
            string technicianId,
            string checklistProtocol,
            decimal laborCost,
            decimal consumablesCost = 0.0m)
            : base(maintenanceId, serviceCode, technicianId, MaintenanceType.Preventive, laborCost)
        {
            checklistProtocol = ValidateRequiredValue(checklistProtocol, nameof(checklistProtocol));

            if (consumablesCost < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(consumablesCost),
                    "El costo de insumos no puede ser negativo.");
            }
            
            ChecklistProtocol = checklistProtocol.Trim();
            ConsumablesCost = consumablesCost;
        }

        //public override decimal CalculateTotalCost() => LaborCost + ConsumablesCost;

        public decimal CalculateTotalCost()
        {
            return LaborCost + ConsumablesCost;
        }

        public void FinalizePreventive(string? observations = null)
        {
            MarkCompleted (observations);
            //Observations = observations;
        }
    } //End class
} // End namespace
