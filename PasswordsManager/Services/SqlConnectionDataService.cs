using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace PasswordsManager.Services
{
    static class SqlConnectionDataService
    {

        public static string  ConnectionDataBase()
        {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();

            builder.DataSource = @"ANDREYPC\SQLEXPRESS";
            builder.InitialCatalog = "newBD";
            builder.IntegratedSecurity = true;

            return builder.ConnectionString;
        }
    }
}
