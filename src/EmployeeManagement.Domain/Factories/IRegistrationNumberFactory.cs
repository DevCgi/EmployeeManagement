using EmployeeManagement.Domain.ValueObjects;

namespace EmployeeManagement.Domain.Factories
{
    public interface IRegistrationNumberFactory
    {
        Task<RegistrationNumberObject> Create();
    }
}
