using Auth.Service;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PI.Domain.Entities;
using PI.Domain.Interfaces.Services;
using PI.Domain.Request;
using System.Net;

namespace UI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : BasePIController
    {
        private IMapper _mapper;
        private IUserService _userService;
        public UserController(IUserService service, IMapper mapper)
        {
            _userService = service;
            _mapper = mapper;
        }

        [HttpGet("getallusers")]
        public async Task<IActionResult> GetAll()
        {

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                return Ok(await _userService.GetAll());
            }
            catch (ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [HttpGet("getuserwithid/{id}", Name = "getuserwithid")]
        public async Task<IActionResult> GetUser(Guid id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                return Ok(await _userService.Get(id));
            }
            catch (ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [HttpPost("createuser")]
        public async Task<IActionResult> PostUser([FromBody] UserRequest userRequest)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var user =  _mapper.Map<UserEntity>(userRequest);
            user.PassWordCrypt = userRequest.Password.GenerateHash();

            try
            {
                var result = await _userService.Post(user);

                if (result == null)
                    return BadRequest();

                return Created(
                        new Uri(Url.Link("getuserwithid", new { id = result.Id })),
                        result);
            }
            catch (ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [HttpPut("edituser")]
        public async Task<IActionResult> PutUser([FromBody] UserEntity u)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            try
            {
                var result = await _userService.Put(u);
                return Ok(result);
            }
            catch (ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }

        }

        [HttpDelete("deleteuser/{id}")]
        public async Task<IActionResult> DeleteUser(Guid id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var result = _userService.Delete(id);

                if (!result.Result)
                    return BadRequest();

                return Ok(await _userService.Delete(id));
            }
            catch (ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }
    }
}
