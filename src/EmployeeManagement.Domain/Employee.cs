using EmployeeManagement.Domain.ValueObjects;

namespace EmployeeManagement.Domain
{
    public class Employee
    {
        public Guid Id { get; protected set; }

        public RegistrationNumberObject RegistrationNumber { get; protected set; }

        public SurnameObject Surname { get; protected set; }

        public GenderObject Gender { get; protected set; }

        public Employee(Guid id, RegistrationNumberObject registrationNumber, SurnameObject surname, GenderObject gender)
        {
            Id = id;
            RegistrationNumber = registrationNumber;
            Surname = surname;
            Gender = gender;
        }

        public void Update(SurnameObject surname, GenderObject gender)
        {
            Surname = surname;
            Gender = gender;
        }
    }
}
