using PI.Domain.DTOs;
using PI.Domain.Entities;
using PI.Domain.Request;

namespace PI.Domain.Interfaces.Services
{
    public interface IUserService : IBaseService<UserEntity>
    {
        Task<UserEntity> GetByName(string name);
    }
}