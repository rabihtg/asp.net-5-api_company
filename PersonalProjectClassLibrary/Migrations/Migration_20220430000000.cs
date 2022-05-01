using FluentMigrator;
using PersonalProjectClassLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalProjectClassLibrary.Migrations
{
    [Migration(20220430000000, "SeedDataBase")]
    public class Migration_20220430000000 : Migration
    {
        public override void Up()
        {
            Insert.IntoTable(TableNames.RoleTable)
                .Row(new { Id = 1, Name = "Admin", AllowedActions = AllowedActions.readWrite })
                .Row(new { Id = 2, Name = "User", AllowedActions = AllowedActions.read })
                .Row(new { Id = 3, Name = "Control", AllowedActions = AllowedActions.delete })
                .Row(new { Id = 4, Name = "Super Admin", AllowedActions = AllowedActions.readWriteDeleteUpdate })
                .Row(new { Id = 5, Name = "Division Manager", AllowedActions = AllowedActions.readWriteDelete })
                .Row(new { Id = 6, Name = "Captain", AllowedActions = AllowedActions.write });

            var depId1 = Guid.NewGuid();
            var depId2 = Guid.NewGuid();
            var depId3 = Guid.NewGuid();
            var depId4 = Guid.NewGuid();
            var depId5 = Guid.NewGuid();

            Insert.IntoTable(TableNames.DepartmentTable)
                .Row(new { Id = depId1, Name = "Accounting" })
                .Row(new { Id = depId2, Name = "H.R" })
                .Row(new { Id = depId3, Name = "I.T" })
                .Row(new { Id = depId4, Name = "Marketing" })
                .Row(new { Id = depId5, Name = "Production" });



            var empId1 = Guid.NewGuid();
            var empId2 = Guid.NewGuid();
            var empId3 = Guid.NewGuid();
            var empId4 = Guid.NewGuid();
            var empId5 = Guid.NewGuid();
            var empId6 = Guid.NewGuid();
            var empId7 = Guid.NewGuid();
            var empId8 = Guid.NewGuid();
            var empId9 = Guid.NewGuid();
            var empId10 = Guid.NewGuid();
            var empId11 = Guid.NewGuid();

            Insert.IntoTable(TableNames.EmployeeTable)
                .Row(new
                {
                    Id = empId1,
                    FullName = "Rabih Harb",
                    Position = "Associate",
                    DateStarted = DateTimeOffset.UtcNow.AddMonths(-5),
                    Salary = 5000,
                    Email = "rabih@work.com",
                    CellPhoneNumber = "ad/fd abde",
                    RoleId = 1
                });
            Insert.IntoTable(TableNames.EmployeeTable)
                .Row(new
                {
                    Id = empId2,
                    FullName = "Hasan Harb",
                    Position = "Junior",
                    DateStarted = DateTimeOffset.UtcNow.AddMonths(-5),
                    Salary = 2000,
                    Email = "hasan@work.com",
                    CellPhoneNumber = "ra/abd abc",
                    RoleId = 2
                });
            Insert.IntoTable(TableNames.EmployeeTable)
                .Row(new
                {
                    Id = empId3,
                    FullName = "Jamal Harb",
                    Position = "Junior",
                    DateStarted = DateTimeOffset.UtcNow.AddMonths(-5),
                    Salary = 2000,
                    Email = "jamal@work.com",
                    CellPhoneNumber = "rad/asd fdf",
                    RoleId = 3
                });
            Insert.IntoTable(TableNames.EmployeeTable)
                .Row(new
                {
                    Id = empId4,
                    FullName = "Zeina Harb",
                    Position = "Senior",
                    DateStarted = DateTimeOffset.UtcNow.AddMonths(-10),
                    Salary = 3000,
                    Email = "zeina@work.com",
                    CellPhoneNumber = "fdf/fdfsd fdfdf",
                    RoleId = 4
                });
            Insert.IntoTable(TableNames.EmployeeTable)
                .Row(new
                {
                    Id = empId5,
                    FullName = "John Doe",
                    Position = "Senior Partner",
                    DateStarted = DateTimeOffset.UtcNow.AddMonths(-2),
                    Salary = 10000,
                    Email = "John@work.com",
                    CellPhoneNumber = "aw/fdsa fdfe",
                    RoleId = 5
                });
            Insert.IntoTable(TableNames.EmployeeTable)
                .Row(new
                {
                    Id = empId6,
                    FullName = "Jake Peralta",
                    Position = "Associate",
                    DateStarted = DateTimeOffset.UtcNow.AddMonths(-30),
                    Salary = 5000,
                    Email = "Jake@work.com",
                    CellPhoneNumber = "ws/sadf fdfds",
                    RoleId = 6
                });
            Insert.IntoTable(TableNames.EmployeeTable)
                .Row(new
                {
                    Id = empId7,
                    FullName = "Blake Drake",
                    Position = "Senior",
                    DateStarted = DateTimeOffset.UtcNow.AddMonths(-4),
                    Salary = 3000,
                    Email = "Blake@work.com",
                    CellPhoneNumber = "ab/zzz xxx",
                    RoleId = 2
                });
            Insert.IntoTable(TableNames.EmployeeTable)
                .Row(new
                {
                    Id = empId8,
                    FullName = "Employee Some",
                    Position = "Associate",
                    DateStarted = DateTimeOffset.UtcNow.AddMonths(-1),
                    Salary = 4000,
                    Email = "Some@work.com",
                    CellPhoneNumber = "71/xx yy yy ",
                    RoleId = 3
                });
            Insert.IntoTable(TableNames.EmployeeTable)
                .Row(new
                {
                    Id = empId9,
                    FullName = "Employee SomeTwo",
                    Position = "Associate",
                    DateStarted = DateTimeOffset.UtcNow.AddMonths(-9),
                    Salary = 4000,
                    Email = "SomeTwo@work.com",
                    CellPhoneNumber = "71/6xx 0xx",
                    RoleId = 4
                });
            Insert.IntoTable(TableNames.EmployeeTable)
                .Row(new
                {
                    Id = empId10,
                    FullName = "Employee AnotherTwo",
                    Position = "Senior",
                    DateStarted = DateTimeOffset.UtcNow.AddMonths(-45),
                    Salary = 10000,
                    Email = "anotherTwo@work.com",
                    CellPhoneNumber = "fdsd/xx yy zz",
                    RoleId = 5
                });
            Insert.IntoTable(TableNames.EmployeeTable)
                .Row(new
                {
                    Id = empId11,
                    FullName = "Sara Wilde",
                    Position = "Associate",
                    DateStarted = DateTimeOffset.UtcNow.AddMonths(-19),
                    Salary = 5000,
                    Email = "sara@work.com",
                    CellPhoneNumber = "xr/rrsa ssdtd",
                    RoleId = 4
                });

            var addId1 = Guid.NewGuid();
            var addId2 = Guid.NewGuid();
            var addId3 = Guid.NewGuid();
            var addId4 = Guid.NewGuid();
            var addId5 = Guid.NewGuid();
            var addId6 = Guid.NewGuid();
            var addId7 = Guid.NewGuid();
            var addId8 = Guid.NewGuid();
            var addId9 = Guid.NewGuid();
            var addId10 = Guid.NewGuid();
            var addId11 = Guid.NewGuid();

            Insert.IntoTable(TableNames.AddressTable)
                .Row(new { Id = addId1, City = "Nabatieh", Street = "11th", EmployeeId = empId1 })
                .Row(new { Id = addId2, City = "Beiurtut", Street = "12th", EmployeeId = empId2 })
                .Row(new { Id = addId3, City = "Saida", Street = "10th", EmployeeId = empId3 })
                .Row(new { Id = addId4, City = "Beirut", Street = "1st", EmployeeId = empId4 })
                .Row(new { Id = addId5, City = "Tyre", Street = "3rd", EmployeeId = empId5 })
                .Row(new { Id = addId6, City = "Jbeil", Street = "4th", EmployeeId = empId10 })
                .Row(new { Id = addId7, City = "Jounieh", Street = "13th", EmployeeId = empId11 })
                .Row(new { Id = addId8, City = "Nabatieh", Street = "8th", EmployeeId = empId1 })
                .Row(new { Id = addId9, City = "Jounieh", Street = "2nd", EmployeeId = empId8 })
                .Row(new { Id = addId10, City = "Jbeil", Street = "1st", EmployeeId = empId1 })
                .Row(new { Id = addId11, City = "Saida", Street = "20th", EmployeeId = empId7 });

            Insert.IntoTable(TableNames.Employee_DepartmentTable)
                .Row(new { EmployeeId = empId1, DepartmentId = depId1 })
                .Row(new { EmployeeId = empId11, DepartmentId = depId1 })
                .Row(new { EmployeeId = empId10, DepartmentId = depId1 })
                .Row(new { EmployeeId = empId8, DepartmentId = depId1 })
                .Row(new { EmployeeId = empId1, DepartmentId = depId2 })
                .Row(new { EmployeeId = empId2, DepartmentId = depId2 })
                .Row(new { EmployeeId = empId3, DepartmentId = depId2 })
                .Row(new { EmployeeId = empId4, DepartmentId = depId3 })
                .Row(new { EmployeeId = empId5, DepartmentId = depId3 })
                .Row(new { EmployeeId = empId6, DepartmentId = depId4 })
                .Row(new { EmployeeId = empId7, DepartmentId = depId4 })
                .Row(new { EmployeeId = empId8, DepartmentId = depId4 })
                .Row(new { EmployeeId = empId9, DepartmentId = depId5 })
                .Row(new { EmployeeId = empId10, DepartmentId = depId5 })
                .Row(new { EmployeeId = empId11, DepartmentId = depId5 })
                .Row(new { EmployeeId = empId4, DepartmentId = depId5 })
                .Row(new { EmployeeId = empId9, DepartmentId = depId5 });
        }

        public override void Down()
        {
            Delete.FromTable(TableNames.Employee_DepartmentTable).AllRows();
            Delete.FromTable(TableNames.AddressTable).AllRows();
            Delete.FromTable(TableNames.EmployeeTable).AllRows();
            Delete.FromTable(TableNames.RoleTable).AllRows();
            Delete.FromTable(TableNames.DepartmentTable).AllRows();
        }
    }
}
