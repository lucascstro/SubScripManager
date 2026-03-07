using Microsoft.AspNetCore.Mvc;
using SubscripManager.api.Models;
using SubscripManager.application.DTO;
using SubscripManager.application.Interfaces;
using SubscripManager.domain.Entities;

namespace SubscripManager.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SignatureController : ControllerBase
    {
        private readonly ISignatureServices _signatureServices;

        public SignatureController(ISignatureServices signatureServices)
        {
            _signatureServices = signatureServices;
        }

        [HttpGet("{userId}")]
        public List<Signature> GetByUser(Guid userId)
        {
            return _signatureServices.GetByUserId(userId);
        }
        
        [HttpGet("monthly-expences/{userId}")]
        public ActionResult<MonthlyExpencesDTO> GetMonthly(Guid userId)
        {
            var result = _signatureServices.GetMonthlyExpences(userId);
            return Ok(result);
        }

        [HttpPost]
        public ActionResult Post([FromBody] SignatureModel model)
        {
            var ret = _signatureServices.Create(new Signature(model.NameService,
                                                              model.Value,
                                                              model.PaymentDay,
                                                              model.Status,
                                                              model.Categories,
                                                              model.UserId));
            return Ok(ret);
        }

        [HttpPut("{id}")]
        public ActionResult Put(Guid id, [FromBody] SignatureModel model)
        {
            var ret = _signatureServices.Update(id, new Signature(model.NameService,
                                                                  model.Value,
                                                                  model.PaymentDay,
                                                                  model.Status,
                                                                  model.Categories,
                                                                  model.UserId));
            return Ok(ret);
        }
    }
}