using SatRecruitment.Domain.Entities.Calculators;
using SatRecruitment.Domain.Entities.Calculators.Interfaces;
using Xunit;

namespace SatRecruitment.Domain.Entities.UnitTests.Calculators
{
    public class NormalUserGiftCalculatorTests
    {
        private readonly IUserGiftCalculator _calculator;

        public NormalUserGiftCalculatorTests()
        {
            _calculator = new NormalUserGiftCalculator();
        }

        [Fact]
        public void Should_Calculate_When_Money_Is_Higher_Than_100()
        {
            // Arrange  
            var percentage = 0.12M;
            var money = new Random().Next(100, 1000);
            var expectedGift = money * percentage;

            // Act  
            var gift = _calculator.Calculate(money);

            //Assert  
            Assert.Equal(expectedGift, gift);
        }

        [Fact]
        public void Should_Calculate_When_Money_Is_Between_10_And_100()
        {
            // Arrange  
            var percentage = 0.8M;
            var money = new Random().Next(11, 100);
            var expectedGift = money * percentage;

            // Act  
            var gift = _calculator.Calculate(money);

            //Assert  
            Assert.Equal(expectedGift, gift);
        }

        [Fact]
        public void Should_Calculate_When_Money_Is_Less_Than_10()
        {
            // Arrange  
            var money = new Random().Next(10);
            var expectedGift = 0;

            // Act  
            var gift = _calculator.Calculate(money);

            //Assert  
            Assert.Equal(expectedGift, gift);
        }
    }
}
