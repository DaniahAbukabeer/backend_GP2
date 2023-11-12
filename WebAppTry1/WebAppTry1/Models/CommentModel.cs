using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace WebAppTry1.Models
{
    public class CommentModel
    {
        [Key]
        public int Id { get; set; }

        public bool Statues { get; set; }//true => active, fauls => removed
        public string Text { get; set; }// the content of the comment

        public string Title { get; set; }

        [Required]//so we make the ratting required but the comment is not,
        [MaxLength(5)]//so someone can leave a ratting but cant leave a comment without ratting!
        public float Ratting { get; set; }//this is the indivisual ratting for every comment,

        public int UserId { get; set; }
        public int PharmacyId { get; set; }

        public UserModel Users { get; set; }
        public PharmacyModel Pharmacy { get; set;}//every comment is connected to one pharmacy only!
        
    }
}
