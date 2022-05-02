using FluentMigrator.Runner;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using PersonalProjectClassLibrary.DataAccess;
using PersonalProjectClassLibrary.DataServices;
using PersonalProjectClassLibrary.Migrations;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using PersonalProjectClassLibrary.JWT;

namespace PersonalProjectAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();

            var key = Encoding.ASCII.GetBytes(Configuration["JWT:Key"]);

            var tokenValParams = new TokenValidationParameters
            {
                ValidateAudience = false,
                ValidateIssuer = false,
                ValidateIssuerSigningKey = true,
                ValidateLifetime = false,
                IssuerSigningKey = new SymmetricSecurityKey(key)
            };

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(opt =>
                {
                    opt.SaveToken = true;
                    opt.TokenValidationParameters = tokenValParams;
                });

            services.AddFluentMigratorCore()
                .ConfigureRunner(opt =>
                {
                    opt.AddSqlServer()
                    .WithGlobalConnectionString(Configuration.GetConnectionString("Default"))
                    .ScanIn(typeof(Migration_20220429000000).Assembly)
                    .For.All();
                });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "PersonalProjectAPI", Version = "v1" });
            });

            
            services.AddTransient<IJwtManager, JwtManager>();
            services.AddSingleton(tokenValParams);


            services.AddTransient<IRefreshTokenData, RefreshTokenData>();
            services.AddTransient<ISqlDataAccess, SqlDataAccess>();
            services.AddTransient<IAddressData, AddressData>();
            services.AddTransient<IEmployeeData, EmployeeData>();
            services.AddTransient<IUserData, UserData>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "PersonalProjectAPI v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();
            
            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            //DataBase.EnsureDataBase();
            //app.MigrateDown();
            //app.MigrateUp();
        }
    }
}
