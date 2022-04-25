using EmployeeManagement.Domain.Enums;

namespace EmployeeManagement.Domain.ValueObjects
{
    public class GenderObject
    {
        public Gender Value { get; private set; }

        public GenderObject(Gender gender)
        {
            Value = gender;
        }
    }
}
