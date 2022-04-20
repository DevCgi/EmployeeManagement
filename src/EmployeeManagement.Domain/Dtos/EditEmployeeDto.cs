using EmployeeManagement.Domain.Enums;

namespace EmployeeManagement.Domain.Dtos
{
    public class EditEmployeeDto
    {
        public Guid Id { get; set; }
        public string Surname { get; set; }

        public Gender Gender { get; set; }
    }
}
