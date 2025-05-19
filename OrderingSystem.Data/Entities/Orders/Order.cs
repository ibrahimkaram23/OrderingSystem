
using OrderingSystem.Data.Entities.Identity;

namespace OrderingSystem.Data.Entities.Orders
{
    public class Order
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public DateTime OrderDate { get; set; } = DateTime.UtcNow;
        public int StatusId { get; set; }
        public DateTime StatusUpdateDate { get; set; } = DateTime.UtcNow;
        public double TotalAmount => OrderItems?.Sum(item => item.TotalPrice) ?? 0;

        // Navigation properties
        public virtual User? Customer { get; set; }
        public virtual StatusLookup? Status { get; set; } = new StatusLookup();
        public virtual ICollection<OrderItem>? OrderItems { get; set; } = new List<OrderItem>();
    }
}
