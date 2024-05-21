using Auth.Service;
using PI.Domain.Entities;
using PI.Domain.Interfaces;
using PI.Domain.Interfaces.Services;
using PI.Domain.Request;

namespace PI.Service
{
    public class UserService : IUserService
    {
        private IUserRepository _repository;

        public UserService(IUserRepository userRepository)
        {
            _repository = userRepository;
        }

        public async Task<bool> Delete(int id)
        {
            return await _repository.DeleteAsync(id);
        }

        public async Task<UserEntity> Get(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<UserEntity>> GetAll()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<UserEntity> Post(UserEntity userRequest)
        {

            var newUser = await _repository.CreateAsync(userRequest);
            return newUser;
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

        public void SetPassHash(string password)
        {
            password.GenerateHash();
        }
    }
}