using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using quartz.application.Users.CommandInteractors.CreateUser;
using quartz.application.Users.QueryInteractors.UserLogin;
using Quartz.Application;
using System.Threading.Tasks;

namespace quartz.api.Controllers
{
    [Authorize(AuthenticationSchemes = "Bearer")]
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class UserController : ControllerBase
    {

        private readonly IMediator _mediator;
        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> login([FromBody] UserLoginRequest userLoginRequest)
        {
            try
            {
                var result = await _mediator.Send(userLoginRequest);
                return Ok(result);
            }
            catch (InvalidQuartzOperationException e)
            {
                return Content(e.Message);
            }
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> createuser([FromBody] CreateUserRequest createUserRequest)
        {
            try
            {
                var result = await _mediator.Send(createUserRequest);
                return Ok(result);
            }
            catch (InvalidQuartzOperationException e)
            {
                return Content(e.Message);
            }
        }
    }
}