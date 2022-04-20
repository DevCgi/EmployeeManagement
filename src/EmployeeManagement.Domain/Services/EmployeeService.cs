using EmployeeManagement.Domain.Dtos;
using EmployeeManagement.Domain.Factories;
using EmployeeManagement.Domain.ValueObjects;

namespace EmployeeManagement.Domain.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IRegistrationNumberFactory _registrationNumberFactory;
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeService(IRegistrationNumberFactory registrationNumberFactory, IEmployeeRepository employeeRepository)
        {
            _registrationNumberFactory = registrationNumberFactory;
            _employeeRepository = employeeRepository;
        }

        public async Task<Guid> AddEmployeeAsync(AddEmployeeDto employeeDto)
        {
            var surname = new SurnameObject(employeeDto.Surname);
            var gender = new GenderObject(employeeDto.Gender);
            var registrationNumber = await _registrationNumberFactory.Create();
            var employee = new Employee.Employee(Guid.NewGuid(), registrationNumber, surname, gender);

            await _employeeRepository.AddEmployeeAsync(employee);

            return employee.Id;
        }

        public async Task<Guid> EditEmployee(EditEmployeeDto employeeDto)
        {
            var surname = new SurnameObject(employeeDto.Surname);
            var gender = new GenderObject(employeeDto.Gender);

            var employee = await _employeeRepository.GetEmployeeAsync(employeeDto.Id);
            employee.Update(surname, gender);

            await _employeeRepository.UpdateEmployeeAsync(employee);

            return employee.Id;
        }

        public async Task<List<GetEmployeeDto>> GetEmployees()
        {
            var employees = await _employeeRepository.GetAll();

            var employeesDto = new List<GetEmployeeDto>();

            employees.ToList().ForEach(e =>
            {
                employeesDto.Add(new GetEmployeeDto()
                {
                    Id = e.Id,
                    Gender = e.Gender.Gender,
                    RegistrationNumber = e.RegistrationNumber.RegistrationNumber,
                    Surname = e.Surname.Surname,
                });
            });

            return employeesDto;
        }
    }
}
