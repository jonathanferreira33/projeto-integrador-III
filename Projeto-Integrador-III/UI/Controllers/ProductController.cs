using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PI.Domain.Interfaces.Services;
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

    }
}
