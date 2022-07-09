using Blazor_E_Commerce.DataStore.SQL.Dapper.Helpers.Interface;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blazor_E_Commerce.DataStore.SQL.Dapper.Helpers
{
    public class DataAccess : IDataAccess
    {
        private readonly string connectionString = null!;

        public DataAccess(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public List<T> Query<T, U>(string sql, U parameter)
        {
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                return connection.Query<T>(sql, parameter).ToList();
            }
        }

        public T QuerySingle<T, U>(string sql, U parameter)
        {
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                return connection.QuerySingle<T>(sql, parameter);
            }
        }

        public void ExecuteCommand<T>(string sql, T parameter)
        {
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                connection.Execute(sql, parameter);
            }
        }
    }
}
