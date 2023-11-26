using WebAppTry1.Models.Interfaces;

namespace WebAppTry1.Models.sqlRepo
{
    public class ProductSqlReopsitory : IProductReopsitory
    {
        private readonly ApplicationDbContext context;

        public ProductSqlReopsitory(ApplicationDbContext context)
        {
            this.context = context;
        }
        public Product addProduct(Product product)
        {
            context.Products.Add(product);
            context.SaveChanges();
            return product;
        }

    
        public Product DeleteProduct(int id)
        {
            var product = context.Products.Find(id);
            if (product != null) { 
                context.Products.Remove(product);
                context.SaveChanges();
            }
            return product;
        }

        public Product GetProduct(int id)
        {
            return context.Products.Find(id);
        }

        public IEnumerable<Product> GetProducts()
        {
            return context.Products;
        }

        public Product updateProduct(Product product)
        {
            var modifiedProduct = context.Products.Attach(product);
            modifiedProduct.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return product;
        }


    }
}
