namespace Auth.Interface
{
    interface IAuthRepository
    {
        Task<bool> FindByLogin(UserLoginRequest user);
    }
}
