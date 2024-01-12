namespace WebAppTry1.Models
{
    public class UserProduct
    {
        //public UserProduct()
        //{
        //   user = new User();   
        //   Product = new Product();
        //}

        public UserProduct()
        {
                IsFavorite= false;
        }
        public int UserId { get; set; }
        public int ProductId { get; set; }
        public bool IsFavorite { get; set; }
        public User? user { get; set; } = null!;
        public Product? Product { get; set; } = null!;
        public DateTime ViewedAt { get; set; }
    }
}
