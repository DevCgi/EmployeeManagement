using EmployeeManagement.Domain;
using EmployeeManagement.Domain.Employee;

namespace EmployeeManagemet.Infrastructure
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly List<Employee> _employees;

        public EmployeeRepository()
        {
            _employees = new List<Employee>();
        }

        public Task<Guid> AddEmployeeAsync(Employee employee)
        {
            return Task.Run(() =>
            {
               _employees.Add(employee);
                return employee.Id;
            });
            
        }

        public Task<List<Employee>> GetAll()
        {
            return Task.Run(() => _employees);
        }

        public Task<Employee> GetEmployeeAsync(Guid Id)
        {
            return Task.Run(() => _employees.FirstOrDefault(e => e.Id == Id));
        }

        public Task<Employee> GetLast()
        {
            return Task.Run(() =>
            {
                return _employees.LastOrDefault();
            });
        }

        public Task<Guid> UpdateEmployeeAsync(Employee employee)
        {
            return Task.Run(() =>
            {
                var employeeToDel = _employees.FirstOrDefault(e => e.Id == employee.Id);
                if (employeeToDel != null)
                    _employees.Remove(employeeToDel);

                _employees.Add(employee);
                return employee.Id;
            });
        }
    }
}
