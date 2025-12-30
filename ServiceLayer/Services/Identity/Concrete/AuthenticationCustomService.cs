using Azure.Core;
using EntityLayer.Identity.Entities;
using EntityLayer.Identity.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Helpers.Identity.EmailHelper;
using ServiceLayer.Services.Identity.Abstract;
using System;

namespace ServiceLayer.Services.Identity.Concrete
{
    public class AuthenticationCustomService(ISendEmailMethod _sendEmail, UserManager<AppUser> _userManager) : IAuthenticationCustomService
    {
        public async Task CreateResetPassLinkAndSentToEmail(AppUser user, HttpContext context, IUrlHelper url, ForgotPasswordVM request)
        {
            string resetToken = await _userManager.GeneratePasswordResetTokenAsync(user);
            var resetPasswordLink = url.Action("ResetPassword", "Authentication", new { userId = user.Id, Token = resetToken }, context.Request.Scheme);
            await _sendEmail.SendPasswordResetLinkWithToken(resetPasswordLink!, request.Email);
        }
    }
}
