using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Apps_TechService.Models.Entities
{
    public class Device
    {
        #region Properties
        public string DeviceCode { get; private set; }
        public string CustomerId { get; private set; }
        public string Type { get; private set; }
        public string Brand { get; private set; } 
        public string Model { get; private set; }
        public string SerialNumber { get; private set; }
        public string ReportedProblem { get; private set; }
        public DateOnly RegistrationDate {  get; private set; }

        #endregion Properties

        #region Constructors
        Device () 
        { 
            //Constructor por default
        }

        public Device (
            string deviceCode,
            string custoomerId,
            string type,
            string brand,
            string reportedProblem
            )
        {
            ArgumentException.ThrowIfNullOrWhiteSpace ( deviceCode, nameof (deviceCode));
            ArgumentException.ThrowIfNullOrWhiteSpace (custoomerId, nameof (custoomerId));
            ArgumentException.ThrowIfNullOrWhiteSpace (brand, nameof (brand));
            ArgumentException.ThrowIfNullOrWhiteSpace(reportedProblem, nameof (brand));

            DeviceCode = deviceCode;
            CustomerId = custoomerId;
            Type = type;
            Brand = brand;
            ReportedProblem = reportedProblem;
        }
        #endregion 

        public void UpdateReportedProblem (string updatedProblem)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace (@updatedProblem, nameof (@updatedProblem));
            ReportedProblem = updatedProblem; // Asignar el reporte del problema.
        } //end Methods


    }//end class
} //end namespace
