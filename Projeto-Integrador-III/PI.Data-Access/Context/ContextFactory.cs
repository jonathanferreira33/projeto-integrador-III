using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace PI.Data_Access.Context
{
    public class ContextFactory : IDesignTimeDbContextFactory<MySQLContext>
    {
        private static IConfiguration _configuration;
        //public ContextFactory(IConfiguration configuration)
        //{
        //    _configuration = configuration;
        //}

        public ContextFactory()
        {
        }
        public MySQLContext CreateDbContext(string[] args)
        {
            var connectionString = "server=127.0.0.1;uid=root;pwd=admin123;database=db_stockmanager";
            //var connectionString = _configuration.GetSection("ConnectionString").Value;
            Console.WriteLine(connectionString);
            var optionsBuilder = new DbContextOptionsBuilder<MySQLContext>();
            optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
            return new MySQLContext(optionsBuilder.Options);
        }
    }
}