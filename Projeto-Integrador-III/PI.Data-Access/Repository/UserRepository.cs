using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using PI.Data_Access.Context;
using PI.Domain.DTOs;
using PI.Domain.Entities;
using PI.Domain.Interfaces;

namespace PI.Data_Access.Repository
{
    public class UserRepository : BaseRepository<UserEntity>, IUserRepository
    {
        private readonly MySQLContext _context;
        private readonly IMemoryCache _memoryCache;
        private DbSet<UserEntity> _dataset;
        public UserRepository(MySQLContext context, IMemoryCache memoryCache) : base(context, memoryCache)
        {
            _memoryCache = memoryCache;
            _context = context;
            _dataset = context.Set<UserEntity>();
        }

        public async Task<UserEntity?> GetByEmail(string email)
        {
            return await _dataset.FirstOrDefaultAsync(x => x.Email.Equals(email));
        }

        public async Task<UserEntity?> GetByUserName(string u)
        {
            return await _dataset.FirstOrDefaultAsync(x => x.UserName.Equals(u));
        }
    }
}
