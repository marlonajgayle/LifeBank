using LifeBank.Api.Routes.Version1;
using LifeBank.Application.Donors.Commands.CreateDonor;
using LifeBank.Application.Donors.Commands.DeleteDonor;
using LifeBank.Application.Donors.Models;
using LifeBank.Application.Donors.Queries;
using LifeBank.Application.Donors.Queries.GetDonorsList;
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

        [HttpGet(ApiRoutes.Donors.GetAll)]
        public async Task<IActionResult> GetDonors()
        {
            var query = new GetDonorsListQuery();
            var result = await mediator.Send(query);

            return Ok(result);
        }

        [HttpPut(ApiRoutes.Donors.Update)]
        public async Task<IActionResult> UpdateDonor(long donorId, [FromBody] DonorViewModel donor)
        {
            var query = new GetDonorByIdQuery(donorId);
            var result = await mediator.Send(query);

            return result != null ? (IActionResult)Ok(result) : NotFound();
        }

        [HttpDelete(ApiRoutes.Donors.Delete)]
        public async Task<IActionResult> DeleteDonor(long donorId)
        {
            var command = new DeleteDonorCommand(donorId);
            var result = await mediator.Send(command);

            return result != null ? (IActionResult)Ok(result) : NotFound();
        }
    }
}