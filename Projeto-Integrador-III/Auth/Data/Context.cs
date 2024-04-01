using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using PI.Data_Access.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Auth.Data
{
    public class Context 
    {
        // Configuration["ConnectionStrings:MySQLConnectionString"]
        public MySqlConnection MySQLconn = new MySqlConnection("Persist Security Info=false;server=127.0.0.1;uid=root;pwd=admin123;database=db_stockmanager");
        
        public void connect() => MySQLconn.Open();

        public void disconnect() => MySQLconn.Close();
    }
}
