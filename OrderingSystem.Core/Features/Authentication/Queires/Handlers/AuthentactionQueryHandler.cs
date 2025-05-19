﻿using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Localization;
using OrderingSystem.Core.Bases;
using OrderingSystem.Core.Features.Authentication.Command.Models;
using OrderingSystem.Core.Features.Authentication.Queires.Models;
using OrderingSystem.Core.Resources;
using OrderingSystem.Data.Entities.Identity;
using OrderingSystem.Data.Helpers;
using OrderingSystem.Service.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderingSystem.Core.Features.Authentication.Queires.Handlers
{
    public class AuthentactionQueryHandler : ResponseHandler,
        IRequestHandler<AuthorizeUserQuery, Response<string>>,
        IRequestHandler<ConfirmEmailQuery, Response<string>>,
        IRequestHandler<ConfirmResetPasswordQuery, Response<string>>
    {
        #region fields
        private readonly IStringLocalizer<SharedResources> _stringLocalizer;
        private readonly IAuthenicationService _authenicationService;

        #endregion
        #region ctor
        public AuthentactionQueryHandler(IAuthenicationService authenicationService, IStringLocalizer<SharedResources> stringLocalizer) : base(stringLocalizer)
        {
            _authenicationService = authenicationService;
            
            _stringLocalizer = stringLocalizer;
        }
        #endregion
        #region functions
        public async Task<Response<string>> Handle(AuthorizeUserQuery request, CancellationToken cancellationToken)
        {
            var result = await _authenicationService.ValidateToken(request.AccessToken);
            if (result == "NotExpired") 
                return Success(result);
            return Unauthorized<string>(_stringLocalizer[SharedResourcesKeys.TokenIsExpired]);
        }

        public async Task<Response<string>> Handle(ConfirmEmailQuery request, CancellationToken cancellationToken)
        {
            var confirmEmail = await _authenicationService.ConfirmEmail(request.UserId, request.Code);
            if (confirmEmail== "ErrorWhenConfirmEmail")
            {
                return BadRequest<string>(_stringLocalizer[SharedResourcesKeys.ErrorWhenConfirmEmail]);
            }
            return Success<string>(_stringLocalizer[SharedResourcesKeys.ConfirmEmailDone]);
        }

        public async Task<Response<string>> Handle(ConfirmResetPasswordQuery request, CancellationToken cancellationToken)
        {
            var result = await _authenicationService.ConfirmResetPassword(request.Code,request.Email);
            switch (result)
            {
                case "UserNotFound": return BadRequest<string>(_stringLocalizer[SharedResourcesKeys.UserIsNotFound]);
                case "Failed": return BadRequest<string>(_stringLocalizer[SharedResourcesKeys.InvaildCode]);
                case "Success": return Success<string>("");
                default: return BadRequest<string>(_stringLocalizer[SharedResourcesKeys.InvaildCode]);
            }
        }
        #endregion



    }
}
