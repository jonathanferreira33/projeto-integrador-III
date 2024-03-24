using PI.Data_Access.Context;
using PI.Domain;
using PI.Domain.Entities;
using PI.Domain.Interfaces;

namespace PI.Data
{
    public class UserRepository : BaseRepository<UserEntity>
    {
        private readonly MySQLContext _context;
        public UserRepository(MySQLContext context) : base(context)
        {
            _context = context;
        }

        public Task<UserEntity> GetByUserName(string name)
        {
            return _context
            Task<UserEntity>? user = new UserEntity();
            return user;
        }
    }
}