using LifeBank.Api.Routes.Version1;
using LifeBank.Application.Common.Interfaces;
using LifeBank.Application.Donations.Commands.CreateDonation;
using LifeBank.Application.Donations.Commands.DeleteDonation;
using LifeBank.Application.Donations.Commands.UpdateDonation;
using LifeBank.Application.Donations.Models;
using LifeBank.Application.Donations.Queries.GetDonationDetails;
using LifeBank.Application.Donations.Queries.GetDonationsList;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;
using System.Threading.Tasks;

namespace LifeBank.Api.Controllers.Version1
{
    [Consumes(MediaTypeNames.Application.Json)]
    [ApiController]
    public class DonationsController : ControllerBase
    {
        private readonly IMediator mediator;
        private readonly IUriService uriService;

        public DonationsController(IMediator mediator, IUriService uriService)
        {
            this.mediator = mediator;
            this.uriService = uriService;
        }

        /// <summary>
        /// Retrieves a Donation by provided Id
        /// </summary>
        /// <response code="200">Retrieves a Donation by provided Id</response>
        /// <response code="400">Unable to retrieve Donation due to validation error</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet(ApiRoutes.Donations.Get)]
        public async Task<IActionResult> Get(long DonationId)
        {
            var query = new GetDonationByIdQuery(DonationId);
            var result = await mediator.Send(query);

            return Ok(result);
        }

        /// <summary>
        /// Creates a New Donation
        /// </summary>
        /// <response code="201">Creates a New Donation</response>
        /// <response code="400">Unable to create Donation due to validation error</response>
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost(ApiRoutes.Donations.Create)]
        public async Task<IActionResult> Create([FromBody] DonationViewModel viewModel)
        {
            var command = new CreateDonationCommand(viewModel);
            var result = await mediator.Send(command);

            var locationUri = uriService.GetDonationUri(ApiRoutes.Donations.Get, result.DonationId.ToString());

            return CreatedAtAction("CreateDonation", result);
        }

        /// <summary>
        /// Returns a list of Donations
        /// </summary>
        /// <response code="200">Returns a list of Donations</response>
        [HttpGet(ApiRoutes.Donations.GetAll)]
        public async Task<IActionResult> GetAll()

        {
            var query = new GetDonationsListQuery();
            var result = await mediator.Send(query);

            return Ok(result);
        }

        /// <summary>
        /// Update a Donations record
        /// </summary>
        /// <response code="200">Update a Donations record</response>
        /// <response code="400">Unable to update Donations due to validation error</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPut(ApiRoutes.Donations.Update)]
        public async Task<IActionResult> Update([FromRoute]long donationId, [FromBody]DonationViewModel viewModel)
        {
            var query = new UpdateDonationCommand(donationId, viewModel);
            var result = await mediator.Send(query);

            return Ok(result);
        }

        /// <summary>
        /// Delete a Donation record
        /// </summary>
        /// <response code="204">Delete a Donation record</response>
        /// <response code="404">Unable to delete Donation due to invalid Id</response>
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpDelete(ApiRoutes.Donations.Delete)]
        public async Task<IActionResult> Delete(long DonationId)
        {
            var command = new DeleteDonationCommand(DonationId);
            await mediator.Send(command);

            return NoContent();
        }
    }
}