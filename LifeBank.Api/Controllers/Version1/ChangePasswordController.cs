using LifeBank.Api.Routes.Version1;
using LifeBank.Application.ChangePassword.Command;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace LifeBank.Api.Controllers.Version1
{
    [ApiController]
    public class ChangePasswordController : ControllerBase
    {
        private readonly IMediator mediator;

        public ChangePasswordController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost(ApiRoutes.Change.Password)]
        public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordViewModel ViewModel)
        {
            var command = new ChangePasswordCommand(ViewModel, User);
            var result = await mediator.Send(command);

            return Ok(result);
        }
    }
}