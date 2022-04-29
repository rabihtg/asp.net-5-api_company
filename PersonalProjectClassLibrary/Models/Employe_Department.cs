using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalProjectClassLibrary.Models
{
    public record Employe_Department
    {
        public int Id { get; init; }
        public Guid DepartmentId { get; init; }
        public Guid EmployeeId { get; init; }
    }
}
