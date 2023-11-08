using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebAppTry1.Models
{
    public class UserModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(30)]
        public string UserName { get; set; }

        [Required]
        [MaxLength(30)]
        [PasswordPropertyText]
        public string Password { get; set; }
        [Required]
        [MaxLength(13)]
        [MinLength(13)]
        public string PhoneNumber { get; set; }

        public  double Latitude { get; set; }
        public double Longitude { get; set; }

        //public enum UserRole {get; set; }



    }
}
