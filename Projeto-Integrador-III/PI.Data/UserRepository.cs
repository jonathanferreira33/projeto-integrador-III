using PI.Data_Access.Context;
using PI.Domain;
using PI.Domain.Entities;
using PI.Domain.Interfaces;

namespace PI.Data
{
    public class UserRepository : BaseRepository<User>
    {
        public UserRepository(MySQLContext context) : base(context)
        {
        }
    }
}