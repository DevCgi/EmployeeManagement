using EmployeeManagement.Domain.Enums;

namespace EmployeeManagement.Api.Requests.GetEmployees
{
    public class EmployeeResponse
    {
        public Guid Id { get; set; }

        public string RegistrationNumber { get; set; }

        public string Surname { get; set; }

        public Gender Gender { get; set; }
    }
}
