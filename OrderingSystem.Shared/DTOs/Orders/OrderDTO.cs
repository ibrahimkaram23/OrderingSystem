
namespace OrderingSystem.Shared.DTOs.Orders
{
    public class OrderDTO
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public string CustomerName { get; set; } = string.Empty;
        public string CustomerEmail { get; set; } = string.Empty;
        public string CustomerPhone { get; set; } = string.Empty;
        public DateTime OrderDate { get; set; } = DateTime.UtcNow;
        public int StatusId { get; set; }
        public string StatusName { get; set; } = string.Empty;
        public DateTime StatusUpdateDate { get; set; } = DateTime.UtcNow;
        public double TotalAmount => OrderItems?.Sum(item => item.TotalPrice) ?? 0;
        public List<OrderItemDTO>? OrderItems { get; set; } = new List<OrderItemDTO>();
    }
    public class OrderItemDTO
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public double Price { get; set; }
        public double TotalPrice => Price * Quantity;
        public int Quantity { get; set; }
    }
}
