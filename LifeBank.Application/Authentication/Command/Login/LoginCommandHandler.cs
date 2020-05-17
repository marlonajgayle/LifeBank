using LifeBank.Application.Common.Exceptions;
using LifeBank.Application.Common.Interfaces;
using LifeBank.Application.Common.Models;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace LifeBank.Application.Authentication.Command.Login
{
    public class LoginCommandHandler : IRequestHandler<LoginCommand, TokenResult>
    {
        private readonly IUserManager userManager;
        private readonly ISecurityTokenManager securityTokenManager;

        public LoginCommandHandler(IUserManager userManager, ISecurityTokenManager securityTokenManager)
        {
            this.userManager = userManager;
            this.securityTokenManager = securityTokenManager;
        }

        public async Task<TokenResult> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var user = await userManager.FindUserByEmailAsync(request.Username);

            if (user == null)
            {
                throw new BadRequestException("username and or password provided is invalid.");
            }

            var userHasVaildPassword = await userManager.CheckPasswordAsync(user, request.Password);

            if (!userHasVaildPassword)
            {
                throw new BadRequestException("username and or password provided is invalid.");
            }

            var tokenResult = await securityTokenManager.GenerateClaimsTokenAsync(user.DonorId, request.Username, cancellationToken);

            return tokenResult;
        }
    }
}
