using Microsoft.EntityFrameworkCore;
using PI.Data_Access.Context;
using PI.Domain.Entities;
using PI.Domain.Interfaces;

namespace PI.Data
{
    public class BaseRepository<T> : IRepositoryBase<T> where T : BaseEntity
    {
        private readonly MySQLContext _context;
        private DbSet<T> _dataSet;
        public BaseRepository(MySQLContext context)
        {
            _context = context;
            _dataSet = context.Set<T>();
        }

        public async Task<T> CreateAsync(T item)
        {
            try
            {
                item.Id = Guid.NewGuid();

                item.CreateAt = DateTime.Now;
                _dataSet.Add(item);

                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw e;
            }

            return item;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            try
            {
                var result = await _dataSet.SingleOrDefaultAsync(x => x.Id.Equals(id));

                if (result == null)
                    return false;

                _dataSet.Remove(result);
                await _context.SaveChangesAsync();

            }
            catch (Exception e)
            {
                throw e;
            }

            return true;
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            try
            {
                return await _dataSet.ToListAsync();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<T> GetByIdAsync(Guid id)
        {
            try
            {
                return await _dataSet.SingleOrDefaultAsync(x => x.Id.Equals(id));
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<T> UpdateAsync(T item)
        {
            try
            {
                var result = await _dataSet.SingleOrDefaultAsync(x => x.Id.Equals(item.Id));

                if (result == null)
                    return null;

                item.UpdateAt = DateTime.Now;
                item.CreateAt = result.CreateAt;

                _context.Entry(result).CurrentValues.SetValues(item);
                await _context.SaveChangesAsync();

            }
            catch (Exception e)
            {
                throw e;
            }

            return item;
        }

        public async Task<bool> ExistAsync(Guid id)
        {
            return await _dataSet.AnyAsync(x => x.Id.Equals(id));
        }
    }
}
