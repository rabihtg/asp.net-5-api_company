using Dapper;
using PersonalProjectClassLibrary.DataAccess;
using PersonalProjectClassLibrary.Dto;
using PersonalProjectClassLibrary.Models;
using PersonalProjectClassLibrary.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalProjectClassLibrary.DataServices
{
    public class EmployeeData : IEmployeeData
    {
        // TODO - Continue in update Employee Logic, Write update Adress procedure and check Employee update procedure
        // TODO - Revisit EmployeeWithInfoLogic
        // TODO - Consider on adress per employee or Make a way to add many adresses with employee
        // TODO - Check to see if commandType can be set dynamicaly

        private readonly ISqlDataAccess _db;

        public EmployeeData(ISqlDataAccess db)
        {
            _db = db;
        }

        public async Task<IEnumerable<EmployeeVM>> GetEmployees()
        {
            return await _db.LoadData<EmployeeVM, dynamic>("dbo.spEmployee_GetAll", new { });
        }

        public async Task<EmployeeVM> GetEmployee(Guid id)
        {
            return (await _db.LoadData<EmployeeVM, dynamic>("dbo.spEmployee_Get", new { Id = id })).FirstOrDefault();
        }

        public async Task<IEnumerable<EmployeeWithInfoVM>> GetEmployeesWithInfo()
        {
            var result = await _db.LoadWithThreeRelations<EmployeeWithInfoVM, RoleModel, AddressModel, DepartmentModel, dynamic>(
                "dbo.spEmployeeWithInfo_GetAll", MapEmployeeRoleAdressDepartment, new { });

            return result.GroupBy(e => e.FullName).Select(g =>
            {
                var gE = g.First();
                gE.DepartmentNames = g.Select(g => g.DepartmentNames.FirstOrDefault()).Distinct().ToList();
                gE.AddressNames = g.Select(g => g.AddressNames.FirstOrDefault()).Distinct().ToList();
                return gE;
            });
        }

        public async Task InsertEmployee(InsertEmployeeDto employeeDto)
        {
            await _db.InsertEmployee(employeeDto, Guid.NewGuid());
        }

        public async Task UpdateEmployee(Guid id, UpdateEmployeeDto employeeDto)
        {
            var dp = new DynamicParameters();

            dp.AddDynamicParams(employeeDto);
            dp.Add("Id", id);

            await _db.SaveData("dbo.spEmployee_Update", dp);
        }

        public async Task DeleteEmployee(Guid id)
        {
            await _db.SaveData("dbo.spEmployee_Update", new { Id = id });
        }

        private static EmployeeWithInfoVM MapEmployeeRoleAdressDepartment(EmployeeWithInfoVM employee, RoleModel role, AddressModel adress, DepartmentModel department)
        {
            employee.AddressNames.Add(adress?.ToString());
            employee.RoleName = role?.Name;
            employee.AllowedActions = role?.AllowedActions.ToString();
            employee.DepartmentNames.Add(department?.Name);
            return employee;
        }
    }
}
