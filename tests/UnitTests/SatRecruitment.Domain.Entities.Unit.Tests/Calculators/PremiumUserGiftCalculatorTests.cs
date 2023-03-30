using SatRecruitment.Domain.Entities.Calculators;
using SatRecruitment.Domain.Entities.Calculators.Interfaces;
using Xunit;

namespace SatRecruitment.Domain.Entities.UnitTests.Calculators
{
    public class PremiumUserGiftCalculatorTests
    {
        private readonly IUserGiftCalculator _calculator;

        public PremiumUserGiftCalculatorTests()
        {
            _calculator = new PremiumUserGiftCalculator();
        }

        [Fact]
        public void Should_Calculate_When_Money_Is_Higher_Than_100()
        {
            // Arrange  
            var money = new Random().Next(100, 1000);
            var expectedGift = money * 2;

            // Act  
            var gift = _calculator.Calculate(money);

            //Assert  
            Assert.Equal(expectedGift, gift);
        }

        [Fact]
        public void Should_Calculate_When_Money_Is_Less_Or_Equal_Than_100()
        {
            // Arrange  
            var money = new Random().Next(101);
            var expectedGift = 0;

            // Act  
            var gift = _calculator.Calculate(money);

            //Assert  
            Assert.Equal(expectedGift, gift);
        }
    }
}
