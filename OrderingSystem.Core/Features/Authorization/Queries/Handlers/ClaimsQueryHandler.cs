using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Localization;
using OrderingSystem.Core.Bases;
using OrderingSystem.Core.Features.Authorization.Queries.Models;
using OrderingSystem.Core.Resources;
using OrderingSystem.Data.Entities.Identity;
using OrderingSystem.Data.Results;
using OrderingSystem.Service.Abstracts;

namespace OrderingSystem.Core.Features.Authorization.Queries.Handlers
{
    public class ClaimsQueryHandler : ResponseHandler,
                                    IRequestHandler<ManageUserClaimsQuery, Response<ManageUserClaimResult>>
    {



        #region Fileds
        private readonly UserManager<User> _userManager;
        private readonly IAuthorizationService _authorizationService;
        private readonly IStringLocalizer<SharedResources> _stringLocalizer;
        #endregion
        #region ctor
        public ClaimsQueryHandler(UserManager<User> userManager, IAuthorizationService authorizationService,IStringLocalizer<SharedResources> stringLocalizer):base(stringLocalizer)
        {
            _userManager = userManager;
            _authorizationService = authorizationService;
            _stringLocalizer = stringLocalizer;
        }
        #endregion
        #region functions
        public async Task<Response<ManageUserClaimResult>> Handle(ManageUserClaimsQuery request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByIdAsync(request.UserId.ToString());
            if (user == null) return NotFound<ManageUserClaimResult>(_stringLocalizer[SharedResourcesKeys.UserIsNotFound]);
            var result = await _authorizationService.ManageUserClaimsData(user);
            return Success(result);

        }
        #endregion

    }
}
