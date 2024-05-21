using Auth.Model;
using Microsoft.Extensions.Caching.Memory;
using MySql.Data.MySqlClient;
using System.Data;

namespace Auth.Data
{
    internal class AuthRepository
    {
        private Context conn;
        private readonly IMemoryCache _memoryCache;

        public AuthRepository()
        {
            conn = new Context();
        }
        public async Task<LoginDTO> FindByLogin(UserLoginRequest user)
        {

            try
            {
                conn.connect();

                var query = $@"
                    SELECT * FROM db_stockmanager.tb_user
                    WHERE Email = '{user.Email}'
                    AND PassWordCrypt = '{user.Password}'
                ";

                MySqlDataAdapter dados = new MySqlDataAdapter(query, conn.MySQLconn);
                DataTable dataTable = new DataTable();

                dados.Fill(dataTable);

                if (dataTable.Rows.Count > 0)
                {
                    var result = (from rw in dataTable.AsEnumerable()
                                  select new LoginDTO()
                                  {
                                      Email = Convert.ToString(rw["Email"]),
                                      UserName = Convert.ToString(rw["UserName"])
                                  });
                    return result.FirstOrDefault();
                }
                return null;
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                conn.disconnect();
            }

        }
    }
}
