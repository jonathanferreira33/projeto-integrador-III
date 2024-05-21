using Microsoft.EntityFrameworkCore;
using PI.Data_Access.Mapping;
using PI.Domain.Entities;

namespace PI.Data_Access.Context
{
    public class MySQLContext : DbContext
    {
        public DbSet<UserEntity> Users { get; set; }
        public DbSet<ProductEntity> Products { get; set; }

        public MySQLContext(DbContextOptions<MySQLContext> options) : base(options)
        {

        }


        protected override void OnModelCreating (ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<UserEntity>(new UserMap().Configure);
            modelBuilder.Entity<ProductEntity>(new ProductMap().Configure);
            modelBuilder.Entity<RoleEntity>(new RoleMap().Configure);
            modelBuilder.Entity<CategoryEntity>(new CategoryMap().Configure);
        }
    }
}
