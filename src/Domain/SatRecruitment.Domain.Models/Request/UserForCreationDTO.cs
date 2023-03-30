using System.ComponentModel.DataAnnotations;

namespace SatRecruitment.Domain.Models.Request
{
    public class UserForCreationDTO
    {
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Address is required")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Phone is required")]
        [Phone]
        public string Phone { get; set; }

        [Required(ErrorMessage = "UserType is required")]
        [EnumDataType(typeof(UserTypeForCreationDTO))]
        public int UserType { get; set; }

        [Required(ErrorMessage = "Money is required")]
        public decimal Money { get; set; }
    }
}
