using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalProjectClassLibrary.Migrations
{
    public static class TableNames
    {
        public static string EmployeeTable { get; } = "Employees";

        public static string RoleTable { get; } = "Roles";

        public static string AddressTable { get; } = "Adresses";

        public static string DepartmentTable { get; } = "Departments";

        public static string Employee_DepartmentTable { get; } = "Employees_Departments";
    }
}
