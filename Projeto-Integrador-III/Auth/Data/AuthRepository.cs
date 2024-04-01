using Auth.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using MySql.Data.MySqlClient;
using System.Data;

namespace Auth.Data
{
    internal class AuthRepository : IAuthRepository
    {
        private Context conn;
        private readonly IMemoryCache _memoryCache;

        public AuthRepository(IMemoryCache memoryCache)
        {
            conn = new Context();
            _memoryCache = memoryCache;
        }
        public async Task<bool> FindByLogin(UserLoginRequest user)
        {

            try
            {
                conn.connect();

                var query = $@"
                    SELECT * FROM db_stockmanager.tb_user
                    WHERE Email = {user.Email}
                    AND PassWordCrypt = {user.Password}
                ";

                MySqlDataAdapter dados = new MySqlDataAdapter(query, conn.MySQLconn);
                DataTable dataTable = new DataTable();

                dados.Fill(dataTable);



            }
            catch (Exception ex)
            {
                return false;
            }


            conn.disconnect();
            return true;

        }
    }
}
