using AutoFixture;
using AutoMapper;
using EmployeeManagement.Api.Requests;
using EmployeeManagement.Api.Requests.AddEmployee;
using EmployeeManagement.Domain.Dtos;
using EmployeeManagement.Domain.Services;
using Moq;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace EmployeeManagement.Domain.Unit.Tests
{
    public class AddEmployeeRequestHandlerTests
    {
        EmployeeManagementFixture _fixture = new ();
        IMapper _mapper;

        public AddEmployeeRequestHandlerTests()
        {
            var config = new MapperConfiguration(cfg => cfg.AddProfiles(new List<Profile>
            {
                new EmployeeDtoAutoMapperConfiguration(),
            }));

            _mapper = config.CreateMapper();
        }

        [Fact]
        public async Task RequestHandler_Should_Process_Request()
        {
            // arrange
            var request = _fixture.Create<AddEmployeeRequest>();
            var employeeService = _fixture.Freeze<Mock<IEmployeeService>>();
            _fixture.SetupEmployeeServiceAddEmployeeAsync();
            
            var sut = new AddEmployeeRequestHandler(employeeService.Object, _mapper);

            // act
            var response = await sut.Handle(request, CancellationToken.None);

            // assert
            employeeService.Verify(e => e.AddEmployeeAsync(
                    It.IsAny<AddEmployeeDto>()), 
                Times.Once);
        }
    }
}
