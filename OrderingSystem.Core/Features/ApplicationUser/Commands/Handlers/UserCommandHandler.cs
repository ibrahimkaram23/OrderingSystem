﻿using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;
using OrderingSystem.Core.Bases;
using OrderingSystem.Core.Features.ApplicationUser.Commands.Models;
using OrderingSystem.Core.Resources;
using OrderingSystem.Data.Entities.Identity;
using OrderingSystem.Service.Abstracts;
using MapsterMapper;

namespace OrderingSystem.Core.Features.ApplicationUser.Commands.Handlers
{   public class UserCommandHandler:ResponseHandler
        ,IRequestHandler<AddUserCommand,Response<string>>
        ,IRequestHandler<EditUserCommand,Response<string>>
        ,IRequestHandler<DeleteUserCommand, Response<string>>
        ,IRequestHandler<ChangeUserPasswordCommand, Response<string>>
    {
     

        #region fields
        private readonly IStringLocalizer<SharedResources> _sharedLocalizer;
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IApplicationUserService _applicationUserService;
        private readonly IEmailService _emailService;
        #endregion
        #region ctor
        public UserCommandHandler(IHttpContextAccessor httpContextAccessor,IApplicationUserService applicationUserService,IEmailService emailService,IStringLocalizer<SharedResources> sharedLocalizer, IMapper mapper, UserManager<User> userManager) : base(sharedLocalizer)
        {
            _httpContextAccessor = httpContextAccessor;
            _applicationUserService = applicationUserService;
            _emailService = emailService;
            _sharedLocalizer = sharedLocalizer;
            _mapper = mapper;
            _userManager = userManager;
        }
        #endregion
        #region handelFuction
       
        public async Task<Response<string>> Handle(AddUserCommand request, CancellationToken cancellationToken)
        {
            var identityUser= _mapper.Map<User>(request);
            //create
            var CreateResult = await _applicationUserService.AddUserAsync(identityUser, request.Password);
            switch (CreateResult)
            {
                case ("EmailIsExist"): return BadRequest<string>(_sharedLocalizer[SharedResourcesKeys.EmailIsExist]);
                case ("UserNameIsExist"): return BadRequest<string>(_sharedLocalizer[SharedResourcesKeys.UserNameIsExist]);
                case ("ErrorInCreateUser"): return BadRequest<string>(_sharedLocalizer[SharedResourcesKeys.FaildToAddUser]);
                case ("Failed"): return BadRequest<string>(_sharedLocalizer[SharedResourcesKeys.TryToRegisterAgain]);
                case "Success":return Success<string>("");
                default:return BadRequest<string>(CreateResult);
            }
            return Success<string>("");
            
        }

        public async Task<Response<string>> Handle(EditUserCommand request, CancellationToken cancellationToken)
        {
            //check if user is exist
            var Olduser=await _userManager.FindByIdAsync(request.Id.ToString());
            //if not exist not found
            if(Olduser == null) return NotFound<string>();
            //mapping
            var newUser=_mapper.Map(request,Olduser);

            //if username is Exist
            var userByUserName= await _userManager.Users.FirstOrDefaultAsync(x=>x.UserName==newUser.UserName&&x.Id!=newUser.Id);
            //username is exist
            if(userByUserName != null) return BadRequest<string>(_sharedLocalizer[SharedResourcesKeys.UserNameIsExist]);

            //update
            var result = await _userManager.UpdateAsync(newUser);
            //result is not success
            if (!result.Succeeded) return BadRequest<string>(_sharedLocalizer[SharedResourcesKeys.UpdateFailed]);
            //message
            return Success((string)_sharedLocalizer[SharedResourcesKeys.Updated]);
        }

        public async Task<Response<string>> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            //check if user is exist
            var user = await _userManager.FindByIdAsync(request.Id.ToString());
            //if not exist not found
            if (user == null) return NotFound<string>();
            //delete the user
            var result= await _userManager.DeleteAsync(user);
            //in case of failure
            if (!result.Succeeded) return BadRequest<string>(_sharedLocalizer[SharedResourcesKeys.DeletedFailed]);
            return Success((string)_sharedLocalizer[SharedResourcesKeys.Deleted]);



        }

        public async Task<Response<string>> Handle(ChangeUserPasswordCommand request, CancellationToken cancellationToken)
        {
            //get user
            //check if user is exist
            var user = await _userManager.FindByIdAsync(request.Id.ToString());
            //if Not Exist notfound
            if (user == null) return NotFound<string>();

            //Change User Password
            var result = await _userManager.ChangePasswordAsync(user, request.CurrentPassword, request.NewPassword);
            //var user1=await _userManager.HasPasswordAsync(user);
            //await _userManager.RemovePasswordAsync(user);
            //await _userManager.AddPasswordAsync(user, request.NewPassword);

            //result
            if (!result.Succeeded) return BadRequest<string>(result.Errors.FirstOrDefault().Description);
            return Success((string)_sharedLocalizer[SharedResourcesKeys.Success]);
        }
        #endregion
    }
}
