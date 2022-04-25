namespace EmployeeManagement.Domain
{
    public interface IEmployeeRepository
    {
        public Task<Guid> AddEmployeeAsync(Employee employee);
        public Task<Guid> UpdateEmployeeAsync(Employee employee);

        public Task<Employee> GetEmployeeAsync(Guid Id);

        public Task<List<Employee>> GetAll();

        public Task<Employee> GetLast();

    }
}
