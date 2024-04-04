using AutoMapper;
using CleanArchCqrs.Application.ComandsHandlers.Payment.Commands;
using CleanArchCqrs.Application.ComandsHandlers.Payment.Queries;
using CleanArchCqrs.Application.Dtos;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchCqrs.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly IMediator _mediator;

        private readonly IMapper _mapper;

        public PaymentController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult<PaymentGetAllResponse>> Post([FromBody] PaymentCreateRequest paymentCreateRequest)
        {
            var paymentCreateResponse = await _mediator.Send(_mapper.Map<PaymentCreateCommand>(paymentCreateRequest));

            return paymentCreateResponse == null
                ? NotFound("Payment not created")
                : Ok(paymentCreateResponse);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PaymentGetAllResponse>>> Get()
        {
            var paymentGetAllResponse = await _mediator.Send(new PaymentGetAllQuery());

            return paymentGetAllResponse == null || !paymentGetAllResponse.Any()
                ? NotFound("Payments not found")
                : Ok(paymentGetAllResponse);
        }
    }
}
