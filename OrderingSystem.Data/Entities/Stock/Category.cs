
using OrderingSystem.Data.Commons;

namespace OrderingSystem.Data.Entities.Stock
{
    public class Category
    {
        public int Id { get; set; }
        public LocalizableEntity Name { get; set; } = new LocalizableEntity();
        public string Description { get; set; } = string.Empty;
        public bool IsActive { get; set; } = true;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        // Navigation properties
        public virtual ICollection<Product>? Products { get; set; } = new List<Product>();
    }
}
