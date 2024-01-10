namespace DbConnectionAPI.Models
{
    public class PharamaysProducts
    {
        public double? PublicPrice { get; set; }
        public double? Quantity { get; set; }
        public int? Amount { get; set; }
        public double? PrivatePrice { get; set; }
        public int PharmacyId { get; set; }
        public Pharmacy Pharmacy { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }

    }
}
