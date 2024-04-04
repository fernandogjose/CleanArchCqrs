using AutoMapper;
using CleanArchCqrs.Application.ComandsHandlers.Product.Commands;
using CleanArchCqrs.Application.ComandsHandlers.Product.Queries;
using CleanArchCqrs.Application.Dtos;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchCqrs.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;

        private readonly IMapper _mapper;

        public ProductController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult<ProductGetAllResponse>> Post([FromBody] ProductCreateRequest productCreateRequest)
        {
            var productCreateResponse = await _mediator.Send(_mapper.Map<ProductCreateCommand>(productCreateRequest));

            return productCreateResponse == null
                ? NotFound("Product not created")
                : Ok(productCreateResponse);
        }

        [HttpDelete]
        public async Task<ActionResult<ProductGetAllResponse>> Delete([FromBody] ProductDeleteRequest productDeleteRequest)
        {
            var productDeleteResponse = await _mediator.Send(_mapper.Map<ProductDeleteCommand>(productDeleteRequest));

            return productDeleteResponse == null
                ? NotFound("Product not created")
                : Ok(productDeleteResponse);
        }

        [HttpPut]
        public async Task<ActionResult<ProductGetAllResponse>> Put([FromBody] ProductUpdateRequest productUpdateRequest)
        {
            var productUpdateResponse = await _mediator.Send(_mapper.Map<ProductUpdateCommand>(productUpdateRequest));

            return productUpdateResponse == null
                ? NotFound("Product not created")
                : Ok(productUpdateResponse);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductGetAllResponse>>> Get()
        {
            var productGetAllResponse = await _mediator.Send(new ProductGetAllQuery());

            return productGetAllResponse == null || !productGetAllResponse.Any()
                ? NotFound("Products not found")
                : Ok(productGetAllResponse);
        }

        [HttpGet("id:int")]
        public async Task<ActionResult<ProductGetByIdResponse>> Get([FromQuery] int id)
        {
            var productGetByIdResponse = await _mediator.Send(new ProductGetByIdQuery(id));

            return productGetByIdResponse == null
                ? NotFound("Product not found")
                : Ok(productGetByIdResponse);
        }
    }
}
