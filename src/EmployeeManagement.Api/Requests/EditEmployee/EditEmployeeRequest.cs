using EmployeeManagement.Domain.Enums;
using MediatR;

namespace EmployeeManagement.Api.Requests.EditEmployee
{
    public class EditEmployeeRequest : IRequest<Guid>
    {
        public string Id { get; set; }
        public string Surname { get; set; }

        public Gender Gender { get; set; }
    }
}
