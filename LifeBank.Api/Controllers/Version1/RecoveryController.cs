using LifeBank.Api.Routes.Version1;
using LifeBank.Application.PasswordRecovery.Commands.ForgotPassword;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
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

        /// <summary>
        /// Generates and sends authentication token for password recovery
        /// </summary>
        /// <response code="200">Generates and sends authentication token for password recovery</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpPost(ApiRoutes.Recovery.ForgotPassword)]
        public async Task<IActionResult> ForgotPassword([FromBody] ForgotPasswordViewModel viewModel)
        {
            var command = new ForgotPasswordCommand(viewModel);
            var result = await mediator.Send(command);

            if (!String.IsNullOrEmpty(result)) // to be refactored into command handler
            {
                var passwordResetLink = Url.Action("ResetPassword", "Recovery",
                    new { email = viewModel.Email, token = result }, Request.Scheme);
            }

            return Ok(result);
        }
    }
}