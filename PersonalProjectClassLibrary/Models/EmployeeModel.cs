using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalProjectClassLibrary.Models
{
    public record EmployeeModel
    {
        public Guid Id { get; init; }

        public string FullName { get; init; }

        public string Position { get; init; }

        public DateTimeOffset DateStarted { get; init; }

        public decimal Salary { get; init; }

        public string Email { get; init; }

        public string CellPhoneNumber { get; init; }

        public int? RoleId { get; init; }

        public RoleModel Role { get; init; }

        public List<AddressModel> Addresses { get; init; }

        public List<DepartmentModel> Departments { get; init; }
    }
}
