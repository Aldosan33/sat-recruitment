using SatRecruitment.Domain.Entities.Calculators.Interfaces;

namespace SatRecruitment.Domain.Entities.Calculators
{
    public class PremiumUserGiftCalculator : IUserGiftCalculator
    {
        public decimal Calculate(decimal money) => money > 100 ? money * 2 : 0;
    }
}
