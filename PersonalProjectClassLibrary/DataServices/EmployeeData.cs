using PersonalProjectClassLibrary.DataAccess;
using PersonalProjectClassLibrary.Dto;
using PersonalProjectClassLibrary.Models;
using PersonalProjectClassLibrary.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalProjectClassLibrary.DataServices
{
    public class EmployeeData
    {
        private readonly ISqlDataAccess _db;

        public EmployeeData(ISqlDataAccess db)
        {
            _db = db;
        }

        public async Task<IEnumerable<EmployeeModel>> GetEmployees()
        {
            return await _db.LoadData<EmployeeModel, dynamic>("dbo.spEmpolyee_GetAll", new { });
        }

        public async Task<EmployeeModel> GetEmployee(Guid id)
        {
            return (await _db.LoadData<EmployeeModel, dynamic>("dbo.spEmpolyee_Get", new { Id = id })).FirstOrDefault();
        }

        public async Task<IEnumerable<EmployeeWithInfoVM>> GetEmployeesWithInfo()
        {
            return await _db.LoadWithThreeRelations<EmployeeWithInfoVM, RoleModel, AddressModel, DepartmentModel, dynamic>(
                "dbo.spEmpolyeeWithInfo_GetAll", MapEmployeeRoleAdressDepartment, new { });
        }

        public async Task InsertEmployee(InsertEmployeeDto employeeDto)
        {
            await _db.SaveData("dbo.spEmployee_Insert", employeeDto);
        }

        public async Task UpdateEmployee(UpdateEmployeeDto employeeDto)
        {
            await _db.SaveData("dbo.spEmployee_Update", employeeDto);
        }

        public async Task DeleteEmployee(Guid id)
        {
            await _db.SaveData("dbo.spEmployee_Update", new { Id = id });
        }

        private static EmployeeWithInfoVM MapEmployeeRoleAdressDepartment(EmployeeWithInfoVM employee, RoleModel role, AddressModel adress, DepartmentModel department)
        {
            employee.AddressNames.Add(adress.ToString());
            employee.RoleName = role.Name;
            employee.DepartmentNames.Add(department.DepartmentName);
            return employee;
        }
    }
}
