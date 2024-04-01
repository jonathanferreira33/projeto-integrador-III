using Auth.Interface;

namespace Auth.Service
{
    internal class AuthService : IAuthService
    {
        private readonly IAuthRepository _authRepository;
        public Task<bool> Login(UserLoginRequest user)
        {
            user.PassWord.GenerateHash();
            return _authRepository.FindByLogin(user);
        }

        public Task<bool> LogOut(UserLoginRequest user)
        {
            throw new NotImplementedException();
        }
    }
}
