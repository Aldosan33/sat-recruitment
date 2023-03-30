using AutoMapper;
using SatRecruitment.Domain.Entities;
using SatRecruitment.Domain.Models.Request;
using SatRecruitment.Domain.Models.Response;

namespace SatRecruitment.Application.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            #region Entity-Model

            CreateMap<User, UserForListDTO>()
                .ForMember(dest => dest.UserType,
                           opt => opt.MapFrom(src => src.UserType.ToString()));

            #endregion

            #region Model-Entity

            CreateMap<UserForCreationDTO, User>();
            CreateMap<UserTypeForCreationDTO, UserType>();

            #endregion
        }
    }
}
