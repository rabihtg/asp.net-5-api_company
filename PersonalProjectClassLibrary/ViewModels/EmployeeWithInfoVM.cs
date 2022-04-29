using PersonalProjectClassLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalProjectClassLibrary.ViewModels
{
    public class EmployeeWithInfoVM
    {
        public string FullName { get; set; }

        public string Position { get; set; }

        public string RoleName { get; set; }

        public string AllowedActions { get; set; }

        public decimal Salary { get; set; }

        public string Email { get; set; }

        public string CellPhoneNumber { get; set; }

        public List<string> AddressNames { get; set; }

        public List<string> DepartmentNames { get; set; }
    }
}
