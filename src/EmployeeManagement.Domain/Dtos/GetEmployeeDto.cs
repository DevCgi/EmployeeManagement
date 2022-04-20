using EmployeeManagement.Domain.Enums;

namespace EmployeeManagement.Domain.Dtos
{
    public class GetEmployeeDto
    {
        public Guid Id { get; set; }

        public string RegistrationNumber { get; set; }

        public string Surname { get; set; }

        public Gender Gender { get; set; }
    }
}
