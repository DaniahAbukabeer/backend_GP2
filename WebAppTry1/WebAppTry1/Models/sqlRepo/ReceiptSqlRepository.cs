using WebAppTry1.Models.Interfaces;

namespace WebAppTry1.Models.sqlRepo
{
    public class ReceiptSqlRepository : IReceiptReopsitory
    {
        private readonly ApplicationDbContext context;

        public ReceiptSqlRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public Receipt AddReceipt(Receipt receipt)
        {
            //context.Re
            throw new NotImplementedException();
        }

        public Receipt DeleteReceipt(int id)
        {
            throw new NotImplementedException();
        }

        public Receipt GetReceipt(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Receipt> GetReceipts()
        {
            throw new NotImplementedException();
        }

        public Receipt UpdateReceipt(Receipt receipt)
        {
            throw new NotImplementedException();
        }
    }
}
