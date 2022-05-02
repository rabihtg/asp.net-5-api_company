using Dapper;
using Microsoft.Extensions.Configuration;
using PersonalProjectClassLibrary.Dto;
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

        public async Task<IEnumerable<T>> LoadData<T, U>(string storedProc,
            U parameters, string connectionId = "Default")
        {
            using var conn = new SqlConnection(_config.GetConnectionString(connectionId));
            return await conn.QueryAsync<T>(storedProc, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task SaveData<T>(string storedProc,
            T parameters, string connectionId = "Default")
        {
            using var conn = new SqlConnection(_config.GetConnectionString(connectionId));
            await conn.ExecuteAsync(storedProc, parameters, commandType: CommandType.StoredProcedure);
        }

        

        public async Task InsertEmployee(InsertEmployeeDto employee, Guid employeeId, string connectionId = "Default")
        {
            var empParams = new DynamicParameters();
            empParams.Add("Id", employeeId);
            empParams.Add("FullName", employee.FullName);
            empParams.Add("Salary", employee.Salary);
            empParams.Add("CellPhoneNumber", employee.CellPhoneNumber);
            empParams.Add("Email", employee.Email);
            empParams.Add("Position", employee.Position);
            empParams.Add("RoleId", employee.RoleId);
            empParams.Add("DateStarted", DateTime.UtcNow);

            var adressParams = new DynamicParameters();

            adressParams.Add("Id", Guid.NewGuid());
            adressParams.Add("EmployeeId", employeeId);
            adressParams.Add("City", employee.City);
            adressParams.Add("Street", employee.Street);

            var bulkEmpDepParams = new List<dynamic>();

            foreach (var id in employee.DepartmentIds)
            {
                bulkEmpDepParams.Add(new
                {
                    EmployeeId = employeeId,
                    DepartmentId = id
                });
            }

            using var conn = new SqlConnection(_config.GetConnectionString(connectionId));
            conn.Open();
            using var trans = conn.BeginTransaction();

            await conn.ExecuteAsync("dbo.spEmployee_Insert", empParams,
                commandType: CommandType.StoredProcedure, transaction: trans);

            await conn.ExecuteAsync("dbo.spAddress_Insert", adressParams,
                commandType: CommandType.StoredProcedure, transaction: trans);

            await conn.ExecuteAsync("dbo.spEmployeeDepartment_Insert", bulkEmpDepParams,
                commandType: CommandType.StoredProcedure, transaction: trans);

            trans.Commit();
        }

        public async Task<IEnumerable<TFirst>> LoadWithOneRelation<TFirst, TSecond, U>(string storedProc,
            Func<TFirst, TSecond, TFirst> mapFunc, U parameters, string splitCol = "Id", string connectionId = "Default")
        {
            using var conn = new SqlConnection(_config.GetConnectionString(connectionId));
            return await conn.QueryAsync(storedProc, mapFunc, parameters, splitOn: splitCol, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<TFirst>> LoadWithTwoRelations<TFirst, TSecond, TThird, U>(string storedProc,
            Func<TFirst, TSecond, TThird, TFirst> mapFunc, U parameters, string splitCol = "Id, Id", string connectionId = "Default")
        {
            using var conn = new SqlConnection(_config.GetConnectionString(connectionId));
            return await conn.QueryAsync(storedProc, mapFunc, parameters, splitOn: splitCol, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<TFirst>> LoadWithThreeRelations<TFirst, TSecond, TThird, TFourth, U>(string storedProc,
            Func<TFirst, TSecond, TThird, TFourth, TFirst> mapFunc, U parameters, string splitCol = "Id, Id, Id", string connectionId = "Default")
        {
            using var conn = new SqlConnection(_config.GetConnectionString(connectionId));
            return await conn.QueryAsync(storedProc, mapFunc, parameters, splitOn: splitCol, commandType: CommandType.StoredProcedure);
        }
    }
}
