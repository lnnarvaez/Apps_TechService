namespace Apps_TechService.Models.Entities
{
    /// <summary>
    /// Representa el equipo o dispositivo electrónico entregado por un cliente.
    /// </summary>

    /* 
     * Regla de construcción: Un equipo no puede registrarse en el sistema sin saber a qué 
     * cliente pertenece, qué tipo de equipo es, su número de serie/código y la falla 
     * reportada por el cliente al momento de ingresarl.
     * 
     * Inicialización automática: La fecha de registro la determina el sistema 
     * en tiempo de creación.
     */

    public class Device
    {
        // Equipo
        public string DeviceCode { get; private set; }
        public string CustomerId { get; private set; }
        public string Type { get; private set; }
        public string Brand { get; private set; }
        public string Model { get; private set; }
        public string SerialNumber { get; private set; }
        public string ReportedProblem { get; private set; }
        public DateTime RegistrationDate { get; private set; }

        public Device(
            string deviceCode,
            string customerId,
            string type,
            string brand,
            string model,
            string serialNumber,
            string reportedProblem)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(deviceCode, nameof(deviceCode));
            ArgumentException.ThrowIfNullOrWhiteSpace(customerId, nameof(customerId));
            ArgumentException.ThrowIfNullOrWhiteSpace(brand, nameof(brand));
            ArgumentException.ThrowIfNullOrWhiteSpace(model, nameof(model));
            ArgumentException.ThrowIfNullOrWhiteSpace(serialNumber, nameof(serialNumber));
            ArgumentException.ThrowIfNullOrWhiteSpace(reportedProblem, nameof(reportedProblem));

            DeviceCode = deviceCode.Trim();
            CustomerId = customerId.Trim();
            Type = type;
            Brand = brand.Trim();
            Model = model.Trim();
            SerialNumber = serialNumber.Trim();
            ReportedProblem = reportedProblem.Trim();

            RegistrationDate = DateTime.UtcNow; // Condición inicial del sistema
        }

        public void UpdateReportedProblem(string updatedProblem)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(updatedProblem, nameof(updatedProblem));
            ReportedProblem = updatedProblem.Trim();
        }

    }//end class Equipment
} //end namespace
