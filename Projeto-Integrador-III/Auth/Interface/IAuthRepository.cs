namespace Auth.Interface
{
    public interface IAuthRepository
    {
        Task<bool> FindByLogin(UserLoginRequest user);
    }
}
