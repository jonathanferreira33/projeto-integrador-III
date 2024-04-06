using Auth.Data;
using Auth.Model;

namespace Auth.Service
{
    public class AuthService 
    {
        private AuthRepository _authRepository;

        public AuthService()
        {
            _authRepository = new AuthRepository();
        }

        public Task<LoginDTO> Login(UserLoginRequest user)
        {
            user.Password.GenerateHash();
            return _authRepository.FindByLogin(user);
        }

        public Task<bool> LogOut(UserLoginRequest user)
        {
            throw new NotImplementedException();
        }
    }
}
