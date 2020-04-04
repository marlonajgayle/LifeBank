using MediatR;

namespace LifeBank.Application.Registration.Commands
{
    public class RegisterDonorCommand : IRequest<Unit>
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }

        public RegisterDonorCommand(RegisterViewModel registerViewModel)
        {
            Email = registerViewModel.Email;
            Password = registerViewModel.Password;
            ConfirmPassword = registerViewModel.ConfirmPassword;
        }
    }
}
