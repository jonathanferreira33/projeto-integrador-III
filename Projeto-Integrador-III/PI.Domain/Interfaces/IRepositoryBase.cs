using PI.Domain.Entities;

namespace PI.Domain.Interfaces
{
    public interface IRepositoryBase<T> where T : BaseEntity
    {

        //DDL = "D" do meio vem de Definição.
        //DML = "M" do meio vem de Manipulação.
        //DQL = "Q" do meio vem de "Query" que sigifica Consulta.

        //DDL

        //DML
        Task<T> CreateAsync(T item);
        Task<T> UpdateAsync(T item);
        Task<bool> DeleteAsync(Guid id);

        //DQL
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(Guid id);
    }
}
