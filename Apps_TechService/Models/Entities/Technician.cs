namespace Apps_TechService.Models.Entities
{
   public  class Technician : Individuo
    {
        #region Properties
        public string Specialty
        { get
            {
                return Specialty;
            }
            set
            {
                Specialty = ValidateRequiredValue(
                    value,
                    nameof(Specialty));
            }
        }       

        #endregion Properties

        #region Constructors

        public Technician () : base ()
        {
            Specialty = null!;
        }

        public Technician(
            string nationalId,
            string firstName,
            string lastName,
            string specialty)
            : base(
                nationalId,
                firstName,
                lastName)
        {
            Specialty = ValidateRequiredValue(
                specialty,
                nameof(specialty));            
        }

        #endregion Constructors

        public void UpdateSpecialty(string specialty)
        {
            Specialty = ValidateRequiredValue(
                specialty,
                nameof(specialty));
        }

        /**public override string GetProfile()
        {
            return
                $"Technician: {FullName} | " +
                $"Spec: {Specialty} | " +
                $"Lic: {ProfessionalLicense}";
        }**/

        private static string ValidateRequiredValue(
            string value,
            string parameterName)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(
                value,
                parameterName);

            return value.Trim();
        }

    } //end of class Technician
} //end of namespace
