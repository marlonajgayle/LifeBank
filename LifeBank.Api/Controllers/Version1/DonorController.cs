using LifeBank.Api.Routes.Version1;
using LifeBank.Application.Common.Interfaces;
using LifeBank.Application.Donors.Commands.CreateDonor;
using LifeBank.Application.Donors.Commands.DeleteDonor;
using LifeBank.Application.Donors.Commands.UpdateDonor;
using LifeBank.Application.Donors.Models;
using LifeBank.Application.Donors.Queries;
using LifeBank.Application.Donors.Queries.GetDonorsList;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;
using System.Threading.Tasks;

namespace LifeBank.Api.Controllers.Version1
{
    [Consumes(MediaTypeNames.Application.Json)]
    [ApiController]
    public class DonorController : ControllerBase
    {
        private readonly IMediator mediator;
        private readonly IUriService uriService;

        public DonorController(IMediator mediator, IUriService uriService)
        {
            this.mediator = mediator;
            this.uriService = uriService;
        }

        /// <summary>
        /// Retrieves a Donor by provided Id
        /// </summary>
        /// <response code="200">Retrieves a Donor by provided Id</response>
        /// <response code="400">Unable to retrieve Donor due to validation error</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet(ApiRoutes.Donors.Get)]
        public async Task<IActionResult> GetDonor([FromRoute]long donorId)
        {
            var query = new GetDonorByIdQuery(donorId);
            var result = await mediator.Send(query);

            return Ok(result);
        }

        /// <summary>
        /// Creates a New Donor
        /// </summary>
        /// <response code="201">Creates a New Donor</response>
        /// <response code="400">Unable to create Donor due to validation error</response>
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost(ApiRoutes.Donors.Create)]
        public async Task<IActionResult> CreateDonor([FromBody] DonorViewModel donor)
        {
            var command = new CreateDonorCommand(donor);
            var result = await mediator.Send(command);

            var locationUri = uriService.GetDonorUri(ApiRoutes.Donors.Get, result.DonorId.ToString());

            return CreatedAtAction("locationUri", result);
        }

        /// <summary>
        /// Returns a list of Donors
        /// </summary>
        /// <response code="200">Returns a list of Donors</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet(ApiRoutes.Donors.GetAll)]
        public async Task<IActionResult> GetDonors()
        {
            var query = new GetDonorsListQuery();
            var result = await mediator.Send(query);

            return Ok(result);
        }

        /// <summary>
        /// Update a Donor record
        /// </summary>
        /// <response code="200">Update a Donor record</response>
        /// <response code="400">Unable to update Donor due to validation error</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPut(ApiRoutes.Donors.Update)]
        public async Task<IActionResult> UpdateDonor([FromRoute]long donorId, [FromBody] DonorViewModel viewModel)
        {
            var command = new UpdateDonorCommand(donorId, viewModel);
            var result = await mediator.Send(command);

            return Ok(result);
        }

        /// <summary>
        /// Delete a Donor record
        /// </summary>
        /// <response code="204">Delete a Donor record</response>
        /// <response code="404">Unable to delete Donor due to invalid Id</response>
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpDelete(ApiRoutes.Donors.Delete)]
        public async Task<IActionResult> DeleteDonor([FromRoute]long donorId)
        {
            var command = new DeleteDonorCommand(donorId);
            await mediator.Send(command);

            return NoContent();
        }
    }
}