using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalProjectClassLibrary.Migrations
{
    [Migration(20220429000000, "CreateTables")]
    public class Migration_20220429000000 : Migration
    {
        public override void Up()
        {
            Create.Table(TableNames.DepartmentTable)
                .WithColumn("Id").AsGuid().PrimaryKey()
                .WithColumn("Name").AsString().Unique();

            Create.Table(TableNames.RoleTable)
                .WithColumn("Id").AsInt32().PrimaryKey().Identity()
                .WithColumn("Name").AsString().Unique()
                .WithColumn("AllowedActions").AsInt32().Unique();

            Create.Table(TableNames.EmployeeTable)
                .WithColumn("Id").AsGuid().PrimaryKey()
                .WithColumn("FullName").AsString()
                .WithColumn("Position").AsString()
                .WithColumn("DateStarted").AsDateTimeOffset()
                .WithColumn("Salary").AsDecimal()
                .WithColumn("Email").AsString().Unique()
                .WithColumn("CellPhoneNumber").AsString()
                .WithColumn("RoleId").AsInt32().Nullable().ForeignKey(TableNames.RoleTable, "Id").OnDeleteOrUpdate(Rule.SetNull);

            Create.Table(TableNames.AddressTable)
                .WithColumn("Id").AsGuid().PrimaryKey()
                .WithColumn("City").AsString()
                .WithColumn("Street").AsString().Nullable()
                .WithColumn("EmployeeId").AsGuid().ForeignKey(TableNames.EmployeeTable, "Id").OnDeleteOrUpdate(Rule.Cascade);

            Create.Table(TableNames.Employee_DepartmentTable)
                .WithColumn("Id").AsInt32().PrimaryKey().Identity()
                .WithColumn("EmployeeId").AsGuid().ForeignKey(TableNames.EmployeeTable, "Id").OnDeleteOrUpdate(Rule.Cascade)
                .WithColumn("DepartmentId").AsGuid().ForeignKey(TableNames.DepartmentTable, "Id").OnDeleteOrUpdate(Rule.Cascade);
        }

        public override void Down()
        {

            Delete.Table(TableNames.Employee_DepartmentTable);
            Delete.Table(TableNames.AddressTable);
            Delete.Table(TableNames.EmployeeTable);

            Delete.Table(TableNames.RoleTable);
            Delete.Table(TableNames.DepartmentTable);


        }
    }
}
