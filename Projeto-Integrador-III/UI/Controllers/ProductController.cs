using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PI.Domain.DTOs;
using PI.Domain.Entities;
using PI.Domain.Interfaces.Services;
using PI.Domain.Request;
using System.Net;

namespace UI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : BasePIController
    {
        private IMapper _mapper;
        private IProductService _service;

        public ProductController(IMapper mapper, IProductService service)
        {
            _mapper = mapper;
            _service = service;
        }

        [HttpGet("getallproducts")]
        public async Task<IActionResult> GetAll()
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                return Ok(await _service.GetAll());
            }
            catch (Exception e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [HttpPost("createproduct")]
        public async Task<IActionResult> PostProduct([FromBody] ProductRequest productRequest)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var user = _mapper.Map<ProductEntity>(productRequest);

            try
            {
                var result = await _service.Post(user);

                if (result == null)
                    return BadRequest();

                return Created(
                        new Uri(Url.Link("getproductwithid", new { id = result.Id })),
                        result);
            }
            catch (ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [HttpGet("getproductwithid/{id}", Name = "getproductwithid")]
        public async Task<IActionResult> GetProduct(Guid id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                return Ok(await _service.Get(id));
            }
            catch (Exception e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [HttpPut("editproduct")]
        public async Task<IActionResult> PutProduct([FromBody] ProductDto productUp)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                if (await _service.Get(productUp.Id) == null)
                    return NotFound("Produto não encontrado!");

                var product = _mapper.Map<ProductEntity>(productUp);
                product.UpdateAt = DateTime.Now;
                var result = await _service.Put(product);
                return Ok(result);
            }
            catch (ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }

        }

        [HttpPut("quantitychange")]
        public async Task<IActionResult> QuantityChange([FromBody] Guid id, int amount)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var product = await _service.Get(id);
                if (product == null)
                    return NotFound("Produto não encontrado!");

                return Ok(await _service.QuantityChange(product, amount));
            }
            catch (Exception e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }
    }
}
