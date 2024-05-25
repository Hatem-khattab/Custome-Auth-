using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CustomeAuth.Models
{
    public class LoginViewModel
    {

        [Required(ErrorMessage = "this informtion is requried")]
        [MaxLength(20,ErrorMessage ="max 20 Characters is Allowed")]
        [DisplayName("User Name Or Email ")]
        public string UserNameOrEmail { get; set; }


        [Required(ErrorMessage = "this informtion is requried")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
