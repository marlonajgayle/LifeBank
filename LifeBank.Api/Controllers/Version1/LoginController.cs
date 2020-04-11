using LifeBank.Api.Routes.Version1;
using LifeBank.Application.Authentication.Command.Login;
using LifeBank.Application.Authentication.Command.Logout;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace LifeBank.Api.Controllers.Version1
{
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IMediator mediator;

        public LoginController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost(ApiRoutes.Auth.Login)]
        public async Task<IActionResult> Login([FromBody] LoginViewModel model)
        {
            var command = new LoginCommand(model);
            var results = await mediator.Send(command);

            return Ok();
        }

        [HttpPost(ApiRoutes.Auth.Logout)]
        public async Task<IActionResult> Logout()
        {
            var command = new LogoutCommand();
            var results = await mediator.Send(command);

            return Ok();
        }
    }
}