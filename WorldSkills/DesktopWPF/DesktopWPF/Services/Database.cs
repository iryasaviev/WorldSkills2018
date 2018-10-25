using System.Data.SqlClient;

namespace DesktopWPF.Services
{
    public class Database
    {
        public string ConnectionString { get; set; }

        public SqlConnection ConnectionOpen()
        {
            SqlConnection connection = new SqlConnection(ConnectionString);

            return connection;
        }
    }
}