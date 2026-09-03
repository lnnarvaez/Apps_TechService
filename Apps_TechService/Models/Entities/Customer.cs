namespace Apps_TechService.Models.Entities
{
    public class Customer : Individuo
    {
        #region Properties
        public string? Address
        {
            get
            {
                return Address;
            }
            set
            {
                Address = NormalizeAddress(value);
            }
        }

        #endregion Properties

        #region Constructors
        public Customer(
        string nationalId,
        string firstName,
        string lastName,
        string? address = null)
        : base(
                nationalId,
                firstName,
                lastName)
        {
            Address = NormalizeAddress(address);
        }

        /// <summary>
        /// Inicialización de nuevas instancias como una instancia nula
        /// </summary>
        protected Customer()
        {
            // Constructor por default
            Address = null;
        }
        
        #endregion Constructors

        
        /* public override string GetProfile ()
        {
            return $"Customer: {FullName} (ID: {NationalID})";
        }*/

        private static string? NormalizeAddress(string? address)
        {
            return string.IsNullOrWhiteSpace(address)
                ? null
                : address.Trim();
        }
        
    } // End of class Customer
} // End of namespace
