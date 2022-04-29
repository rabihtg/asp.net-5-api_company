using FluentMigrator.Runner;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalProjectClassLibrary.Migrations
{
    public static class MigrationAppExtensions
    {
        public static void MigrateUp(this IApplicationBuilder app, long versionNumber)
        {
            using var scope = app.ApplicationServices.CreateScope();
            var migrator = scope.ServiceProvider.GetRequiredService<IMigrationRunner>();

            migrator.MigrateUp(versionNumber);
        }

        public static void MigrateUp(this IApplicationBuilder app)
        {
            using var scope = app.ApplicationServices.CreateScope();
            var migrator = scope.ServiceProvider.GetRequiredService<IMigrationRunner>();

            migrator.MigrateUp();
        }

        public static void MigrateDown(this IApplicationBuilder app, long versionNumber)
        {
            using var scope = app.ApplicationServices.CreateScope();
            var migrator = scope.ServiceProvider.GetRequiredService<IMigrationRunner>();

            migrator.MigrateDown(versionNumber);
        }

        public static void MigrateDown(this IApplicationBuilder app)
        {
            using var scope = app.ApplicationServices.CreateScope();
            var migrator = scope.ServiceProvider.GetRequiredService<IMigrationRunner>();

            migrator.MigrateDown(0);
        }
    }
}
