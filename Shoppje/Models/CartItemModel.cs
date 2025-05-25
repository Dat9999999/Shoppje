namespace Shoppje.Models
{
    public class CartItemModel
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string ImageUrl { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public decimal TotalPrice => Price * Quantity;

        public CartItemModel()
        {

        }
        public CartItemModel(int productId, string productName, string imageUrl, decimal price, int quantity)
        {
            ProductId = productId;
            ProductName = productName;
            ImageUrl = imageUrl;
            Price = price;
            Quantity = quantity;
        }
    }
}
