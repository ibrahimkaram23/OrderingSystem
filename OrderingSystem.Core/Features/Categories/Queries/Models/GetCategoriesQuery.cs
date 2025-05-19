using OrderingSystem.Core.Bases;
using OrderingSystem.Core.Wrappers;
using OrderingSystem.Shared.DTOs.Stock.Category;
using MediatR;

namespace OrderingSystem.Core.Features.Categories.Queries.Models
{
    public class GetCategoriesQuery : IRequest<Response<PaginatedResult<CategoryDTO>>>
    {
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
        public string? Search { get; set; } = string.Empty;
        public bool? IsActive { get; set; } = null;
    }
}
