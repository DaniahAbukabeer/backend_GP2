namespace WebAppTry1.Models
{
    public class ProdoctModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Provider { get; set; }
        public string TradeName { get; set; }
        public double PublicPrice  { get; set; }

        public double PrivatePrice { get; set; }
        public DateTime ExpireDate { get; set; }
        public string Discreption { get; set; }
        public double Discaount { get; set; }

    }
}
