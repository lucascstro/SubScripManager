using Microsoft.AspNetCore.Mvc;
using SubscripManager.api.Models;
using SubscripManager.application.DTO;
using SubscripManager.application.Interfaces;
using SubscripManager.application.Services;
using SubscripManager.domain.Entities;

namespace SubscripManager.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserServices _userServices;
        private readonly ISignatureServices _signatureServices;

        public UserController(IUserServices userServices, ISignatureServices signatureServices)
        {
            _userServices = userServices;
            _signatureServices = signatureServices;
        }

        // GET: api/<UserController>
        [HttpGet]
        public IEnumerable<User> Get()
        {
          return _userServices.GetUsers();
        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public User Get(string userId)
        {
            return _userServices.GetUserById(Guid.Parse(userId));
        }

        // POST api/<UserController>
        [HttpPost]
        public ActionResult Post([FromBody] UserModel user)
        {
            var ret = _userServices.Create(new User(user.Name, user.Email));
            return Ok(ret);
        }

        // PUT api/<UserController>/5
        [HttpPut("{userid}")]
        public ActionResult Put(string userId, [FromBody] UserModel user)
        {
            var ret = _userServices.Update(Guid.Parse(userId), new User(user.Name, user.Email));
            return Ok(ret);
        }

        // Caso de uso principal: Gastos Mensais
        [HttpGet("monthly-expences/{userId}")]
        public ActionResult<MonthlyExpencesDTO> GetMonthly(Guid userId)
        {
            var result = _signatureServices.GetMonthlyExpenxes(userId);
            return Ok(result);
        }
    }
}
