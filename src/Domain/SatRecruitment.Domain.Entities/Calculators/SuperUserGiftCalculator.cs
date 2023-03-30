using SatRecruitment.Domain.Entities.Calculators.Interfaces;

namespace SatRecruitment.Domain.Entities.Calculators
{
    public class SuperUserGiftCalculator : IUserGiftCalculator
    {
        public decimal Calculate(decimal money) => money > 100 ? money * 0.20M : 0;
    }
}
