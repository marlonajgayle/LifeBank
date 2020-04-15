using LifeBank.Api.Routes.Version1;
using LifeBank.Application.Registration.Commands;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace LifeBank.Api.Controllers.Version1
{
    [ApiController]
    public class RegistrationController : ControllerBase
    {
        private readonly IMediator mediator;

        public RegistrationController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        /// <summary>
        /// Registers new Donor
        /// </summary>
        /// <response code="200">Registers a new Donor</response>
        /// <response code="400">Unable to register Donor due to validation error</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost(ApiRoutes.Registration.Register)]
        public async Task<IActionResult> register([FromBody] RegisterViewModel model)
        {
            var command = new RegisterDonorCommand(model);
            var result = await mediator.Send(command);

            return Ok(result);
        }
    }
}