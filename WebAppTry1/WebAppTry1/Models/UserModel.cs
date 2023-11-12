using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebAppTry1.Models
{
    public class UserModel
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage ="user name is required")]
        [MaxLength(30)]
        public string UserName { get; set; }

        [Required(ErrorMessage ="Password is required")]
        [MaxLength(30)]
        [PasswordPropertyText]
        public string Password { get; set; }
        [Required(ErrorMessage ="Phone number is required")]
        [MaxLength(13)]
        [MinLength(13)]
        public string PhoneNumber { get; set; }

        public  double Latitude { get; set; }
        public double Longitude { get; set; }

        //public enum UserRole {get; set; }



    }
}
