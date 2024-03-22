using PI.Domain.Entities;

namespace PI.Domain.Interfaces

{
    public interface IUserRepository
    {
        public void Add(User u);
        public User? GetByUserName(User u);
    }
}
