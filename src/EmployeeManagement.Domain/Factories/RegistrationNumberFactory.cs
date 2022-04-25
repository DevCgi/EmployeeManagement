using EmployeeManagement.Domain.ValueObjects;

namespace EmployeeManagement.Domain.Factories
{
    public class RegistrationNumberFactory : IRegistrationNumberFactory
    {
        private readonly IEmployeeRepository _employeeRepository;
        private const string numberFormat = "{0:00000000}";

        public RegistrationNumberFactory(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<RegistrationNumberObject> Create()
        {
            int registrationNumber;
            var lastEmployee = await _employeeRepository.GetLast();

            if(lastEmployee == null)
            {
                registrationNumber = 1;
            }
            else
            {
                if (int.TryParse(lastEmployee.RegistrationNumber.Value, out registrationNumber))
                {
                    registrationNumber++;
                }
            }

            return new RegistrationNumberObject(string.Format(numberFormat, registrationNumber));
        }
    }
}
