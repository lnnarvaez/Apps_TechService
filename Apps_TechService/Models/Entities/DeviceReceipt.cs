/// <summary>
/// Documenta la recepción formal y el estado físico del equipo al ingresar.
/// </summary>
/* 
 * Regla de construcción: Representa el acto de recibir el hardware. 
 * Exige el código del equipo, el receptor y las condiciones físicas 
 * en las que ingresa. Los accesorios u observaciones son complementarios.
 *
 */
namespace Apps_TechService.Models.Entities
{
    //Recepción Física
    public class DeviceReceipt
    {
        public string ReceiptId { get; private set; }
        public string DeviceCode { get; private set; }
        public string ReceivedByUserId { get; private set; }
        public string PhysicalCondition { get; private set; }
        public DateTime ReceiptDate { get; private set; }
        public string? IncludedAccessories { get; private set; }
        public string? Remarks { get; private set; }

        public DeviceReceipt(
            string receiptId,
            string deviceCode,
            string receivedByUserId,
            string physicalCondition)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(receiptId, nameof(receiptId));
            ArgumentException.ThrowIfNullOrWhiteSpace(deviceCode, nameof(deviceCode));
            ArgumentException.ThrowIfNullOrWhiteSpace(receivedByUserId, nameof(receivedByUserId));
            ArgumentException.ThrowIfNullOrWhiteSpace(physicalCondition, nameof(physicalCondition));

            ReceiptId = receiptId.Trim();
            DeviceCode = deviceCode.Trim();
            ReceivedByUserId = receivedByUserId.Trim();
            PhysicalCondition = physicalCondition.Trim();

            ReceiptDate = DateTime.UtcNow;
        }

        public void SetAdditionalDetails(string? includedAccessories, string? remarks)
        {
            IncludedAccessories = includedAccessories?.Trim();
            Remarks = remarks?.Trim();
        }
    }
}
