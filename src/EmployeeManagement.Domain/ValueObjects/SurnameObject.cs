namespace EmployeeManagement.Domain.ValueObjects
{
    public class SurnameObject
    {
        public string Surname { get; private set; }

        public SurnameObject(string surname)
        {
            if(string.IsNullOrEmpty(surname))
                throw new ArgumentNullException($"{nameof(surname)} cannot be null or empty");

            if(surname.Length > 50)
                throw new ArgumentOutOfRangeException($"{nameof(surname)} cannot be longer than 50 chars");

            Surname = surname;
        }
    }
}
