namespace EmployeeManagement.Domain.ValueObjects
{
    public class RegistrationNumberObject
    {
        public string Value { get; private set; }

        public RegistrationNumberObject(string registrationNumber)
        {
            if (string.IsNullOrEmpty(registrationNumber))
                throw new ArgumentNullException($"{nameof(registrationNumber)} cannot be null or empty");

            if (registrationNumber.Length > 8)
                throw new ArgumentException($"{nameof(registrationNumber)} cannot be longer than 8 chars");

            if (registrationNumber.Length < 8)
                throw new ArgumentException($"{nameof(registrationNumber)} cannot be shorter than 8 chars");

            Value = registrationNumber;
        }
    }
}
