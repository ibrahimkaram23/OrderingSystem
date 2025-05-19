﻿using Azure.Core;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Localization;
using Microsoft.IdentityModel.Tokens;
using OrderingSystem.Core.Bases;
using OrderingSystem.Core.Features.Authentication.Command.Models;
using OrderingSystem.Core.Resources;
using OrderingSystem.Data.Entities.Identity;
using OrderingSystem.Data.Results;
using OrderingSystem.Service.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace OrderingSystem.Core.Features.Authentication.Command.Handlers
{
    public class AuthentactionCommandHandler : ResponseHandler,
        IRequestHandler<SignInCommand, Response<JwtAuthResult>>,
        IRequestHandler<RefreshTokenCommand, Response<JwtAuthResult>>,
        IRequestHandler<SendResetPasswordCommand, Response<string>>,
        IRequestHandler<ResetPasswordCommand, Response<string>>
    {
        #region fields
        private readonly IStringLocalizer<SharedResources> _stringLocalizer;
        private readonly IAuthenicationService _authenicationService;
        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;
        #endregion
        #region ctor
        public AuthentactionCommandHandler(IAuthenicationService authenicationService, SignInManager<User> signInManager,UserManager<User> userManager,IStringLocalizer<SharedResources> stringLocalizer):base(stringLocalizer)
        {
            _authenicationService = authenicationService;
            _signInManager = signInManager;
            _userManager = userManager;
            _stringLocalizer = stringLocalizer;
        }
        #endregion
        #region functions
        public async Task<Response<JwtAuthResult>> Handle(SignInCommand request, CancellationToken cancellationToken)
        {
         //هنشةف ايميل موجود ف داتا بيز ولالا check if email is exist or not
         var Email= await _userManager.FindByEmailAsync(request.Email);
            var user = await _userManager.FindByNameAsync(Email.UserName);

         //return the email not found
         if (Email == null) return BadRequest<JwtAuthResult>(_stringLocalizer[SharedResourcesKeys.EmailIsNotExist]);
            //try to sign in
         var signInResult =  await _signInManager.CheckPasswordSignInAsync(user, request.Password, false);
            if (!signInResult.Succeeded) return BadRequest<JwtAuthResult>(_stringLocalizer[SharedResourcesKeys.PasswordNotCorrect]);
            //confirm email
            if (!user.EmailConfirmed)
                return BadRequest<JwtAuthResult>(_stringLocalizer[SharedResourcesKeys.EmailNotConfirmed]);
            //if failed return password is wrong
            //try to sign in
            //generate token
            var result =  await _authenicationService.GetJWTToken(user);
            //return token
            return Success(result);
        }

        public async Task<Response<JwtAuthResult>> Handle(RefreshTokenCommand request, CancellationToken cancellationToken)
        {
            var jwtToken =_authenicationService.ReadJWTToken(request.AccessToken);
            if (jwtToken == null)
            {
                return Unauthorized<JwtAuthResult>(_stringLocalizer[SharedResourcesKeys.InvaildToken]);
            }

            var userIdAndExpireDate = await _authenicationService.ValidateDetails(jwtToken, request.AccessToken, request.RefreshToken);
            switch (userIdAndExpireDate)
            {
                case ("AlgrothimIsWrong",null):return Unauthorized<JwtAuthResult>(_stringLocalizer[SharedResourcesKeys.AlgrothimIsWrong]);
                case ("TokenIsNotExpired",null): return Unauthorized<JwtAuthResult>(_stringLocalizer[SharedResourcesKeys.TokenIsNotExpired]);
                case ("RefreshTokenIsNotFound",null): return Unauthorized<JwtAuthResult>(_stringLocalizer[SharedResourcesKeys.RefreshTokenIsNotFound]);
                case ("RefreshTokenIsExpired",null) : return Unauthorized<JwtAuthResult>(_stringLocalizer[SharedResourcesKeys.RefreshTokenIsExpired]);
            }
            var (userId, expiredate) = userIdAndExpireDate;
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return NotFound<JwtAuthResult>();
            }

            var result = await _authenicationService.GetRefreshToken(user,jwtToken,expiredate,request.RefreshToken);
            return Success( result);


        }

        public async Task<Response<string>> Handle(SendResetPasswordCommand request, CancellationToken cancellationToken)
        {
            var result = await _authenicationService.SendResetPasswordCode(request.Email);
            switch (result)
            {
                case "UserNotFound":return BadRequest<string>(_stringLocalizer[SharedResourcesKeys.UserIsNotFound]);
                case "ErrorInUpdateUser": return BadRequest<string>(_stringLocalizer[SharedResourcesKeys.TryAgainInAnotherTime]);
                case "Failed": return BadRequest<string>(_stringLocalizer[SharedResourcesKeys.TryAgainInAnotherTime]);
                case "Success": return Success<string>("");
                default:return BadRequest<string>(_stringLocalizer[SharedResourcesKeys.TryAgainInAnotherTime]);
            }
        }

        public async Task<Response<string>> Handle(ResetPasswordCommand request, CancellationToken cancellationToken)
        {
            var result = await _authenicationService.ResetPassword(request.Email, request.Password);
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
