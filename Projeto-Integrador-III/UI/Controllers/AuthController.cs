using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using PI.Domain.Request;
using Auth.Service;
using Auth;

namespace UI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : BasePIController
    {
        private IMapper _mapper;
        private AuthService _auth;

        public AuthController(IMapper mapper)
        {
            _mapper = mapper;
            _auth = new AuthService();

        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromQuery] LoginRequest userRequest)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var user = _mapper.Map<UserLoginRequest>(userRequest);
                user.Password = userRequest.Password.GenerateHash();

                var result = await _auth.Login(user);

                if (result == null)
                    return StatusCode(401, "Usuário não encontrado");

                return Ok(result);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPost("logout")]
        public async Task<IActionResult> Logout([FromQuery] LoginRequest userRequest)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok();
        }

    }
}
