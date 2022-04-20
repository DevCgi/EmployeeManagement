using EmployeeManagement.Domain.Enums;

namespace EmployeeManagement.Domain.Dtos
{
    public class AddEmployeeDto
    {
        public string Surname { get; set; }

        public Gender Gender { get; set; }
    }
}
