using MediatR;

namespace EmployeeManagement.Api.Requests.GetEmployees
{
    public class GetEmployeesRequest : IRequest<List<EmployeeResponse>>
    {
    }
}
