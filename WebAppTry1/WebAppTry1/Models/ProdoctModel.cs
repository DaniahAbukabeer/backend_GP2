using System.ComponentModel.DataAnnotations;

namespace WebAppTry1.Models
{
    public class ProdoctModel
    {
        public int Id { get; set; } // code == number
        [MaxLength(60)]//the longes medication known is of 45 char's but give a margin for the future :)
        public string PName { get; set; }//public name
        [MaxLength(60)]
        public string SName { get; set; } //scientific name
        [MaxLength(50)]
        public string Provider { get; set; } //who makes the product "company"
        [MaxLength(50)]
        public string LocalAgent { get; set; }//who gets and store the medication here 
        [MaxLength(30)]
        public string Country { get; set; }//where was it made
        public double PublicPrice  { get; set; }//price ppl buy at
        [MaxLength(13)]
        [MinLength(13)]
        public int BarCode { get; set; }

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
        
        public double Discaount { get; set; }

    }
}
