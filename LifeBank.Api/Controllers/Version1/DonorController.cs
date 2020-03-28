using LifeBank.Api.Routes.Version1;
using LifeBank.Application.Donors.Commands.CreateDonor;
using LifeBank.Application.Donors.Models;
using LifeBank.Application.Donors.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace LifeBank.Api.Controllers.Version1
{
    [Route("api/[controller]")]
    [ApiController]
    public class DonorController : ControllerBase
    {
        private readonly IMediator mediator;

        public DonorController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet(ApiRoutes.Donors.Get)]
        public async Task<IActionResult> GetDonor(long donorId)
        {
            var query = new GetDonorByIdQuery(donorId);
            var result = await mediator.Send(query);

            return result != null ? (IActionResult) Ok(result) : NotFound();
        }

        [HttpPost(ApiRoutes.Donors.Create)]
        public async Task<IActionResult> CreateDonor([FromBody] DonorViewModel donor)
        {
            var command = new CreateDonorCommand(donor);
            var result = await mediator.Send(command);

            return CreatedAtAction("CreateDonor", result);
        }
    }
}