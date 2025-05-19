
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Localization;
using OrderingSystem.Core.Bases;
using OrderingSystem.Core.Features.ApplicationUser.Queries.Results;
using OrderingSystem.Core.Features.Customers.Queries.Models;
using OrderingSystem.Core.Resources;
using OrderingSystem.Core.Wrappers;
using OrderingSystem.Data.Entities.Identity;

namespace OrderingSystem.Core.Features.Customers.Queries.Handlers
{
    public class GetAllCustomersQueryHandler : ResponseHandler, IRequestHandler<GetAllCustomersQuery, Response<PaginatedResult<GetUserByIdResponse>>>
    {
        private readonly IStringLocalizer<SharedResources> _stringLocalizer;
        private readonly UserManager<User> _userManager;
        private readonly IMapper _mapper;

        public GetAllCustomersQueryHandler(IStringLocalizer<SharedResources> stringLocalizer, UserManager<User> userManager, IMapper mapper) : base(stringLocalizer)
        {
            _stringLocalizer = stringLocalizer;
            _userManager = userManager;
            _mapper = mapper;
        }

        public async Task<Response<PaginatedResult<GetUserByIdResponse>>> Handle(GetAllCustomersQuery request, CancellationToken cancellationToken)
        {
            var customers = _userManager.Users.AsQueryable();

            if (!string.IsNullOrEmpty(request.Search))
            {
                customers = customers.Where(c => c.UserName!.Contains(request.Search) || c.Email!.Contains(request.Search) || c.PhoneNumber!.Contains(request.Search));
            }
            var paginatedList = _mapper.Map<PaginatedResult<GetUserByIdResponse>>(await customers.ToPaginatedListAsync(request.PageNumber, request.PageSize));
            return Success(paginatedList);
        }
    }
}
