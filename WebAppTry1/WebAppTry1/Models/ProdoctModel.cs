using System.ComponentModel.DataAnnotations;

namespace WebAppTry1.Models
{
    public class ProdoctModel
    {
        [Key]
        public int Id { get; set; } // code == number
        [MaxLength(60)]//the longes medication known is of 45 char's but give a margin for the future :)
        public string TName { get; set; }//Trade name
        [MaxLength(60)]
        public string SName { get; set; } //scientific name

        [MaxLength(50)]
        public string number { get; set; }

        [MaxLength(50)]
        public string Provider { get; set; } //who makes the product "company"
        [MaxLength(50)]
        public string LocalAgent { get; set; }//who gets and store the medication here 
        [MaxLength(30)]
        public string Country { get; set; }//where was it made
        public double PublicPrice  { get; set; }//price ppl buy at
        public double PulbicPriceWTax { get; set; }// price with tax
        [MaxLength(13)]
        [MinLength(13)]
        public int BarCode { get; set; }

        public int Quantity { get; set; }

        [MaxLength(7)]
        [MinLength(7)]
        public string ATCCODE { get; set; }//universal code to help categoires medications

        [MinLength(1)]
        public int Amount { get; set; }//the number of pills/tablets 
        public double PrivatePrice { get; set; }//price pharmacy buy at
        //[Range()] how to set up restrections on the date such it cannot be in the past
        public DateTime ExpireDate { get; set; }
        [MaxLength(150)]
        public string Discreption { get; set; }
        
        public double Discount { get; set; }

        public List<UserProductModel> UserProducts { get; set; }
        public List<PharmacyModel> Pharmacy { get; set;}//every product can be in one or more pharmacies!


    }
}
