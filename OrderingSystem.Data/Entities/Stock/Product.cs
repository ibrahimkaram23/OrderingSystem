
using OrderingSystem.Data.Commons;

namespace OrderingSystem.Data.Entities.Stock
{
    public class Product
    {
        public int Id { get; set; }
        public LocalizableEntity Name { get; set; } = new LocalizableEntity();
        public string Description { get; set; } = string.Empty;
        public string MediaLink { get; set; } = string.Empty;
        public double SystemPrice { get; set; }
        public double VendorPrice { get; set; }
        public double FixedEarnPrice { get; set; }
        public int StockQuantity { get; set; }
        public int ProductType { get; set; } = 1; // 1 For public, 2 For Private
        public bool IsActive { get; set; } = true;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
        public int SizeId { get; set; }
        public int ColorId { get; set; }
        // Navigation properties
        public virtual Category? Category { get; set; }
        public virtual Color? Color { get; set; }
        public virtual Size? Size { get; set; }
        public virtual ICollection<ProductPhoto> ProductPhotos { get; set; } = new List<ProductPhoto>();
    }
}
