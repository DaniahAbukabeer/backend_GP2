namespace DbConnectionAPI.Models
{
    public class UserProduct
    {
        public int UserId { get; set; }
        public int ProductId { get; set; }
        public User user { get; set; }
        public Product Product { get; set; }
        public DateTime ViewedAt { get; set; }
    }
}
