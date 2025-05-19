using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;
using OrderingSystem.Core.Bases;
using OrderingSystem.Core.Features.ApplicationUser.Queries.Results;
using OrderingSystem.Core.Features.Customers.Queries.Models;
using OrderingSystem.Core.Resources;
using OrderingSystem.Data.Entities.Identity;

namespace OrderingSystem.Core.Features.Customers.Queries.Handlers
{
    public class GetCustomerByIdQueryHandler : ResponseHandler, IRequestHandler<GetCustomerByIdQuery, Response<GetUserByIdResponse>>
    {
        private readonly UserManager<User> _userManager;
        private readonly IStringLocalizer<SharedResources> _stringLocalizer;
        private readonly IMapper _mapper;

        public GetCustomerByIdQueryHandler(UserManager<User> userManager, IStringLocalizer<SharedResources> stringLocalizer, IMapper mapper) : base(stringLocalizer)
        {
            _userManager = userManager;
            _stringLocalizer = stringLocalizer;
            _mapper = mapper;
        }

        public async Task<Response<GetUserByIdResponse>> Handle(GetCustomerByIdQuery request, CancellationToken cancellationToken)
        {
            var customer = await _userManager.Users.FirstOrDefaultAsync(u => u.Id == request.Id);
            if (customer == null || !(await _userManager.IsInRoleAsync(customer!, "Customer")))
            {
                return NotFound<GetUserByIdResponse>(_stringLocalizer[SharedResourcesKeys.NotFound]);
            }
            return Success(_mapper.Map<GetUserByIdResponse>(customer!));
        }
    }
}
