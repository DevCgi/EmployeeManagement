using EmployeeManagement.Domain.Dtos;

namespace EmployeeManagement.Domain.Services
{
    public interface IEmployeeService
    {
        Task<Guid> AddEmployeeAsync(AddEmployeeDto employeeDto);

        Task<Guid> EditEmployee(EditEmployeeDto employeeDto);

        Task<List<GetEmployeeDto>> GetEmployees();
    }
}
