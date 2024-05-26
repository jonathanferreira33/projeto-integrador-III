using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PI.Domain.DTOs;
using PI.Domain.Entities;
using PI.Domain.Interfaces.Services;
using PI.Domain.Request;
using System.Net;

namespace UI.Controllers
{
    //[Authorize]
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
                var listProducts = await _service.GetAll();
                return Ok(listProducts);
            }
            catch (Exception e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [HttpGet("getproductwithid/{id}", Name = "getproductwithid")]
        public async Task<IActionResult> GetProduct(int id)
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

        [HttpPost("createproduct")]
        public async Task<IActionResult> PostProduct(ProductRequest productRequest)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var product = _mapper.Map<ProductEntity>(productRequest);

            try
            {
                var result = await _service.Post(product);

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
        public async Task<IActionResult> QuantityChange([FromBody] QuantityChangeRequest productRequest)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var product = await _service.Get(productRequest.Id);
                if (product == null)
                    return NotFound("Produto não encontrado!");

                var edit = await _service.QuantityChange(product, productRequest.Amount);

                return Ok(edit);
            }
            catch (Exception e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }
    }
}
