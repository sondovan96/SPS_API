using MediatR;
using Microsoft.AspNetCore.Identity;
using SPS.Data.Models.Entities;
using SPS.Service.Accounts.JWTGeneration;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using SPS.Data.Repositories;
using FluentValidation;
using FluentValidation.Results;
using SPS.Core.Exceptions;
using SPS.Data.UnitOfWork;
using SPS.Core.Constants;

namespace SPS.Service.Accounts.Command.RegisterAccount
{
    public class RegisterAccountHandler : IRequestHandler<RegisterAccountRequest, JWTGenerationRequest>
    {
        private readonly UserManager<Account> _userManager;
        private readonly RoleManager<Role> _roleManager;

        public RegisterAccountHandler(UserManager<Account> userManager, RoleManager<Role> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task<JWTGenerationRequest> Handle(RegisterAccountRequest request, CancellationToken cancellationToken)
        {
            var role = await ValidateRole(request);
            await ValidateEmail(request);
            var user = await AddUser(request);
            await _userManager.AddToRoleAsync(user, role);
            return new JWTGenerationRequest
            {
                Email = request.Email,
                FirstName = request.FirstName,
                LastName = request.LastName,
                Id = user.Id,
                IsConfirmedEmail = false,
                Roles = new List<string> { role }
            };
        }

        private async Task ValidateEmail(RegisterAccountRequest request)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);
            if(user != null)
            {
                throw new ValidationException(new ValidationFailure[]
                {
                    new ValidationFailure(nameof(request.Email), "The " + nameof(request.Email).ToLower()+" is existed")
                });
            }
        }
        private async Task<string> ValidateRole(RegisterAccountRequest request)
        {
            var result = await _roleManager.FindByIdAsync(request.RoleId.ToString());
            if (result == null)
            {
                throw new ResourceNotFoundException(nameof(request.RoleId), request.RoleId);
            }
            return result.Name;
        }

        private async Task<Account> AddUser(RegisterAccountRequest request)
        {
            var user = new Account
            {
                CreatedDate = DateTime.UtcNow,
                Email = request.Email,
                EmailConfirmed = false,
                FirstName = request.FirstName,
                LastName = request.LastName,
                NormalizedEmail = request.Email.ToUpper(),
                NormalizedUserName = request.Email.ToUpper(),
                PhoneNumberConfirmed = true,
                UserName = request.Email
            };

            var result = await _userManager.CreateAsync(user, request.Password);
            if(!result.Succeeded)
            {
                var validationFailures = new List<ValidationFailure>();
                foreach(var error in result.Errors)
                {
                    validationFailures.Add(new ValidationFailure(error.Code, error.Description));
                }

                throw new ValidationException(validationFailures);
            }
            return user;
        }
    }
}
