using AutoMapper;
using LifeBank.Api.Contracts.Version1.Requests;
using LifeBank.Api.Contracts.Version1.Responses;
using LifeBank.Api.Routes.Version1;
using LifeBank.Application.Authentication.Command.Login;
using LifeBank.Application.Authentication.Command.Logout;
using LifeBank.Application.Authentication.Command.Refresh.Command;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace LifeBank.Api.Controllers.Version1
{
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IMediator mediator;
        private readonly IMapper mapper;

        public LoginController(IMediator mediator, IMapper mapper)
        {
            this.mediator = mediator;
            this.mapper = mapper;
        }

        /// <summary>
        /// Login user
        /// </summary>
        /// <response code="200">Login user</response>
        /// <response code="401">Unable to login user due to authentication error</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [HttpPost(ApiRoutes.Auth.Login)]
        public async Task<IActionResult> Login([FromBody] LoginViewModel model)
        {
            var command = new LoginCommand(model);
            var result = await mediator.Send(command);

            return Ok(new AuthSuccessResponse()
            {
                Token = result.Token,
                RefreshToken = result.RefreshToken,
                Success = true
            });
        }

        [HttpPost(ApiRoutes.Auth.Refresh)]
        public async Task<IActionResult> Refresh([FromBody] RefreshTokenRequest refreshTokenRequest)
        {
            var refreshToken = mapper.Map<TokenDto>(refreshTokenRequest);
            var command = new RefreshTokenCommand(refreshToken);
            var result = await mediator.Send(command);

            return Ok(new AuthSuccessResponse()
            {
                Token = result.Token,
                RefreshToken = result.RefreshToken,
                Success = true
            });
        }

        /// <summary>
        /// Logout user
        /// </summary>
        /// <response code="200">Logout user</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpPost(ApiRoutes.Auth.Logout)]
        public async Task<IActionResult> Logout()
        {
            var command = new LogoutCommand();
            var results = await mediator.Send(command);

            return Ok();
        }
    }
}