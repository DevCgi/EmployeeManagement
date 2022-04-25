using AutoFixture;
using EmployeeManagement.Domain.Factories;
using Moq;
using System.Threading.Tasks;
using Xunit;
using FluentAssertions;
using EmployeeManagement.Domain.Services;
using EmployeeManagement.Domain.Dtos;
using EmployeeManagement.Domain.ValueObjects;

namespace EmployeeManagement.Domain.Unit.Tests
{
    public class EmployeeServiceTests
    {
        /*
         * Interesują nas natomiast kompletne i działające testy jednostkowe (i tylko jednostkowe) w zakresie:
            • Kompletne testy dla obiektu pracownika (konstruktor i metoda aktualizująca dane)
            • Jeden wybrany ValueObject (konstruktor)
            • Jedna z metod handlera/serwisu: Tworzenie pracownika lub aktualizacja pracownika
        */
        private readonly EmployeeManagementFixture _fixture = new ();

        [Fact]
        public async Task Employee_Should_Be_Sucsessfully_Created()
        {
            // arrange
            var employeeDto = _fixture.Create<AddEmployeeDto>();

            var registrationNumber = "00000001";
            var registrationNumberObject = new Mock<RegistrationNumberObject>(registrationNumber).Object;

            var registrationNumberFactory = _fixture.Freeze<Mock<IRegistrationNumberFactory>>();
            _fixture.SetupCreateRegistrationNumber(registrationNumberObject);

            var employeeRepository = _fixture.Freeze<Mock<IEmployeeRepository>>();
            _fixture.SetupAddEmployeeAsync();

            var sut = _fixture.Create<EmployeeService>();

            // act
            var result = await sut.AddEmployeeAsync(employeeDto);

            // assert
            employeeRepository.Verify(
                x => x.AddEmployeeAsync(
                    It.IsAny<Employee>()), 
                Times.Once);
        }

        [Fact]
        public async Task Employee_Should_Be_Sucsessfully_Updated()
        {
            // arrange
            var employeeDto = _fixture.Create<EditEmployeeDto>();
            
            var employee = _fixture.CreateEmployeeMock();

            var employeeRepository = _fixture.Freeze<Mock<IEmployeeRepository>>();
            _fixture.SetupGetEmployeeAsync(employee.Object);

            _fixture.SetupUpdateEmployeeAsync(employee.Object);

            var sut = _fixture.Create<EmployeeService>();

            // act
            var result = await sut.EditEmployee(employeeDto);

            // assert
            employeeRepository.Verify(
                e => e.UpdateEmployeeAsync(It.IsAny<Employee>()),
                Times.Once);

            employee.Object.Surname.Value.Should().Be(employeeDto.Surname);
            employee.Object.Gender.Value.Should().Be(employeeDto.Gender);
        }

        [Fact]
        public async Task RegistrationNumberFactory_Should_Return_Correct_Number()
        {
            // arrange
            _fixture.Freeze<Mock<IEmployeeRepository>>();

            var employee = _fixture.CreateEmployeeMock();
            _fixture.SetupGetLastEmployee(employee.Object);

            var sut = _fixture.Create<RegistrationNumberFactory>();

            //act
            var result = await sut.Create();

            // assert
            result.Value.Should().Be("00000002");
        }
    }
}
