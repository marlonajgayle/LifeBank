using LifeBank.Application.Common.Models;
using MediatR;

namespace LifeBank.Application.Authentication.Command.Login
{
    public class LoginCommand : IRequest<TokenResult>
    {
        public string Username { get; set; }
        public string Password { get; set; }

        public LoginCommand(LoginViewModel model)
        {
            Username = model.Username;
            Password = model.Password;
        }
    }
}
