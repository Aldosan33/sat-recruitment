using AutoMapper;
using SatRecruitment.Domain.Entities;
using SatRecruitment.Domain.Entities.Factories;
using SatRecruitment.Domain.Entities.Repositories;
using SatRecruitment.Domain.Models.Request;
using SatRecruitment.Domain.Models.Response;
using SatRecruitment.Domain.Models.Validations;
using SatRecruitment.Infrastructure.Services;

namespace SatRecruitment.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<ValidationMessage> AddUserAsync(UserForCreationDTO userForCreationDTO)
        {
            var user = _mapper.Map<User>(userForCreationDTO);

            var isDuplicated = await _userRepository.IsDuplicatedUserAsync(user);

            if(isDuplicated)
            {
                return new ValidationMessage(false, "User is Duplicated");
            }

            CalculateUserGift(user);

            await _userRepository.AddUserAsync(user);

            return new ValidationMessage(true, string.Empty);
        }

        public async Task<IEnumerable<UserForListDTO>> GetUsersAsync()
        {
            var users = await _userRepository.GetUsersAsync();
            return _mapper.Map<IEnumerable<UserForListDTO>>(users);
        }

        private static void CalculateUserGift(User user)
        {
            var giftCalculator = UserGiftCalculatorFactory.GetUserGiftCalculator(user.UserType);
            var gift = giftCalculator.Calculate(user.Money);

            user.Money += gift;
        }
    }
}
