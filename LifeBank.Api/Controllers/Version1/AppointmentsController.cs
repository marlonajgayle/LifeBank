using LifeBank.Api.Routes.Version1;
using LifeBank.Application.Appointments.Commands.CreateAppointment;
using LifeBank.Application.Appointments.Commands.DeleteAppointment;
using LifeBank.Application.Appointments.Commands.UpdateAppointment;
using LifeBank.Application.Appointments.Models;
using LifeBank.Application.Appointments.Queries.GetAppointmentDetails;
using LifeBank.Application.Appointments.Queries.GetAppointmentList;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace LifeBank.Api.Controllers.Version1
{
    [ApiController]
    public class AppointmentsController : ControllerBase
    {
        private readonly IMediator mediator;

        public AppointmentsController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet(ApiRoutes.Appointments.Get)]
        public async Task<IActionResult> Get(long appointmentId)
        {
            var query = new GetAppointmentByIdQuery(appointmentId);
            var result = await mediator.Send(query);

            return result != null ? (IActionResult)Ok(result) : NotFound();
        }

        [HttpPost(ApiRoutes.Appointments.Create)]
        public async Task<IActionResult> Create([FromBody] AppointmentViewModel viewModel)
        {
            var command = new CreateAppointmentCommand(viewModel);
            var result = await mediator.Send(command);

            return CreatedAtAction("CreateAppointment", result);
        }

        [HttpGet(ApiRoutes.Appointments.GetAll)]
        public async Task<IActionResult> GetAll()

        {
            var query = new GetAppointmentsListQuery();
            var result = await mediator.Send(query);

            return Ok(result);
        }

        [HttpPut(ApiRoutes.Appointments.Update)]
        public async Task<IActionResult> Update(long appointmentId, [FromBody] AppointmentViewModel viewModel)
        {
            var query = new UpdateAppointmentCommand(viewModel);
            var result = await mediator.Send(query);

            return result != null ? (IActionResult)Ok(result) : NotFound();
        }

        [HttpDelete(ApiRoutes.Appointments.Delete)]
        public async Task<IActionResult> Delete(long appointmentId)
        {
            var command = new DeleteAppointmentCommand(appointmentId);
            var result = await mediator.Send(command);

            return result != null ? (IActionResult)Ok(result) : NotFound();
        }
    }
}