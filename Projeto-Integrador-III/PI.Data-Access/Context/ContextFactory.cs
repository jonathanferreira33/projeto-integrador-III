using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
namespace PI.Data_Access.Context
{
    public class ContextFactory : IDesignTimeDbContextFactory<SqlSContext>
    {
        public SqlSContext CreateDbContext(string[] args)
        {
            var connectionString = @"Server=(localdb)\mssqllocaldb;Database=EFGetStarted.ConsoleApp.NewDb;Trusted_Connection=True;";
            var optionsBuilder = new DbContextOptionsBuilder<SqlSContext>();
            optionsBuilder.UseSqlServer(connectionString);
            return new SqlSContext(optionsBuilder.Options);
        }
    }
}