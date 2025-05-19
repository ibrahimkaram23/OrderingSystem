﻿using FluentValidation;
using Microsoft.Extensions.Localization;
using OrderingSystem.Core.Features.ApplicationUser.Commands.Models;
using OrderingSystem.Core.Features.Authentication.Command.Models;
using OrderingSystem.Core.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderingSystem.Core.Features.Authentication.Command.Validations
{
    public class SignInValidators : AbstractValidator<SignInCommand>
    {

        #region fields
        private readonly IStringLocalizer<SharedResources> _localizer;
        #endregion
        #region ctor
        public SignInValidators(IStringLocalizer<SharedResources> localizer)
        {
            _localizer = localizer;
            ApplyValidationRules();
            ApplyCustomValidationRules();

        }
        #endregion
        #region function
        public void ApplyValidationRules()
        {
          
            RuleFor(x => x.Email)
               .NotEmpty().WithMessage(_localizer[SharedResourcesKeys.NotEmpty])
               .NotNull().WithMessage(_localizer[SharedResourcesKeys.Required]);

            RuleFor(x => x.Password)
               .NotEmpty().WithMessage(_localizer[SharedResourcesKeys.NotEmpty])
               .NotNull().WithMessage(_localizer[SharedResourcesKeys.Required]);

          


        }

        public void ApplyCustomValidationRules()
        {



        }

        #endregion
    }
}

