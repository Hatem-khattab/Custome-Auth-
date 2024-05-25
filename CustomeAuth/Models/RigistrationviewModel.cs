using System.ComponentModel.DataAnnotations;

namespace CustomeAuth.Models
{
    public class RigistrationviewModel
    {
        [Key]
        public int Id { get; set; }


        [Required(ErrorMessage = "this informtion is requried")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "this informtion is requried")]
        public string LastName { get; set; }


        [Required(ErrorMessage = "this informtion is requried")]      
        public string Password { get; set; }


        [Required(ErrorMessage = "this informtion is requried")]
        [Compare("Password",ErrorMessage ="Please Confirm Your Password")]        
        public string ConfirsPassword { get; set; }
       
        [Required(ErrorMessage = "this informtion is requried")]
        public string Email { get; set; }

       
        [Required(ErrorMessage = "this informtion is requried")]
        public string UserName { get; set; }
    }
}
