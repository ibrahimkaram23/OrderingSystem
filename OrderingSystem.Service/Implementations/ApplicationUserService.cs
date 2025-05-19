﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OrderingSystem.Data.Entities.Identity;
using OrderingSystem.infrastructure.Data;
using OrderingSystem.Service.Abstracts;

namespace OrderingSystem.Service.Implementations
{
    internal class ApplicationUserService : IApplicationUserService
    {
        #region fields
        private readonly IUrlHelper _urlHelper;
        private readonly UserManager<User> _userManager;
        private readonly APPDBContext _aPPDBContext;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IEmailService _emailService;
        #endregion
        #region ctor

        public ApplicationUserService(IUrlHelper urlHelper,UserManager<User> userManager,APPDBContext aPPDBContext ,IHttpContextAccessor httpContextAccessor,IEmailService emailService)
        {
            _urlHelper = urlHelper;
            _userManager = userManager;
            _aPPDBContext = aPPDBContext;
            _httpContextAccessor = httpContextAccessor;
            _emailService = emailService;
        }

        #endregion
        #region functions
        public async Task<string> AddUserAsync(User user, string password)
        {
            var trans=await _aPPDBContext.Database.BeginTransactionAsync();
            try
            {
                //if email is exist
                var existuser = await _userManager.FindByEmailAsync(user.Email!);
                //email is exist
                if (existuser != null) return "EmailIsExist";

                //if username is exist
                var userByUserName = await _userManager.FindByNameAsync(user.UserName!);
                //username is exist
                if (userByUserName != null) return "UserNameIsExist";

                //create
                var CreateResult = await _userManager.CreateAsync(user, password);
                //failed
                if (!CreateResult.Succeeded)
                    return string.Join(",",CreateResult.Errors.Select(x=>x.Description).ToList());
                //message
                await _userManager.AddToRoleAsync(user, "Customer");

                //send confirm email
                var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                var requestAccessor = _httpContextAccessor.HttpContext!.Request;
                var returnUrl = requestAccessor.Scheme + "://" + requestAccessor.Host + _urlHelper.Action("ConfirmEmail", "Authentication", new { userId = user.Id, code = code });
                //message or body
                var message = $"hello {user.UserName} ,To Confirm Email Click Link: <a href='{returnUrl}'></a> ";
                await _emailService.SendEmail(user.Email!, message, "Confirm Email");
                await trans.CommitAsync();
                return "Success";
            }
            catch (Exception)
            {
                await trans.RollbackAsync();
                return "Failed";
            }
        }
        #endregion
    }
}
