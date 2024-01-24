using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebAppTry1.Models
{
    public class User
    {
        public User()
        {
            FeedBacks = new List<FeedBack>();
            UserProducts = new List<UserProduct>();
        }


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
        public string PhoneNumber { get; set; }

        //public  double Latitude { get; set; }
        //public double Longitude { get; set; }

        public List<FeedBack>? FeedBacks { get; set; }

        public List<UserProduct>? UserProducts { get; } = new(); 

        
        //public enum UserRole {get; set; }



    }
}
