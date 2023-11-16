namespace WebAppTry1.Models
{
    public class UserProduct
    {
        public int UserId { get; set; }
        public int ProductId { get; set; }
        public User user { get; set; } = null!;
        public Product Product { get; set; } = null!;
        public DateTime ViewedAt { get; set; }
    }
}
