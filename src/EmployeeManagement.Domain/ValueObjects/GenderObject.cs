using EmployeeManagement.Domain.Enums;

namespace EmployeeManagement.Domain.ValueObjects
{
    public class GenderObject
    {
        public Gender Gender { get; private set; }

        public GenderObject(Gender gender)
        {
            Gender = gender;
        }
    }
}
