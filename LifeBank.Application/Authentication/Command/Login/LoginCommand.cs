using MediatR;

namespace LifeBank.Application.Authentication.Command.Login
{
    public class LoginCommand : IRequest<Unit>
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
