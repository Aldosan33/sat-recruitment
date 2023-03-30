using SatRecruitment.Domain.Models.Request;
using SatRecruitment.Domain.Models.Response;
using SatRecruitment.Domain.Models.Validations;

namespace SatRecruitment.Infrastructure.Services
{
    public interface IUserService
    {
        Task<IEnumerable<UserForListDTO>> GetUsersAsync();
        Task<ValidationMessage> AddUserAsync(UserForCreationDTO userForCreationDTO);
    }
}
