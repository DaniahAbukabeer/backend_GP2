namespace DbConnectionAPI.Models
{
    public class ReceiptInfo
    {
        //public ReceiptInfo()
        //{
        //    ReceiptsProducts = new List<ReceiptsProducts>();
        //}
        public int Id { get; set; }
        public DateTime date { get; set; }
        public string PharmacistName { get; set; }
        public double TotalPrice { get; set; }
        public List<ReceiptsProducts>? ReceiptsProducts { get; set;}
    }
}
