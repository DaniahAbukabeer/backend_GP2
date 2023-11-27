using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace WebAppTry1.Models
{
    public class FeedBack
    {
        
        

        public bool Statues { get; set; }//true => active, fauls => removed
        public string Text { get; set; }// the content of the FeedBack

        public string Title { get; set; }

        [Required]//so we make the ratting required but the FeedBack is not,
        [MaxLength(5)]//so someone can leave a ratting but cant leave a FeedBack without ratting!
        public float Ratting { get; set; }//this is the indivisual ratting for every FeedBack,

        public int UserId { get; set; }
        public int PharmacyId { get; set; }

        public User Users { get; set; }
        public Pharmacy Pharmacy { get; set;}//every FeedBack is connected to one pharmacy only!
        
    }
}
