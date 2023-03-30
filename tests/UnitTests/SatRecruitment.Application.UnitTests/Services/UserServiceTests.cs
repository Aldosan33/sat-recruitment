using AutoMapper;
using Moq;
using SatRecruitment.Application.Profiles;
using SatRecruitment.Application.Services;
using SatRecruitment.Domain.Entities;
using SatRecruitment.Domain.Entities.Repositories;
using SatRecruitment.Domain.Models.Request;
using SatRecruitment.Infrastructure.Services;
using Xunit;

namespace SatRecruitment.Application.UnitTests.Services
{
    public class UserServiceTests
    {
        private readonly Mock<IUserRepository> _userRepository;
        private readonly IMapper _mapper;
        private IUserService _userService;

        public UserServiceTests()
        {
            _userRepository = new Mock<IUserRepository>();

            var config = new MapperConfiguration(cfg => cfg.AddProfile<UserProfile>());
            _mapper = config.CreateMapper();

            _userService = new UserService(_userRepository.Object, _mapper);
        }

        [Fact]
        public async Task Should_AddUserAsync_Return_Validation_Message_When_User_Is_Duplicated()
        {
            // Arrange  
            _userRepository.Setup(x => x.IsDuplicatedUserAsync(It.IsAny<User>())).Returns(Task.FromResult(true));

            // Act  
            var validationMessage = await _userService.AddUserAsync(UserForCreationDTO);

            //Assert  
            Assert.False(validationMessage.IsSuccess);
            Assert.Equal("User is Duplicated", validationMessage.Message);
        }

        [Fact]
        public async Task Should_AddUserAsync_Return_Success()
        {
            // Arrange  
            _userRepository.Setup(x => x.IsDuplicatedUserAsync(It.IsAny<User>())).Returns(Task.FromResult(false));

            // Act  
            var validationMessage = await _userService.AddUserAsync(UserForCreationDTO);

            //Assert  
            Assert.True(validationMessage.IsSuccess);
            Assert.Empty(validationMessage.Message);
        }

        [Fact]
        public async Task Should_GetUsersAsync_Return_Users()
        {
            // Arrange  
            _userRepository.Setup(x => x.GetUsersAsync()).Returns(Task.FromResult(Users));

            // Act  
            var users = await _userService.GetUsersAsync();

            //Assert  
            Assert.NotNull(users);
            Assert.Equal(Users.Count(), users.Count());
        }

        private UserForCreationDTO UserForCreationDTO { get; set; } = new UserForCreationDTO
        {
            Name = "Test Name",
            Email = "test@gmail.com",
            Address = "Test Address",
            Phone = "123456789",
            UserType = 1,
            Money = 100
        };

        private IEnumerable<User> Users { get; set; } = new List<User>
        {
            new User
            {
                Name = "Test Name #1",
                Email = "test1@gmail.com",
                Address = "Test Address #1",
                Phone = "123456789",
                UserType = UserType.Normal,
                Money = 100
            },
            new User
            {
                Name = "Test Name #2",
                Email = "test2@gmail.com",
                Address = "Test Address #2",
                Phone = "987654321",
                UserType = UserType.SuperUser,
                Money = 200
            }
        };
    }
}
