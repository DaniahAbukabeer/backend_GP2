using System.ComponentModel.DataAnnotations;

namespace DbConnectionAPI.Models
{
    public class FeedBack
    {
        //public FeedBack()
        //{
        //    Users = new User();
        //    Pharmacy = new Pharmacy();
        //}

        public bool Statues { get; set; }
        public string  Text { get; set; }
        public string Title { get; set; }
        [Required]
        [MaxLength(5)]
        public double Ratting { get; set; }
        public int UserId { get; set; }
        public int PharmacyId { get; set; }
        public User? Users { get; set; }
        public Pharmacy? Pharmacy { get; set; }
    }
}
