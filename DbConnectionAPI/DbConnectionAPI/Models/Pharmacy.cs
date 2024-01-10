using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DbConnectionAPI.Models
{
    public class Pharmacy
    {
        public Pharmacy()
        {
            FeedBack = new List<FeedBack>();
            PharamaysProducts = new List<PharamaysProducts>();
        }

        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        [Required]
        [MaxLength(10)]
        public string PhoneNumber { get; set; }
        [Required]
        public double Latitude { get; set; }
        [Required]
        public double Longitude { get; set; }
        [MaxLength(150)]
        public string Description { get; set; }

        [DefaultValue(0.0)]
        public float Ratting { get; set; }//this is the average ratting of each pharamcy! (sum of all FeedBacks/number)
        public List<FeedBack> FeedBack { get; set; }
        public List<PharamaysProducts> PharamaysProducts { get; set; }

    }
}
