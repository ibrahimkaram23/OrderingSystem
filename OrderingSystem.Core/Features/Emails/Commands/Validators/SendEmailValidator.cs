using FluentValidation;
using Microsoft.Extensions.Localization;
using OrderingSystem.Core.Features.Emails.Commands.Models;
using OrderingSystem.Core.Resources;
using OrderingSystem.Service.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderingSystem.Core.Features.Emails.Commands.Validators
{
    public class SendEmailValidator:AbstractValidator<SendEmailCommand>
    {


        #region fields
        private readonly IStringLocalizer<SharedResources> _localizer;
        #endregion
        #region ctor
        public SendEmailValidator(IStringLocalizer<SharedResources> localizer)
        {
            _localizer = localizer;
            ApplyValidationRules();
           
        }
        #endregion
        #region functions
        public void ApplyValidationRules()
        {
            RuleFor(x => x.Email)
               .NotEmpty().WithMessage(_localizer[SharedResourcesKeys.NotEmpty])
               .NotNull().WithMessage(_localizer[SharedResourcesKeys.Required]);


            RuleFor(x => x.Message)
               .NotEmpty().WithMessage(_localizer[SharedResourcesKeys.NotEmpty])
               .NotNull().WithMessage(_localizer[SharedResourcesKeys.Required]);


        }
        #endregion
    }
}
