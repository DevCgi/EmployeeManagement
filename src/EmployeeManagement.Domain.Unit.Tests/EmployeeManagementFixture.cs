using AutoFixture;
using AutoFixture.AutoMoq;
using EmployeeManagement.Domain.Dtos;
using EmployeeManagement.Domain.Enums;
using EmployeeManagement.Domain.Factories;
using EmployeeManagement.Domain.Services;
using EmployeeManagement.Domain.ValueObjects;
using Moq;
using Moq.Language.Flow;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Domain.Unit.Tests
{
    public class EmployeeManagementFixture : Fixture
    {
        public EmployeeManagementFixture()
        {
            Customize(new AutoMoqCustomization());
            Behaviors.OfType<ThrowingRecursionBehavior>().ToList()
                .ForEach(b => Behaviors.Remove(b));
            Behaviors.Add(new OmitOnRecursionBehavior());
        }

        public ISetup<IEmployeeRepository, Task<Guid>> SetupAddEmployeeAsync()
        {
            return this.Freeze<Mock<IEmployeeRepository>>()
                .Setup(x => x.AddEmployeeAsync(It.IsAny<Employee>()));
        }

        public ISetup<IEmployeeRepository, Task<Guid>> SetupUpdateEmployeeAsync(Employee employee)
        {
            return this.Freeze<Mock<IEmployeeRepository>>()
                .Setup(x => x.UpdateEmployeeAsync(It.Is<Employee>(e => e.Equals(employee))));
        }

        public void SetupGetEmployeeAsync(Employee employee)
        {
            this.Freeze<Mock<IEmployeeRepository>>()
                .Setup(x => x.GetEmployeeAsync(It.IsAny<Guid>()))
                .ReturnsAsync(employee);
        }

        public void SetupCreateRegistrationNumber(RegistrationNumberObject registrationNumber)
        {
            this.Freeze<Mock<IRegistrationNumberFactory>>()
                .Setup(x => x.Create())
                .ReturnsAsync(registrationNumber);
        }

        public void SetupGetLastEmployee(Employee employee)
        {
            this.Freeze<Mock<IEmployeeRepository>>()
                .Setup(x => x.GetLast())
                .ReturnsAsync(employee);
        }

        public Mock<Employee> CreateEmployeeMock()
        {
            var id = this.Create<Guid>();

            var registrationNumber = "00000001";
            var registrationNumberObject = new Mock<RegistrationNumberObject>(registrationNumber).Object;

            var surname = this.Create<string>();
            var surnameObject = new Mock<SurnameObject>(surname);

            var gender = this.Create<Gender>();
            var genderObject = new Mock<GenderObject>(gender);

            return new Mock<Employee>(
                id,
                registrationNumberObject,
                surnameObject.Object,
                genderObject.Object);
        }

        public ISetup<IEmployeeService, Task<Guid>> SetupEmployeeServiceAddEmployeeAsync()
        {
            return this.Freeze<Mock<IEmployeeService>>()
                .Setup(x => x.AddEmployeeAsync(It.IsAny<AddEmployeeDto>()));
        }
    }
}
