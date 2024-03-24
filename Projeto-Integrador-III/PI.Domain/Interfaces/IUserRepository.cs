using PI.Domain.Entities;

namespace PI.Domain.Interfaces

{
    public interface IUserRepository : IRepositoryBase<User>
    {
        public User? GetByUserName(User u);
    }
}
