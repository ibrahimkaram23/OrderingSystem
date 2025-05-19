
namespace OrderingSystem.Data.Entities.Stock
{
    public class ProductPhoto
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string Description { get; set; } = string.Empty;
        public string MediaUrl { get; set; } = string.Empty;
        public string MediaTitle { get; set; } = string.Empty;
        public virtual Product Product { get; set; } = new Product();
    }
}
