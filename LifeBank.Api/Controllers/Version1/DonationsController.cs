using LifeBank.Api.Routes.Version1;
using LifeBank.Application.Donations.Commands.CreateDonation;
using LifeBank.Application.Donations.Commands.DeleteDonation;
using LifeBank.Application.Donations.Commands.UpdateDonation;
using LifeBank.Application.Donations.Queries.GetDonationDetails;
using LifeBank.Application.Donations.Queries.GetDonationsList;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace LifeBank.Api.Controllers.Version1
{
    [ApiController]
    public class DonationsController : ControllerBase
    {
        private readonly IMediator mediator;

        public DonationsController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet(ApiRoutes.Donations.Get)]
        public async Task<IActionResult> Get(long DonationId)
        {
            var query = new GetDonationByIdQuery(DonationId);
            var result = await mediator.Send(query);

            return result != null ? (IActionResult)Ok(result) : NotFound();
        }

        [HttpPost(ApiRoutes.Donations.Create)]
        public async Task<IActionResult> Create([FromBody] Application.Donations.Models.DonationViewModel Donation)
        {
            var command = new CreateDonationCommand(Donation);
            var result = await mediator.Send(command);

            return CreatedAtAction("CreateDonation", result);
        }

        [HttpGet(ApiRoutes.Donations.GetAll)]
        public async Task<IActionResult> GetAll()

        {
            var query = new GetDonationsListQuery();
            var result = await mediator.Send(query);

            return Ok(result);
        }

        [HttpPut(ApiRoutes.Donations.Update)]
        public async Task<IActionResult> Update(long DonationId, [FromBody] Application.Donations.Models.DonationViewModel Donation)
        {
            var query = new UpdateDonationCommand(Donation);
            var result = await mediator.Send(query);

            return result != null ? (IActionResult)Ok(result) : NotFound();
        }

        [HttpDelete(ApiRoutes.Donations.Delete)]
        public async Task<IActionResult> Delete(long DonationId)
        {
            var command = new DeleteDonationCommand(DonationId);
            var result = await mediator.Send(command);

            return result != null ? (IActionResult)Ok(result) : NotFound();
        }
    }
}