using PI.Domain.Entities;

namespace PI.Domain.Interfaces.Services
{
    public interface IUserService
    {
        Task<UserEntity> Get(Guid id);
        Task<IEnumerable<UserEntity>> GetAll();
        Task<UserEntity> Post(UserEntity u);
        Task<UserEntity> Put(UserEntity u);
        Task<bool> Delete(Guid id);
    }
}