using OrderingSystem.Core.Bases;
using OrderingSystem.Core.Features.Categories.Commands.Models;
using OrderingSystem.Core.Resources;
using OrderingSystem.infrastructure.Data;
using MediatR;
using Microsoft.Extensions.Localization;

namespace OrderingSystem.Core.Features.Categories.Commands.Handlers
{
    public class AddCategoryCommandHandler : ResponseHandler, IRequestHandler<AddCategoryCommand, Response<string>>
    {
        private readonly IStringLocalizer<SharedResources> _sharedLocalizer;
        private readonly APPDBContext _dbContext;

        public AddCategoryCommandHandler(IStringLocalizer<SharedResources> sharedLocalizer, APPDBContext dbContext) : base(sharedLocalizer)
        {
            _sharedLocalizer = sharedLocalizer;
            _dbContext = dbContext;
        }


        public async Task<Response<string>> Handle(AddCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = new Data.Entities.Stock.Category
            {
                Name = request.Name,
                Description = request.Description,
                IsActive = true,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };
           
            await _dbContext.Categories.AddAsync(category, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return Success<string>(_sharedLocalizer[SharedResourcesKeys.Success]);
        }
    }
}
