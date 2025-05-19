﻿using OrderingSystem.Data.Entities.Stock;

namespace OrderingSystem.Data.Entities.Orders
{
    public class OrderItem
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        public double TotalPrice => Price * Quantity;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
        // Navigation properties
        public virtual Order? Order { get; set; }
        public virtual Product? Product { get; set; }

    }
}
