using Microsoft.AspNetCore.Mvc;
using MediatR;
using EmployeeManagement.Api.Requests.AddEmployee;
using EmployeeManagement.Api.Requests.EditEmployee;
using EmployeeManagement.Api.Requests.GetEmployees;

namespace EmployeeManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly ILogger<EmployeeController> _logger;
        private readonly IMediator _mediator;

        public EmployeeController(
            ILogger<EmployeeController> logger, 
            IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpPost(Name = "AddEmployee")]
        public async Task<ActionResult<Guid>> AddEmployee(AddEmployeeRequest request)
        {
            try
            {
                return await _mediator.Send(request);
            }
            catch (Exception ex)
            {
                _logger.LogError("Bad request: {0}", ex.Message);
                return BadRequest(ex.Message);
            }
        }

        [HttpPut(Name = "EditEmployee")]
        public async Task<ActionResult<Guid>> EditEmployee(EditEmployeeRequest request)
        {
            try
            {
                return await _mediator.Send(request);
            }
            catch (Exception ex)
            {
                _logger.LogError("Bad request: {0}", ex.Message);
                return BadRequest(ex.Message);
            }
        }

        [HttpGet(Name = "GetEmployees")]
        public async Task<ActionResult<List<EmployeeResponse>>> Get()
        {
            try
            {
                return await _mediator.Send(new GetEmployeesRequest());
            }
            catch (Exception ex)
            {
                _logger.LogError("Bad request: {0}", ex.Message);
                return BadRequest(ex.Message);
            }
        }
    }
}
