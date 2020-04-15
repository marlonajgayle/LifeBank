using LifeBank.Api.Routes.Version1;
using LifeBank.Application.Appointments.Commands.CreateAppointment;
using LifeBank.Application.Appointments.Commands.DeleteAppointment;
using LifeBank.Application.Appointments.Commands.UpdateAppointment;
using LifeBank.Application.Appointments.Models;
using LifeBank.Application.Appointments.Queries.GetAppointmentDetails;
using LifeBank.Application.Appointments.Queries.GetAppointmentList;
using LifeBank.Application.Common.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace LifeBank.Api.Controllers.Version1
{
    [ApiController]
    public class AppointmentsController : ControllerBase
    {
        private readonly IMediator mediator;
        private readonly IUriService uriService;

        public AppointmentsController(IMediator mediator, IUriService uriService)
        {
            this.mediator = mediator;
            this.uriService = uriService;
        }

        /// <summary>
        /// Retrieves an Appointment by provided Id
        /// </summary>
        /// <response code="200">Retrieves an Appointment by provided Id</response>
        /// <response code="400">Unable to retrieve Appointment due to validation error</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet(ApiRoutes.Appointments.Get)]
        public async Task<IActionResult> Get(long appointmentId)
        {
            var query = new GetAppointmentByIdQuery(appointmentId);
            var result = await mediator.Send(query);

            return Ok(result);
        }

        /// <summary>
        /// Creates a New Appointment
        /// </summary>
        /// <response code="201">Creates a New Appointment</response>
        /// <response code="400">Unable to create Appointment due to validation error</response>
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost(ApiRoutes.Appointments.Create)]
        public async Task<IActionResult> Create([FromBody] AppointmentViewModel viewModel)
        {
            var command = new CreateAppointmentCommand(viewModel);
            var result = await mediator.Send(command);

            var locationUri = uriService.GetAppointmentUri(ApiRoutes.Appointments.Get, result.AppointmentId.ToString());
            
            return CreatedAtAction("locationUri", result);
        }

        /// <summary>
        /// Returns a list of Appointments
        /// </summary>
        /// <response code="200">Returns a list of Appointments</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet(ApiRoutes.Appointments.GetAll)]
        public async Task<IActionResult> GetAll()

        {
            var query = new GetAppointmentsListQuery();
            var result = await mediator.Send(query);

            return Ok(result);
        }

        /// <summary>
        /// Update an Appointment record
        /// </summary>
        /// <response code="200">Update an Appointment record</response>
        /// <response code="400">Unable to update Appointment due to validation error</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPut(ApiRoutes.Appointments.Update)]
        public async Task<IActionResult> Update([FromRoute]long appointmentId, [FromBody] AppointmentViewModel viewModel)
        {
            var query = new UpdateAppointmentCommand(appointmentId, viewModel);
            var result = await mediator.Send(query);

            return Ok(result);
        }

        /// <summary>
        /// Delete an Appointment record
        /// </summary>
        /// <response code="204">Delete an Appointment record</response>
        /// <response code="404">Unable to delete Appointment due to invalid Id</response>
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpDelete(ApiRoutes.Appointments.Delete)]
        public async Task<IActionResult> Delete(long appointmentId)
        {
            var command = new DeleteAppointmentCommand(appointmentId);
            await mediator.Send(command);

            return NoContent();
        }
    }
}