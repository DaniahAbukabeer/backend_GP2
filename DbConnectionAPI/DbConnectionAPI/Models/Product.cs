using System.ComponentModel.DataAnnotations;

namespace DbConnectionAPI.Models
{
    public class Product
    {
        //public Product()
        //{
        //    UserProducts = new List<UserProduct>();
        //    PharmacyProducts = new List<PharamaysProducts>();
        //}
        
        public int Id { get; set; }
        [MaxLength(60)]
        public string TName { get; set; }
        [MaxLength(60)]
        public string  SName { get; set; }
        public int UserId { get; set; }
        public List<UserProduct> UserProducts { get; set; } = new();

        [MaxLength(50)]
        public string Provider { get; set; }
        [MaxLength(30)]
        public string Country { get; set; }
        public double Dosage { get; set; }
        [MaxLength(7)]
        public string ATCCODE { get; set; }
        public string Categorie { get; set; }
        public List<PharamaysProducts>? PharmacyProducts { get; set; }



    }
}
