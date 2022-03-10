using FluentValidation;
using FluentValidation.Results;
using MediatR;
using Microsoft.AspNetCore.Identity;
using SPS.Core.Exceptions;
using SPS.Data.Models.Entities;
using SPS.Service.Accounts.JWTGeneration;

using System.Threading;
using System.Threading.Tasks;

namespace SPS.Service.Accounts.Queries.EmailConfirm
{
    public class EmailConfirmHandler : IRequestHandler<EmailConfirmRequest, JWTGenerationRequest>
    {
        private readonly UserManager<Account> _userManager;

        public EmailConfirmHandler(UserManager<Account> userManager)
        {
            _userManager = userManager;
        }

        public async Task<JWTGenerationRequest> Handle(EmailConfirmRequest request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);
            if(user ==null)
            {
                throw new ResourceNotFoundException(nameof(request.Email), request.Email);
            }

            var result = await _userManager.ConfirmEmailAsync(user, request.Token);
            if(result.Succeeded)
            {
                user.EmailConfirmed = true;
                await _userManager.UpdateAsync(user);

                return new JWTGenerationRequest
                {
                    Email = user.Email,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Id = user.Id,
                    IsConfirmedEmail = true,
                    Roles = await _userManager.GetRolesAsync(user),
                };
            }
            else
            {
                throw new ValidationException(new ValidationFailure[1]
                {
                    new ValidationFailure(nameof(request.Token), request.Token)
                });
            }
        }
    }
}
