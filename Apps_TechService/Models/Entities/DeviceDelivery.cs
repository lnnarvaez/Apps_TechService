using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/// <summary>
/// Registra la entrega y conformidad del equipo con el cliente.
/// </summary>
/* 
 Regla de construcción: Se produce al final del ciclo de vida del servicio. 
 Requiere la orden asociada, el usuario que entrega y si hubo conformidad del cliente
 */

namespace Apps_TechService.Models.Entities
{
    //Entrega al Cliente
    public class DeviceDelivery
    {
        public string DeliveryId { get; private set; }
        public string ServiceCode { get; private set; }
        public string DeliveredByUserId { get; private set; }
        public bool CustomerAccepted { get; private set; }
        public DateTime DeliveryDate { get; private set; }
        public string? Remarks { get; private set; }

        public DeviceDelivery(
            string deliveryId,
            string serviceCode,
            string deliveredByUserId,
            bool customerAccepted,
            string? remarks = null)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(deliveryId, nameof(deliveryId));
            ArgumentException.ThrowIfNullOrWhiteSpace(serviceCode, nameof(serviceCode));
            ArgumentException.ThrowIfNullOrWhiteSpace(deliveredByUserId, nameof(deliveredByUserId));

            DeliveryId = deliveryId.Trim();
            ServiceCode = serviceCode.Trim();
            DeliveredByUserId = deliveredByUserId.Trim();
            CustomerAccepted = customerAccepted;
            Remarks = remarks?.Trim();

            DeliveryDate = DateTime.UtcNow;
        }

    } // End class 
} // End namespace
