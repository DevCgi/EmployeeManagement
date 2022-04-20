using AutoMapper;
using EmployeeManagement.Domain.Services;
using MediatR;

namespace EmployeeManagement.Api.Requests.GetEmployees
{
    public class GetEmployeeRequestHandler : IRequestHandler<GetEmployeesRequest, List<EmployeeResponse>>
    {
        private readonly IEmployeeService _employeeService;
        private readonly IMapper _mapper;

        public GetEmployeeRequestHandler(IEmployeeService employeeService, IMapper mapper)
        {
            _employeeService = employeeService;
            _mapper = mapper;
        }

        public async Task<List<EmployeeResponse>> Handle(GetEmployeesRequest request, CancellationToken cancellationToken)
        {
            var response = await _employeeService.GetEmployees();
            return _mapper.Map<List<EmployeeResponse>>(response);
        }
            
    }
}
