namespace Shoppje.Models
{
    public class OrderItemViewModel
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; } // Name of the product
        public string ProductDescription { get; set; }
        public string ProductImageUrl { get; set; } // URL to the product image
        public decimal ProductPrice { get; set; } // Price of the product
        public int Quantity { get; set; } // Quantity of the product in the order
    }
}
