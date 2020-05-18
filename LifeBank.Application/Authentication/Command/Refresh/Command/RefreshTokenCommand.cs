using LifeBank.Application.Common.Models;
using MediatR;

namespace LifeBank.Application.Authentication.Command.Refresh.Command
{
    public class RefreshTokenCommand : IRequest<TokenResult>
    {
        public string Token { get; set; }
        public string RefreshToken { get; set; }

        public RefreshTokenCommand(TokenDto tokenDto)
        {
            Token = tokenDto.Token;
            RefreshToken = tokenDto.RefreshToken;
        }
    }
}
