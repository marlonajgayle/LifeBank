using LifeBank.Api.Routes.Version1;
using LifeBank.Application.PasswordRecovery.Commands.ForgotPassword;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace LifeBank.Api.Controllers.Version1
{
    [ApiController]
    public class RecoveryController : ControllerBase
    {
        private readonly IMediator mediator;

        public RecoveryController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost(ApiRoutes.Recovery.ForgotPassword)]
        public async Task<IActionResult> ForgotPassword([FromBody] ForgotPasswordViewModel viewModel)
        {
            var command = new ForgotPasswordCommand(viewModel);
            var result = await mediator.Send(command);

            if (result != null) // to be refactored into command handler
            {
                var passwordResetLink = Url.Action("ResetPassword", "Recovery",
                    new { email = viewModel.Email, token = result }, Request.Scheme);
            }

            return Ok(result);
        }
    }
}