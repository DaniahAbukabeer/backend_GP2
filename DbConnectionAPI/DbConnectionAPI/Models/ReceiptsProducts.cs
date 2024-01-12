namespace DbConnectionAPI.Models
{
    public class ReceiptsProducts
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public ReceiptInfo? Receipt { get; set; }
        public Product? ProductInfo { get; set; }
        public int Quantity { get; set; }
    }
}
