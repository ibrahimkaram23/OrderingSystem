using FluentValidation;
using Microsoft.Extensions.Localization;
using OrderingSystem.Core.Features.Authorization.Commands.Models;
using OrderingSystem.Core.Resources;
using OrderingSystem.Service.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderingSystem.Core.Features.Authorization.Commands.Validators
{
    public class AddRoleValidator:AbstractValidator<AddRoleCommand>
    {
       
        #region fields
        private readonly IStringLocalizer<SharedResources> _localizer;
        private readonly IAuthorizationService _authorizationService;
        #endregion
        #region ctor
        public AddRoleValidator(IAuthorizationService authorizationService,IStringLocalizer<SharedResources> localizer)
        {
            _authorizationService = authorizationService;
            _localizer = localizer;
            ApplyValidationRules();
            ApplyCustomValidationRules();

        }
        #endregion
        #region function
        public void ApplyValidationRules()
        {

            RuleFor(x => x.RoleName)
               .NotEmpty().WithMessage(_localizer[SharedResourcesKeys.NotEmpty])
               .NotNull().WithMessage(_localizer[SharedResourcesKeys.Required]);
               
        }

        public void ApplyCustomValidationRules()
        {
            RuleFor(x => x.RoleName)
                .MustAsync(async (Key, CancellationToken) => !await _authorizationService.IsRoleExistByName(Key))
               .WithMessage(_localizer[SharedResourcesKeys.IsExist]);

           


        }

        #endregion
    }
}
