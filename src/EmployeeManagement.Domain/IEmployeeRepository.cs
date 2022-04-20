namespace EmployeeManagement.Domain
{
    public interface IEmployeeRepository
    {
        public Task<Guid> AddEmployeeAsync(Employee.Employee employee);
        public Task<Guid> UpdateEmployeeAsync(Employee.Employee employee);

        public Task<Employee.Employee> GetEmployeeAsync(Guid Id);

        public Task<List<Employee.Employee>> GetAll();

        public Task<Employee.Employee> GetLast();

    }
}
