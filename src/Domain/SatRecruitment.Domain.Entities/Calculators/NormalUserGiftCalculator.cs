using SatRecruitment.Domain.Entities.Calculators.Interfaces;

namespace SatRecruitment.Domain.Entities.Calculators
{
    public class NormalUserGiftCalculator : IUserGiftCalculator
    {
        public decimal Calculate(decimal money)
        {
            decimal percentage = 0;

            if (money > 100)
            {
                percentage = 0.12M;
            }
            else if (money > 10 && money < 100)
            {
                percentage = 0.8M;
            }

            return money * percentage;
        }
    }
}
