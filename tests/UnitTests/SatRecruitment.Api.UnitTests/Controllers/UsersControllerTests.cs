using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using SatRecruitment.Api.Controllers;
using SatRecruitment.Domain.Entities;
using SatRecruitment.Domain.Models.Request;
using SatRecruitment.Domain.Models.Response;
using SatRecruitment.Domain.Models.Validations;
using SatRecruitment.Infrastructure.Services;
using Xunit;

namespace SatRecruitment.Api.UnitTests.Controllers
{
    public class UsersControllerTests
    {
        private readonly Mock<IUserService> _userService;
        private readonly UsersController _userController;

        public UsersControllerTests()
        {
            _userService = new Mock<IUserService>();
            _userController = new UsersController(_userService.Object);
        }

        [Fact]
        public async Task Should_GetUsers_Return_Ok_And_Users()
        {
            // Arrange  
            _userService.Setup(x => x.GetUsersAsync()).Returns(Task.FromResult(UsersForList));

            // Act  
            var response = await _userController.GetUsers();

            //Assert  
            var actionResult = Assert.IsType<OkObjectResult>(response);
            var actionValue = actionResult.Value as IEnumerable<UserForListDTO>;
            
            Assert.True(actionValue.Count() > 0);
        }

        [Fact]
        public async Task Should_CreateUser_Return_BadRequest_And_Validation_Message()
        {
            // Arrange
            var validationMessage = new ValidationMessage(false, "User is Duplicated");

            _userService.Setup(x => x.AddUserAsync(It.IsAny<UserForCreationDTO>())).Returns(Task.FromResult(validationMessage));

            // Act  
            var response = await _userController.CreateUser(UserForCreationDTO);

            //Assert  
            var actionResult = Assert.IsType<BadRequestObjectResult>(response);
            Assert.Equal(validationMessage.Message, actionResult.Value);
        }

        [Fact]
        public async Task Should_CreateUser_Return_Created()
        {
            // Arrange
            var validationMessage = new ValidationMessage(true, null);

            _userService.Setup(x => x.AddUserAsync(It.IsAny<UserForCreationDTO>())).Returns(Task.FromResult(validationMessage));

            // Act  
            var response = await _userController.CreateUser(UserForCreationDTO);

            //Assert  
            var statusCodeResult = Assert.IsType<StatusCodeResult>(response);
            Assert.Equal(StatusCodes.Status201Created, statusCodeResult.StatusCode);
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

        private IEnumerable<UserForListDTO> UsersForList { get; set; } = new List<UserForListDTO>
        {
            new UserForListDTO
            {
                Name = "Test Name #1",
                Email = "test1@gmail.com",
                Address = "Test Address #1",
                Phone = "123456789",
                UserType = UserType.Normal.ToString(),
                Money = 100
            },
            new UserForListDTO
            {
                Name = "Test Name #2",
                Email = "test2@gmail.com",
                Address = "Test Address #2",
                Phone = "987654321",
                UserType = UserType.SuperUser.ToString(),
                Money = 200
            }
        };
    }
}
