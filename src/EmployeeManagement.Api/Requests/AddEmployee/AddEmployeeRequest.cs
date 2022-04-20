using EmployeeManagement.Domain.Enums;
using MediatR;

namespace EmployeeManagement.Api.Requests.AddEmployee
{
    public class AddEmployeeRequest : IRequest<Guid>
    {
        public string Surname { get; set; }

        public Gender Gender { get; set; }
    }
}
