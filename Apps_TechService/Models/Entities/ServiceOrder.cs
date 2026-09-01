using Apps_TechService.Models.Enums;
/// <summary>
/// Representa la orden de servicio principal solicitada por el cliente.
/// </summary>
/*
 * Regla de construcción: Para abrir un servicio solo se requiere el identificador, 
 * el equipo asignado, el usuario que abre la orden, el tipo de mantenimiento y el 
 * nombre/concepto general.
 * 
 * Inicialización automática: Nace obligatoriamente en estado Pending y con 
 * RequestDate = DateTime.UtcNow
 */
namespace Apps_TechService.Models.Entities
{
    //(Orden de Servicio)
    public class ServiceOrder
    {
        public string ServiceCode { get; private set; }
        public string DeviceCode { get; private set; }
        public string CreatedByUserId { get; private set; }
        public string ServiceName { get; private set; }
        public MaintenanceType MaintenanceType { get; private set; }
        public ServiceStatus Status { get; private set; }
        public DateTime RequestDate { get; private set; }
        public DateTime? StartDate { get; private set; }
        public DateTime? CompletionDate { get; private set; }
        public decimal EstimatedCost { get; private set; }
        public string? Description { get; private set; }

        // Constructor que establece la invariante de inicio del servicio
        public ServiceOrder(
            string serviceCode,
            string deviceCode,
            string createdByUserId,
            string serviceName,
            MaintenanceType maintenanceType)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(serviceCode, nameof(serviceCode));
            ArgumentException.ThrowIfNullOrWhiteSpace(deviceCode, nameof(deviceCode));
            ArgumentException.ThrowIfNullOrWhiteSpace(createdByUserId, nameof(createdByUserId));
            ArgumentException.ThrowIfNullOrWhiteSpace(serviceName, nameof(serviceName));

            ServiceCode = serviceCode.Trim();
            DeviceCode = deviceCode.Trim();
            CreatedByUserId = createdByUserId.Trim();
            ServiceName = serviceName.Trim();
            MaintenanceType = maintenanceType;

            // Estado inicial coherente garantizado por diseño
            Status = ServiceStatus.Pending;
            RequestDate = DateTime.UtcNow;
            EstimatedCost = 0.0m;
        }

        public void SetEstimatedCost(decimal cost, string? description = null)
        {
            if (cost < 0)
                throw new ArgumentOutOfRangeException(nameof(cost), "El costo estimado no puede ser negativo.");

            EstimatedCost = cost;
            if (!string.IsNullOrWhiteSpace(description))
                Description = description.Trim();
        }

        public void StartDiagnosis()
        {
            if (Status != ServiceStatus.Pending)
                throw new InvalidOperationException("Solo un servicio 'Pending' puede pasar a diagnóstico.");

            Status = ServiceStatus.InDiagnosis;
            StartDate ??= DateTime.UtcNow;
        }

        public void BeginWork()
        {
            if (Status != ServiceStatus.Pending && Status != ServiceStatus.InDiagnosis)
                throw new InvalidOperationException("El trabajo solo puede iniciar desde estado Pendiente o En Diagnóstico.");

            Status = ServiceStatus.InProgress;
            StartDate ??= DateTime.UtcNow;
        }

        public void Complete()
        {
            if (Status != ServiceStatus.InProgress && Status != ServiceStatus.InDiagnosis)
                throw new InvalidOperationException("No se puede finalizar un servicio que no esté en curso o diagnóstico.");

            Status = ServiceStatus.Completed;
            CompletionDate = DateTime.UtcNow;
        }

        public void MarkAsDelivered()
        {
            if (Status != ServiceStatus.Completed)
                throw new InvalidOperationException("El servicio debe estar finalizado antes de marcarse como entregado.");

            Status = ServiceStatus.Delivered;
        }

        public void Cancel()
        {
            if (Status == ServiceStatus.Delivered)
                throw new InvalidOperationException("No se puede cancelar un servicio que ya fue entregado.");

            Status = ServiceStatus.Cancelled;
        }

    } //End class   
} //end namespace
