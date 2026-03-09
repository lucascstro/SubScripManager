using MediatR;
using Microsoft.AspNetCore.Mvc;
using SubscripManager.api.Models;
using SubscripManager.application.Features.Users.Request;
using SubscripManager.application.Interfaces;
using SubscripManager.domain.Entities;

namespace SubscripManager.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserServices _userServices;
        private readonly IMediator _mediator;


        public UserController(IUserServices userServices, IMediator mediator)
        {
            _userServices = userServices;
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var ret = await _mediator.Send(new GetUsersRequest());
            return Ok(ret);
        }

        [HttpGet("{userId}")]
        public async Task<ActionResult> GetUserById(Guid userId)
        {
            var ret = await _mediator.Send(new GetUserByIdRequest(userId));
            return Ok(ret);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] UserModel user)
        {
            var ret = _mediator.Send(new CreateUserRequest(new User(user.Name, user.Email)));
            return Ok(ret);
        }

        [HttpPut("{userId}")]
        public async Task<ActionResult> Put(Guid userId, [FromBody] UserModel user)
        {
            var ret = _mediator.Send(new UpdateUserRequest(userId, new User(user.Name, user.Email)));
            return Ok(ret);
        }
    }
}
