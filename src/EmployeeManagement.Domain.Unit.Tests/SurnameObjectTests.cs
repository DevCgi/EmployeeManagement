using AutoFixture;
using EmployeeManagement.Domain.ValueObjects;
using FluentAssertions;
using System;
using Xunit;

namespace EmployeeManagement.Domain.Unit.Tests
{
    public class SurnameObjectTests
    {
        EmployeeManagementFixture _fixture = new();

        [Theory]
        [InlineData("a", "a")]
        [InlineData("abc", "abc")]
        public void SurnameObject_Should_Be_Created(string surname, string expected)
        {
            SurnameObject surnameObject = null;

            Action creatingSurname = () =>
            {
                surnameObject = new SurnameObject(surname);
            };

            creatingSurname.Should().NotThrow();

            surnameObject.Value.Should().Be(expected);
        }

        [Fact]
        public void CreatingSurnameObject_Should_Throw_ArgumentNullException()
        {
            var surname = string.Empty;

            Action creatingSurname = () => new SurnameObject(surname);

            creatingSurname.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void CreatingSurnameObject_Should_Throw_ArgumentOutOfRangeException()
        {
            var surname = _fixture.CreateMany<char>(51).ToString();

            Action creatingSurname = () => new SurnameObject(surname);

            creatingSurname.Should().Throw<ArgumentOutOfRangeException>();
        }
    }
}
