using PI.Domain.Entities;
using PI.Domain.Interfaces;
using PI.Domain.Interfaces.Services;

namespace PI_Service.Services
{
    internal class UserService : IUserService
    {
        private IUserRepository _repository;

        public UserService(IUserRepository userRepository)
        {
            _repository = userRepository;
        }

        public async Task<bool> Delete(Guid id)
        {
            return await _repository.DeleteAsync(id);
        }

        public async Task<UserEntity> Get(Guid id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<UserEntity>> GetAll()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<UserEntity> Post(UserEntity user)
        {
            return await _repository.CreateAsync(user);
        }

        public async Task<UserEntity> Put(UserEntity user)
        {
            return await _repository.UpdateAsync(user);
        }

        public async Task<UserEntity> GetByName(string name)
        {
            //TODO - DAO
            return await _repository.GetByUserName(name);
        }
    }
}
