using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlServerCe;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KassaApp.Models.Connection
{
    class ConnectionFactory
    {
        public static IDbConnection GetConnection()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["KassaDBContext"].ToString();
            return new SqlCeConnection(connectionString);
        }

        public static IDbConnection GetMainDbConnection()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["MainDB"].ToString();
            return new SqlCeConnection(connectionString);
        }
    }
}
