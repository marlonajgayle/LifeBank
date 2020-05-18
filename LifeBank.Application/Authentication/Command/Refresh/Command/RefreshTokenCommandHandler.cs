using LifeBank.Application.Common.Exceptions;
using LifeBank.Application.Common.Interfaces;
using LifeBank.Application.Common.Models;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace LifeBank.Application.Authentication.Command.Refresh.Command
{
    public class RefreshTokenCommandHandler : IRequestHandler<RefreshTokenCommand, TokenResult>
    {
        private readonly ISecurityTokenManager securityTokenManager;

        public RefreshTokenCommandHandler(ISecurityTokenManager securityTokenManager)
        {
            this.securityTokenManager = securityTokenManager;
        }

        public async Task<TokenResult> Handle(RefreshTokenCommand request, CancellationToken cancellationToken)
        {
            var tokenResult = await securityTokenManager.RefreshTokenAsync(request.Token, request.RefreshToken, cancellationToken);

            if (!tokenResult.Succeeded)
            {
                throw new BadRequestException(tokenResult.Error);
            }

            return tokenResult;
        }
    }
}