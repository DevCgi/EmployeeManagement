using AutoFixture;
using AutoFixture.AutoMoq;
using System.Linq;

namespace EmployeeManagement.Domain.Unit.Tests
{
    public class EmployeeFixture : Fixture
    {
        public EmployeeFixture()
        {
            Customize(new AutoMoqCustomization());
            Behaviors.OfType<ThrowingRecursionBehavior>().ToList()
                .ForEach(b => Behaviors.Remove(b));
            Behaviors.Add(new OmitOnRecursionBehavior());
        }


    }
}
