using AutoMapper;
using EmployeeManagement.Domain.Dtos;
using EmployeeManagement.Domain.Services;
using MediatR;

namespace EmployeeManagement.Api.Requests.AddEmployee
{
    public class AddEmployeeRequestHandler : IRequestHandler<AddEmployeeRequest, Guid>
    {
        private readonly IEmployeeService _employeeService;
        private readonly IMapper _mapper;

        public AddEmployeeRequestHandler(IEmployeeService employeeService, IMapper mapper)
        {
            _employeeService = employeeService;
            _mapper = mapper;
        }

        public async Task<Guid> Handle(AddEmployeeRequest request, CancellationToken cancellationToken) 
            => await _employeeService.AddEmployeeAsync(_mapper.Map<AddEmployeeDto>(request));
    }
}
