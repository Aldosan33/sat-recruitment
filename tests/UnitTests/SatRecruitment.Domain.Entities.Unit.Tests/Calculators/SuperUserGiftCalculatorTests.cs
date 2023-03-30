using SatRecruitment.Domain.Entities.Calculators;
using SatRecruitment.Domain.Entities.Calculators.Interfaces;
using Xunit;

namespace SatRecruitment.Domain.Entities.UnitTests.Calculators
{
    public class SuperUserGiftCalculatorTests
    {
        private readonly IUserGiftCalculator _calculator;

        public SuperUserGiftCalculatorTests()
        {
            _calculator = new SuperUserGiftCalculator();
        }

        [Fact]
        public void Should_Calculate_When_Money_Is_Higher_Than_100()
        {
            // Arrange  
            var percentage = 0.20M;
            var money = new Random().Next(100, 1000);
            var expectedGift = money * percentage;

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
