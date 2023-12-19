namespace WebAppTry1.Models.Interfaces
{
    public interface IProductReopsitory
    {
        Product GetProduct(int id);
        IEnumerable<Product> GetProducts();
        IQueryable<Product> GetAllProducts();
        Product addProduct(Product product);
        Product updateProduct(Product product);
        Product DeleteProduct(int id);
    }
}
