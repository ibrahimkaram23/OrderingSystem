using OrderingSystem.Core.Bases;
using OrderingSystem.Core.Features.Categories.Queries.Models;
using OrderingSystem.Core.Resources;
using OrderingSystem.Core.Wrappers;
using OrderingSystem.infrastructure.Data;
using OrderingSystem.Shared.DTOs.Stock.Category;
using MapsterMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;

namespace OrderingSystem.Core.Features.Categories.Queries.Handlers
{
    public class GetCategoriesCommandHandler : IRequestHandler<GetCategoriesQuery, Response<PaginatedResult<CategoryDTO>>>
    {
        private readonly APPDBContext _context;
        private readonly IMapper _mapper;
        private readonly IStringLocalizer<SharedResources> _stringLocalizer;
        public GetCategoriesCommandHandler(APPDBContext context, IMapper mapper, IStringLocalizer<SharedResources> stringLocalizer)
        {
            _context = context;
            _mapper = mapper;
            _stringLocalizer = stringLocalizer;
        }

        public async Task<Response<PaginatedResult<CategoryDTO>>> Handle(GetCategoriesQuery request, CancellationToken cancellationToken)
        {
            var query = _context.Categories.OrderByDescending(n => n.CreatedAt).AsQueryable();
            if (!string.IsNullOrEmpty(request.Search))
            {
                query = query.Where(c => c.Name.NameAr.Contains(request.Search) || c.Name.NameEn.Contains(request.Search));
            }
            if (request.IsActive.HasValue)
            {
                query = query.Where(c => c.IsActive == request.IsActive.Value);
            }
            var totalCount = await query.CountAsync(cancellationToken);
            var categories = await query.AsNoTracking()
                .Skip((request.PageNumber - 1) * request.PageSize)
                .Take(request.PageSize)
                .ToListAsync(cancellationToken);
            var pagedList = new PaginatedResult<CategoryDTO>
            {
                TotalCount = totalCount,
                CurrentPage = request.PageNumber,
                PageSize = request.PageSize,
                Data = _mapper.Map<List<CategoryDTO>>(categories),
                TotalPages = (int)Math.Ceiling((double)totalCount / request.PageSize)
            };
            return new Response<PaginatedResult<CategoryDTO>>(pagedList, _stringLocalizer[SharedResourcesKeys.Success]);
        }
    }
}
