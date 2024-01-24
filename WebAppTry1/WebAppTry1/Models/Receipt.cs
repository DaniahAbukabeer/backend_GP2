namespace WebAppTry1.Models
{
    public class Receipt
    {
        public Receipt()
        {
            Products = new List<Product>();
        }

        public int Id { get; set; } 
        public int PharmacistName { get; set; }
        public int RreceiptNum { get; set; }
        public int NumOfProducts { get; set; }
        public List<Product>? Products { get; set; }
        public double TotalPrice { get; set; }

    }
}
