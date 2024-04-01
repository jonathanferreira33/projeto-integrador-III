namespace Auth.Interface
{
    internal interface IAuthService
    {
        public Task<bool> Login(UserLoginRequest user);

        public Task<bool> LogOut(UserLoginRequest user);
    }
}
