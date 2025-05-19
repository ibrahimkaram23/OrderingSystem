
using OrderingSystem.Data.Entities.Stock;
using OrderingSystem.Shared.DTOs.Stock.Category;
using Mapster;

namespace OrderingSystem.Core.Features.Categories.Mapping
{
    public class CategoriesMapper : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<Category, CategoryDTO>().Map(d => d.Name , s => s.Name.GetLocalized());
        }
    }
}
