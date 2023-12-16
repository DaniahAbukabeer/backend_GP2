using System.ComponentModel.DataAnnotations;

namespace WebAppTry1.Models
{
    public class Product
    {
        public Product()
        {
            UserProducts = new List<UserProduct>();
            //Pharmacy = new List<Pharmacy>();
            //PharmaysProducts = new List<PharmaysProducts>();
        }

        [Key]

        public int Id { get; set; } // code == number
        [MaxLength(60)]//the longes medication known is of 45 char's but give a margin for the future :)
        public string TName { get; set; }//Trade name
         
        [MaxLength(60)]
        public string SName { get; set; } //scientific name
        public int UserId { get; set; }
       // public int PharmacyId { get; set; }//to be forigen key for the pharmacy
        public List<UserProduct> UserProducts { get; } = new();
       // public List<Pharmacy> Pharmacy { get; set;}//every product can be in one or more pharmacies!


        [MaxLength(50)]
        public string Provider { get; set; } //who makes the product "company"
        [MaxLength(30)]
        public string Country { get; set; }//where was it made
        //public double PublicPrice  { get; set; }//price ppl buy at

        public double Dosage { get; set; }


        [MaxLength(7)]
        [MinLength(6)]
        public string ATCCODE { get; set; }//universal code to help categoires medications

        public List<PharmaysProducts> PharmaysProducts { get; set; }
        //[MaxLength(50)]
        //[MaxLength(50)]
        //public string number { get; set; }

        //public string LocalAgent { get; set; }//who gets and store the medication here 
        //public double PulbicPriceWTax { get; set; }// price with tax
        //[MaxLength(13)]
        //[MinLength(12)]
        //public string BarCode { get; set; }

        //public int Quantity { get; set; }

        //[MinLength(1)]
        //public int Amount { get; set; }//the number of pills/tablets 
        //public double PrivatePrice { get; set; }//price pharmacy buy at
        //[Range()] how to set up restrections on the date such it cannot be in the past
        //public DateTime ExpireDate { get; set; }//for debugging remove this

        //public double Discount { get; set; }

    }
}
