namespace Apps_TechService.Models.Entities
{
    public class Individuo
    {
        #region Properties
        public string NationalID { get; private set; }

        public string FirstName { get; private set; }

        public string LastName { get; private set; }

        public string? Phone { get; set; }

        public string? Email { get; set; }

        public bool IsActive { get; private set; }

        public string FullName => $"{FirstName} {LastName}";

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Inicialización de nuevas instancias como una instancia nula
        /// </summary>
        protected Individuo()
        {
            //Constructor por default
            NationalID = null!;
            FirstName = null!;
            LastName = null!;
            IsActive = false;
        }

        /// <summary>
        /// Inicialización de nuevas instancias con garantía de valores validos
        /// </summary>
        /// <param name="nationalID">Número de cédula</param>
        /// <param name="firstName">Nombre completo</param>
        /// <param name="lastName">Apellidos</param>
        protected Individuo(
            string nationalID,
            string firstName,
            string lastName)
        {
            // Se valida que los valores requeridos no sean nulos o vacíos y
            // se asignan a las propiedades correspondientes.
            NationalID = ValidateRequiredValue(
                    nationalID,
                    nameof(nationalID));

            FirstName = ValidateRequiredValue(
                firstName,
                nameof(firstName));

            LastName = ValidateRequiredValue(
                lastName,
                nameof(lastName));

            IsActive = true;
        }

        #endregion Constructors

        public void UpdateContactInfo(
            string? phone,
            string? email)
        {
            Phone = NormalizeOptionalValue(phone);
            Email = NormalizeOptionalValue(email);
        }

        public void UpdateName(
            string firstName,
            string lastName)
        {
            FirstName = ValidateRequiredValue(
                firstName,
                nameof(firstName));

            LastName = ValidateRequiredValue(
                lastName,
                nameof(lastName));
        }

        protected void ChangeNationalId(
            string nationalId)
        {
            NationalID = ValidateRequiredValue(
            nationalId,
            nameof(nationalId));
        }

        public void Activate()
        {
            IsActive = true;
        }

        public void Deactivate()
        {
            IsActive = false;
        }

        public string GetProfile ()
        {
            return string.Empty;
        }

        /// <summary>
        /// Valida que un valor requerido no sea nulo, vacío o contenga solo espacios en blanco.
        /// </summary>
        /// <param name="value">Valor que debe validarse</param>
        /// <param name="parameterName">Nombre del parámetro</param>
        /// <returns>El valor validado</returns>
        private static string ValidateRequiredValue(
            string value,
            string parameterName)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(
                value,
                parameterName);

            return value;
        }

        /// <summary>
        /// Normaliza un valor opcional, devolviendo null si es nulo,
        /// vacío o contiene solo espacios en blanco; de lo contrario,
        /// devuelve el valor recortado.
        /// </summary>
        /// <param name="value">Valor que debe normalizarse</param>
        /// <returns>Null si el valor es nulo, vacío o contiene solo espacios en blanco;
        /// de lo contrario, el valor recortado.
        /// </returns>
        private static string? NormalizeOptionalValue(
            string? value)
        {
            return string.IsNullOrWhiteSpace(value)
                ? null
                : value.Trim();
        }

    } //End class

} //End namespace
