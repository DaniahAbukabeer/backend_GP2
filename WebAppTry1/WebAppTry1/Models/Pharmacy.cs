using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
//using System.Device.Location.GeoCoordinate;
namespace WebAppTry1.Models
{
    public class Pharmacy
    {
        public Pharmacy()
        {
            //initailze the lists in the constroctor so its an empty list and not null by default
            FeedBack = new List<FeedBack>();
            //Product = new List<Product>();
            PharmaysProducts = new List<PharmaysProducts>();
            Open24Hours = false;
        }

        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        [Required]
        [MaxLength(10)]
        public string Phonenumber { get; set; }
        //[Required]
        //public TimeSpan workingHours { get; set; }//for testing removed!
        //[Required]
        //public GeoCoordinate Location { get; set; }

        public string Address { get; set; }

        [Required]
        public double Latitude { get; set; }
        [Required]
        public double Longitude { get; set; }
        [MaxLength(150)]
        public string Description { get; set; }
        //[Required(ErrorMessage ="")]
        //[MaxLength(5)]
        [DefaultValue(0.0)]
        public double Rating { get; set; }//this is the average Rating of each pharamcy! (sum of all FeedBacks/number)

        //public int NumofFeedBacks { get; set; }//auto increment this every time someone leaves a co
        public DateTime? OpeningTime { get; set; }
        public DateTime? ClosingTime { get; set; }

        public bool Open24Hours { get; set; }

        public List<FeedBack>? FeedBack { get; set; }//every pharmacy have a list of FeedBacks
        //public List<Product> Product { get; set; }//a pharamcy can have one or more products
        //public List<PharmaysProducts> PharmaysProducts { get;set; }
        public List<PharmaysProducts>? PharmaysProducts { get;set; }
    }
}
