using LifeBank.Api.Routes.Version1;
using LifeBank.Application.ChangePassword.Command;
using MediatR;
using Microsoft.AspNetCore.Http;
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

        /// <summary>
        /// Change Donor Password
        /// </summary>
        /// <response code="204">Change Donor Password</response>
        /// <response code="401">Unable to change Donor password due to invalid current password</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [HttpPost(ApiRoutes.Change.Password)]
        public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordViewModel ViewModel)
        {
            var command = new ChangePasswordCommand(ViewModel, User);
            var result = await mediator.Send(command);

            return Ok(result);
        }
    }
}