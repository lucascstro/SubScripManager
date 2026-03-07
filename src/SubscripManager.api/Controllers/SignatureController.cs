using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SubscripManager.api.Models;
using SubscripManager.application.DTO;
using SubscripManager.application.Features.Signatures.Dto;
using SubscripManager.application.Features.Signatures.Request;
using SubscripManager.application.Interfaces;
using SubscripManager.domain.Entities;

namespace SubscripManager.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SignatureController : ControllerBase
    {
        private readonly IMediator _mediator;

        public SignatureController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{userId}")]
        public async Task<List<SignatureDTO>> GetByUser(Guid userId)
        {
            return await _mediator.Send(new GetSignaturesByUserRequest(userId));
        }

        // [HttpGet("monthly-expences/{userId}")]
        // public ActionResult<MonthlyExpencesDTO> GetMonthly(Guid userId)
        // {
        //     var result = _signatureServices.GetMonthlyExpences(userId);
        //     return Ok(result);
        // }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] SignatureModel model)
        {
            var signature = new Signature(model.NameService, model.Value, model.PaymentDay, model.Status, model.Categories, model.UserId);
            var ret = await _mediator.Send(new CreateSignatureRequest(signature));
            return Ok(ret);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(Guid id, [FromBody] SignatureModel model)
        {
            
            var ret = await _mediator.Send(new UpdateSignatureRequest(id, new Signature(model.NameService,
                                                                                model.Value,
                                                                                model.PaymentDay,
                                                                                model.Status,
                                                                                model.Categories,
                                                                                model.UserId)));
                                                                                
            return Ok(ret);
        }
    }
}