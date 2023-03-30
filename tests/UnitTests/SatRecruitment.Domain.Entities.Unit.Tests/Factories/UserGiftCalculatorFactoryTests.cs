using SatRecruitment.Domain.Entities.Calculators;
using SatRecruitment.Domain.Entities.Factories;
using Xunit;

namespace SatRecruitment.Domain.Entities.UnitTests.Factories
{
    public class UserGiftCalculatorFactoryTests
    {
        [Fact]
        public void Should_GetUserGiftCalculator_Return_NormalUserGiftCalculator()
        {
            // Arrange  
            var userType = UserType.Normal;

            // Act  
            var userGiftCalculator = UserGiftCalculatorFactory.GetUserGiftCalculator(userType);

            //Assert  
            Assert.IsType<NormalUserGiftCalculator>(userGiftCalculator);
        }

        [Fact]
        public void Should_GetUserGiftCalculator_Return_SuperUserGiftCalculator()
        {
            // Arrange  
            var userType = UserType.SuperUser;

            // Act  
            var userGiftCalculator = UserGiftCalculatorFactory.GetUserGiftCalculator(userType);

            //Assert  
            Assert.IsType<SuperUserGiftCalculator>(userGiftCalculator);
        }

        [Fact]
        public void Should_GetUserGiftCalculator_Return_PremiumUserGiftCalculator()
        {
            // Arrange  
            var userType = UserType.Premium;

            // Act  
            var userGiftCalculator = UserGiftCalculatorFactory.GetUserGiftCalculator(userType);

            //Assert  
            Assert.IsType<PremiumUserGiftCalculator>(userGiftCalculator);
        }

        [Fact]
        public void Should_GetUserGiftCalculator_Throw_ArgumentOutOfRangeException()
        {
            // Arrange  
            var userType = (UserType)Int32.MaxValue;

            //Assert  
            Assert.Throws<ArgumentOutOfRangeException>(() => UserGiftCalculatorFactory.GetUserGiftCalculator(userType));
        }
    }
}
