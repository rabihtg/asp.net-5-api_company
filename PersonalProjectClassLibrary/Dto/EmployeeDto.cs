using PersonalProjectClassLibrary.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalProjectClassLibrary.Dto
{
    public record InsertEmployeeDto
    {
        [Required]
        [MinLength(5)]
        [MaxLength(250)]
        public string FullName { get; init; }

        [Required]
        [MinLength(5)]
        [MaxLength(250)]
        public string Position { get; init; }

        public int? RoleId { get; init; }

        [Required]
        public decimal Salary { get; init; }

        [Required]
        [RegularExpression(@"(^[a-zA-Z0-9]{1,}([!#$%&'*+-/=_`?^{|.][a-zA-Z0-9]{1,})*?)+@([a-zA-Z0-9]([-.][a-zA-Z0-9])*){1,}\.[a-zA-Z]{2,3}$")]
        public string Email { get; init; }

        public string CellPhoneNumber { get; init; }

        public string City { get; init; }

        public string Street { get; init; }

        public List<Guid> DepartmentIds { get; init; }
    }
    public record UpdateEmployeeDto
    {
        [Required]
        [MinLength(5)]
        [MaxLength(250)]
        public string FullName { get; init; }

        [Required]
        [MinLength(5)]
        [MaxLength(250)]
        public string Position { get; init; }

        public int? RoleId { get; init; }

        [Required]
        public decimal Salary { get; init; }

        [Required]
        [RegularExpression(@"(^[a-zA-Z0-9]{1,}([!#$%&'*+-/=_`?^{|.][a-zA-Z0-9]{1,})*?)+@([a-zA-Z0-9]([-.][a-zA-Z0-9])*){1,}\.[a-zA-Z]{2,3}$")]
        public string Email { get; init; }

        public string CellPhoneNumber { get; init; }
    }

}
