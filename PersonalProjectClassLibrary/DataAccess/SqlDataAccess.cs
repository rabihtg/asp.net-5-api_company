using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalProjectClassLibrary.DataAccess
{
    public class SqlDataAccess : ISqlDataAccess
    {
        private readonly IConfiguration _config;
        public SqlDataAccess(IConfiguration config)
        {
            _config = config;
        }

        public Task<IEnumerable<T>> LoadData<T, U>(string storedProc,
            U parameters, string connectionId = "Default")
        {
            using var conn = new SqlConnection(_config.GetConnectionString(connectionId));
            return conn.QueryAsync<T>(storedProc, parameters, commandType: CommandType.StoredProcedure);
        }

        public Task SaveData<T>(string storedProc,
            T parameters, string connectionId = "Default")
        {
            using var conn = new SqlConnection(_config.GetConnectionString(connectionId));
            return conn.ExecuteAsync(storedProc, parameters, commandType: CommandType.StoredProcedure);
        }

        public Task<IEnumerable<TFirst>> LoadWithOneRelation<TFirst, TSecond, U>(string storedProc,
            Func<TFirst, TSecond, TFirst> mapFunc, U parameters, string splitCol = "Id", string connectionId = "Default")
        {
            using var conn = new SqlConnection(_config.GetConnectionString(connectionId));
            return conn.QueryAsync(storedProc, mapFunc, parameters, splitOn: splitCol, commandType: CommandType.StoredProcedure);
        }

        public Task<IEnumerable<TFirst>> LoadWithTwoRelations<TFirst, TSecond, TThird, U>(string storedProc,
            Func<TFirst, TSecond, TThird, TFirst> mapFunc, U parameters, string splitCol = "Id, Id", string connectionId = "Default")
        {
            using var conn = new SqlConnection(_config.GetConnectionString(connectionId));
            return conn.QueryAsync(storedProc, mapFunc, parameters, splitOn: splitCol, commandType: CommandType.StoredProcedure);
        }

        public Task<IEnumerable<TFirst>> LoadWithThreeRelations<TFirst, TSecond, TThird, TFourth, U>(string storedProc,
            Func<TFirst, TSecond, TThird, TFourth, TFirst> mapFunc, U parameters, string splitCol = "Id, Id, Id", string connectionId = "Default")
        {
            using var conn = new SqlConnection(_config.GetConnectionString(connectionId));
            return conn.QueryAsync(storedProc, mapFunc, parameters, splitOn: splitCol, commandType: CommandType.StoredProcedure);
        }
    }
}
