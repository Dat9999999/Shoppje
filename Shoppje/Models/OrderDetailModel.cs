namespace Shoppje.Models
{
    public class OrderDetailModel
    {
        public int Id { get; set; }
        public string OrderCode{ get; set; } // Foreign key to OrderModel
        public int ProductId { get; set; } // Foreign key to ProductModel
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }
}
