using PI.Domain.Entities;

namespace PI.Domain.Interfaces

{
    public interface IUserRepository : IRepositoryBase<UserEntity>
    {
        public Task<UserEntity?> GetByUserName(string u);
    }
}
