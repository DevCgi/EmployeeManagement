using AutoMapper;
using EmployeeManagement.Domain.Dtos;
using EmployeeManagement.Domain.Services;
using MediatR;

namespace EmployeeManagement.Api.Requests.EditEmployee
{
    public class EditEmployeeRequestHandler : IRequestHandler<EditEmployeeRequest, Guid>
    {
        private readonly IEmployeeService _employeeService;
        private readonly IMapper _mapper;

        public EditEmployeeRequestHandler(IEmployeeService employeeService, IMapper mapper)
        {
            _employeeService = employeeService;
            _mapper = mapper;
        }

        public async Task<Guid> Handle(EditEmployeeRequest request, CancellationToken cancellationToken)
            => await _employeeService.EditEmployee(_mapper.Map<EditEmployeeDto>(request));
    }
}
