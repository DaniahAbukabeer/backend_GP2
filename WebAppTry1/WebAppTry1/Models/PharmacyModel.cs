using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
//using System.Device.Location.GeoCoordinate;
namespace WebAppTry1.Models
{
    public class PharmacyModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        [Required]
        [MaxLength(10)]
        public string PhoneNumber { get; set; }
        [Required]
        public TimeSpan workingHours { get; set; }
        //[Required]
        //public GeoCoordinate Location { get; set; }
        [Required]
        public double Latitude { get; set; }
        [Required]
        public double Longitude { get; set; }
        [MaxLength(150)]
        public string Description { get; set; }
        [Required]
        [MaxLength(5)]
        public float Ratting { get; set; }//this is the average ratting of each pharamcy! (sum of all comments/number)

        //public int NumofComments { get; set; }//auto increment this every time someone leaves a co

        public List<CommentModel> Comment { get; set; }//every pharmacy have a list of comments
        public List<ProdoctModel> Prodoct { get; set; }//a pharamcy can have one or more products

    }
}
