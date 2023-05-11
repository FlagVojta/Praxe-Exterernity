using Dapper;
using DataAccessLibrary.Interfaces;
using DataAccessLibrary.Models;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Reflection.Metadata;
using System.Text.Json;

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

        public async Task<T> LoadOne<T,U>(string sql, U parametr)
        {
            string connectionString = _config.GetConnectionString(ConnectionStringName);

            using (IDbConnection connect = new SqlConnection(connectionString))
            {
                var data = await connect.QueryFirstAsync<T>(sql, parametr);
               
                return data;
            }
        }

    }
}