using SatRecruitment.Domain.Entities.Calculators;
using SatRecruitment.Domain.Entities.Calculators.Interfaces;

namespace SatRecruitment.Domain.Entities.Factories
{
    public class UserGiftCalculatorFactory
    {
        public static IUserGiftCalculator GetUserGiftCalculator(UserType userType)
        {
            return userType switch
            {
                UserType.Normal => new NormalUserGiftCalculator(),
                UserType.SuperUser => new SuperUserGiftCalculator(),
                UserType.Premium => new PremiumUserGiftCalculator(),
                _ => throw new ArgumentOutOfRangeException("User Gift Calculator cannot be created"),
            };
        }
    }
}
