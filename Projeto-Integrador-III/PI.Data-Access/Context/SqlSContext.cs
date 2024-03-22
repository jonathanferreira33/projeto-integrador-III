using Microsoft.EntityFrameworkCore;
using PI.Domain.Entities;

namespace PI.Data_Access.Context
{
    public class SqlSContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public SqlSContext(DbContextOptions<SqlSContext> options) : base(options)
        {

        }


        protected override void OnModelCreating (ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
