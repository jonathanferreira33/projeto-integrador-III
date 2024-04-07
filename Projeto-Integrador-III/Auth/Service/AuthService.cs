using Auth.Data;
using Auth.Model;
using Auth.Security;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Principal;

namespace Auth.Service
{
    public class AuthService
    {
        private AuthRepository _authRepository;
        private TokenConfig _tokenConfig;
        private SigningConfig _signingConfig;
        private IConfiguration _config;

        public AuthService()
        {
            _authRepository = new AuthRepository();
            _tokenConfig = new TokenConfig();
            _signingConfig = new SigningConfig();
        }

        public async Task<Object> Login(UserLoginRequest user)
        {
            user.Password.GenerateHash();
            var userCheck = await _authRepository.FindByLogin(user);
            
            if (userCheck == null)
                return new
                {
                    authenticated = false,
                    message = "Falha tentativa login"
                };

            ClaimsIdentity identity = new ClaimsIdentity(
                    new GenericIdentity(userCheck.Email),
                    new[] {
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                        new Claim(JwtRegisteredClaimNames.UniqueName, userCheck.Email),
                        new Claim(JwtRegisteredClaimNames.UniqueName, userCheck.UserName),
                    }
                );
            DateTime created = DateTime.Now;
            DateTime expiration = created + TimeSpan.FromSeconds(_tokenConfig.Seconds);

            var handler = new JwtSecurityTokenHandler();
            string token = CreateToken(identity, created, expiration, handler);

            return SuccessObject(created, expiration, token, userCheck);
        }

        public Task<bool> LogOut(UserLoginRequest user)
        {
            throw new NotImplementedException();
        }

        private string CreateToken(ClaimsIdentity identity, DateTime created, DateTime expiration, JwtSecurityTokenHandler handler)
        {
            var securityToken = handler.CreateToken(new SecurityTokenDescriptor
            {
                Issuer = _tokenConfig.Issuer,
                Audience = _tokenConfig.Audience,
                SigningCredentials = _signingConfig.SigningCredentials,
                Subject = identity,
                NotBefore = created,
                Expires = expiration
            });

            return handler.WriteToken(securityToken);
        }

        private object SuccessObject(DateTime created, DateTime expiration, string token, LoginDTO userCheck)
        {
            return new
            {
                authenticated = true,
                created = created.ToString("yyyy-MM-dd HH-mm:ss"),
                expiration = expiration.ToString("yyyy-MM-dd HH-mm:ss"),
                acessToken = token,
                userName = userCheck.UserName,
                message = "Usuario logado com sucesso"
            };
        }
    }
}
