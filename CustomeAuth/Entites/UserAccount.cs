using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace CustomeAuth.Entites
{
    [Index(nameof(Email), IsUnique = true )]
    [Index(nameof(Password),IsUnique = true )]
    public class UserAccount
    {
        [Key] 
        public int Id { get; set; }
        
        [Required(ErrorMessage ="this informtion is requried") ]
        public string FirstName { get; set; }
        
        [Required(ErrorMessage = "this informtion is requried")]

        public string LastName { get; set; }

        [Required(ErrorMessage = "this informtion is requried")]
        public string Password { get; set; }

        [Required(ErrorMessage = "this informtion is requried")]

        public string Email { get; set; }
        
        [Required(ErrorMessage = "this informtion is requried")]

        public string UserName { get; set; }




    }
}
