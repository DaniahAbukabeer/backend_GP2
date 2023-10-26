using System.ComponentModel.DataAnnotations;

namespace WebAppTry1.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        //[Required]
        //[maxlength]
    }
}
