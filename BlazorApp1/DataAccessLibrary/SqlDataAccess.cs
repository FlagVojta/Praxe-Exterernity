using Dapper;
using DataAccessLibrary.Interfaces;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace DataAccessLibrary
{
    public class SqlDataAccess : ISqlDataAccess
    {
        private readonly IConfiguration _config;

        public string ConnectionStringName { get; set; } = "Default";

        public SqlDataAccess(IConfiguration config)
        {
            _config = config;
        }

        public async Task<List<T>> LoadData<T, U>(string sql, U parametrs)
        {
            string connectionString = _config.GetConnectionString(ConnectionStringName);

            using (IDbConnection connect = new SqlConnection(connectionString))
            {
                var data = await connect.QueryAsync<T>(sql, parametrs);

                return data.ToList();
            }

        }

        public async Task SaveData<T>(string sql, T parametrs)
        {
            string connectionString = _config.GetConnectionString(ConnectionStringName);

            using (IDbConnection connect = new SqlConnection(connectionString))
            {
                await connect.ExecuteAsync(sql, parametrs);
            }
        }

    }
}