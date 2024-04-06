namespace PI.Domain.Interfaces.Services
{
   
    public interface IBaseService<T> 
    {
        Task<T> Get(Guid id);
        Task<IEnumerable<T>> GetAll();
        Task<T> Post(T u);
        Task<T> Put(T u);
        Task<bool> Delete(Guid id);
    }
}