namespace WebAppTry1.Models.Interfaces
{
    public interface IReceiptReopsitory
    {
        Receipt GetReceipt(int id);
        IEnumerable<Receipt> GetReceipts();
        Receipt AddReceipt(Receipt receipt);
        Receipt DeleteReceipt(int id);
        Receipt UpdateReceipt(Receipt receipt);
    }
}
