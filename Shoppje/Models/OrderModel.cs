namespace Shoppje.Models
{
    public class OrderModel
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public DateTime OrderDate { get; set; }
        public string OrderCode { get; set; } // Unique code for the order
        public string Status { get; set; } // e.g., Pending, Completed, Cancelled
    }
}
