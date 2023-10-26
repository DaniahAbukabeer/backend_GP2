using System.ComponentModel.DataAnnotations;
//using System.Device.Location.GeoCoordinate;
namespace WebAppTry1.Models
{
    public class PharmacyModel
    {
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
        [MaxLength(150)]
        public string Description { get; set; }
        [Required]
        [MaxLength(5)]
        public int Ratting { get; set; }

    }
}
