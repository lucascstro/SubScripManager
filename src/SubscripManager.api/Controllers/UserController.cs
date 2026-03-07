using Microsoft.AspNetCore.Mvc;
using SubscripManager.api.Models;
using SubscripManager.application.Interfaces;
using SubscripManager.domain.Entities;

namespace SubscripManager.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserServices _userServices;

        public UserController(IUserServices userServices)
        {
            _userServices = userServices;
        }

        [HttpGet]
        public IEnumerable<User> Get()
        {
          return _userServices.GetUsers();
        }

        [HttpGet("{userId}")]
        public User Get(Guid userId)
        {
            return _userServices.GetUserById(userId);
        }

        [HttpPost]
        public ActionResult Post([FromBody] UserModel user)
        {
            var ret = _userServices.Create(new User(user.Name, user.Email));
            return Ok(ret);
        }

        [HttpPut("{userId}")]
        public ActionResult Put(Guid userId, [FromBody] UserModel user)
        {
            var ret = _userServices.Update(userId, new User(user.Name, user.Email));
            return Ok(ret);
        }
    }
}
