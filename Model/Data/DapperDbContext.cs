using System.Data;
using System.Data.SqlClient;


namespace dapperdemo.Model.Data
{
    public class DapperDbContext
    {
        private readonly IConfiguration _configuration;
        private readonly string connectionString;

        public DapperDbContext(IConfiguration configuration)
        {
            this._configuration = configuration;
            this.connectionString = this._configuration.GetConnectionString("connection");
        }

        public IDbConnection CreateConnection() => new SqlConnection(connectionString);
    }
}

