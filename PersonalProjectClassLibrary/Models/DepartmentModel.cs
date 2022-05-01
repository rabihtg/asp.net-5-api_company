using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalProjectClassLibrary.Models
{
    public record DepartmentModel
    {
        public Guid Id { get; init; }
        public string Name { get; init; }

        public List<EmployeeModel> Employees { get; init; }
    }
}
