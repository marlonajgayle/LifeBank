using LifeBank.Application.Common.Exceptions;
using LifeBank.Application.Common.Interfaces;
using LifeBank.Application.Registration.Commands;
using LifeBank.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace LifeBank.Application.Registration.RegisterDonor.Commands
{
    public class RegisterDonorCommandHandler : IRequestHandler<RegisterDonorCommand, Unit>
    {
        private readonly IUserManager userManager;

        public RegisterDonorCommandHandler(IUserManager userManager)
        {
            this.userManager = userManager;
        }

        public async Task<Unit> Handle(RegisterDonorCommand request, CancellationToken cancellationToken)
        {
            // check if user already registered
            var existingUser = userManager.FindUserByEmailAsync(request.Email);
            if (existingUser != null)
            {
                throw new BadRequestException($"user with this {request.Email} email address already exists.");
            }

            // Create new user account
            var result = await userManager.CreateUserAsync(request.Email, request.Password);

            if (!result.Result.Succeeded)
            {
                throw new CreateFailureException(nameof(Donor), "There was an issue creating this donor.");
            }

            return Unit.Value;
        }
    }
}
