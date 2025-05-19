﻿using FluentValidation;
using Microsoft.Extensions.Localization;
using OrderingSystem.Core.Features.Authentication.Command.Models;
using OrderingSystem.Core.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderingSystem.Core.Features.Authentication.Command.Validations
{
    public class ResetPasswordValidator : AbstractValidator<ResetPasswordCommand>
    {

        #region fields
        private readonly IStringLocalizer<SharedResources> _localizer;
        #endregion
        #region ctor
        public ResetPasswordValidator(IStringLocalizer<SharedResources> localizer)
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

            RuleFor(x => x.ConfirmPassword)
             .Equal(x => x.Password).WithMessage(_localizer[SharedResourcesKeys.PasswordNotEquelConfirmPass]);




        }

        public void ApplyCustomValidationRules()
        {



        }

        #endregion
    }


}
