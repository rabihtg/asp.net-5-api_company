using PersonalProjectClassLibrary.Dto;
using PersonalProjectClassLibrary.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PersonalProjectClassLibrary.DataServices
{
    public interface IEmployeeData
    {
        Task DeleteEmployee(Guid id);
        Task<EmployeeVM> GetEmployee(Guid id);
        Task<IEnumerable<EmployeeVM>> GetEmployees();
        Task<IEnumerable<EmployeeWithInfoVM>> GetEmployeesWithInfo();
        Task InsertEmployee(InsertEmployeeDto employeeDto);
        Task UpdateEmployee(Guid id, UpdateEmployeeDto employeeDto);
    }
}