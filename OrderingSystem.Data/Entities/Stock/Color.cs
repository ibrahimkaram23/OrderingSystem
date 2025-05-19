
using OrderingSystem.Data.Commons;

namespace OrderingSystem.Data.Entities.Stock
{
    public class Color
    {
        public int Id { get; set; }
        public LocalizableEntity Name { get; set; } = new LocalizableEntity();
        public virtual ICollection<Product>? Products { get; set; } = new List<Product>();

    }
}
