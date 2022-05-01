using PersonalProjectClassLibrary.Dto;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PersonalProjectClassLibrary.DataAccess
{
    public interface ISqlDataAccess
    {
        Task<IEnumerable<T>> LoadData<T, U>(string storedProc, U parameters, string connectionId = "Default");

        Task<IEnumerable<TFirst>> LoadWithOneRelation<TFirst, TSecond, U>(string storedProc, Func<TFirst, TSecond, TFirst> mapFunc, U parameters, string splitCol = "Id", string connectionId = "Default");

        Task<IEnumerable<TFirst>> LoadWithTwoRelations<TFirst, TSecond, TThird, U>(string storedProc, Func<TFirst, TSecond, TThird, TFirst> mapFunc, U parameters, string splitCol = "Id, Id", string connectionId = "Default");

        Task<IEnumerable<TFirst>> LoadWithThreeRelations<TFirst, TSecond, TThird, TFourth, U>(string storedProc,
            Func<TFirst, TSecond, TThird, TFourth, TFirst> mapFunc, U parameters, string splitCol = "Id, Id, Id", string connectionId = "Default");

        Task SaveData<T>(string storedProc, T parameters, string connectionId = "Default");

        Task InsertEmployee(InsertEmployeeDto employee, Guid employeeId, string connectionId = "Default");
    }
}