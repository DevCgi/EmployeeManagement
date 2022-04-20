using AutoFixture;
using EmployeeManagement.Domain.Factories;
using EmployeeManagemet.Infrastructure;
using Moq;
using System.Threading.Tasks;
using Xunit;
using FluentAssertions;

namespace EmployeeManagement.Domain.Unit.Tests
{
    public class EmployeeServiceTests
    {
        private readonly EmployeeFixture _fixture = new EmployeeFixture();

        [Fact]
        public async Task RegistrationNumberFactory_Should_Return_Correct_Number()
        {
            // arrange
            _fixture.Freeze<Mock<EmployeeRepository>>();

            var sut = _fixture.Create<RegistrationNumberFactory>();

            //act
            var result = await sut.Create();

            // assert
            result.RegistrationNumber.Should().Be("00000001");
        }

        [Fact]
        public async Task Employee_Was_Sucsessfully_Created()
        {

        }
    }
}
