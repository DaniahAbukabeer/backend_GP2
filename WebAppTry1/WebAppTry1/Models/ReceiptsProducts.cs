﻿namespace WebAppTry1.Models
{
    public class ReceiptsProducts
    {
        //public ReceiptsProducts()
        //{
        //    Receipt = new ReceiptInfo();
        //    ProductInfo = new Product();
        //}
        public int Id { get; set; }
        //public int ReceiptNumber { get; set; }
        public int ProductId { get; set; }

        public ReceiptInfo? Receipt { get; set; }
        public Product? ProductInfo { get; set; }
        public int Quantity { get; set; }
    }
}
