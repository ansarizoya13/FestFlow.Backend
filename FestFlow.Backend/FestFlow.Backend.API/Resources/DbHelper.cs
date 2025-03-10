using Microsoft.Data.SqlClient;
using System.Data;

namespace FestFlow.Backend.API.Resources
{
    public class DbHelper
    {

        public DbHelper(IConfiguration configuration)
        {

        }


        public static IDbConnection GetDbConnection(IConfiguration configuration)
        {
            string connectionString = configuration.GetConnectionString("FestFlow") ?? string.Empty;
            return new SqlConnection(connectionString);
        }
    }
}
