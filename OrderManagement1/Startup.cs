using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json.Serialization;
using OrderManagement1.Data;
using OrderManagement1.Mappings;
using OrderManagement1.Models;
using OrderManagement1.Repositories;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore;
using Microsoft.OpenApi.Models;
using Serilog;
using Serilog.AspNetCore;

namespace OrderManagement1
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
            
            services.AddLogging(c => c.AddSerilog(dispose: true));

            services.AddAutoMapper(typeof(AutoMapperProfiles));

            services.AddCors();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1).AddJsonOptions(options => 
            options.SerializerSettings.ContractResolver = new DefaultContractResolver());  
            
            services.AddDbContext<OrderManagement81363Context>(options => 
            options.UseSqlServer(Configuration.GetConnectionString("OrderStr")));

            //Auth Db Context
            services.AddDbContext<OrderManagementAuthDbContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("OrderStr")));

            services.AddScoped<ITokenRepository, TokenRepository>();

            services.AddIdentityCore<IdentityUser>()
                .AddRoles<IdentityRole>()
                .AddTokenProvider<DataProtectorTokenProvider<IdentityUser >>("OrderManagement")
                .AddEntityFrameworkStores<OrderManagementAuthDbContext>()
                .AddDefaultTokenProviders();

            services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 6;
                options.Password.RequiredUniqueChars = 1;
            });

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience=true,
                ValidateLifetime=true,
                ValidateIssuerSigningKey=true,
                ValidIssuer=Configuration["Jwt:Issuer"],
                ValidAudience=Configuration["Jwt:Audience"],
                IssuerSigningKey= new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(Configuration["Jwt:Key"]))
            });


            //services.AddSwaggerGen(options =>
            //{
            //    options.SwaggerDoc("v1", new APIInfo
            //    {
            //        Title = "Order Management System",
            //        Version = "V1.0",
            //        Description = "Order Management System developed by Mustafa",
            //        Contact = new APIInfo
            //        {
            //            Name = "Syed Mustafa",
            //            Email = string.Empty,
            //            Url = new Uri("http://localhost:4200"),
            //        },
            //    });                
            //});         

            services.AddSwaggerGen(c => {
                c.SwaggerDoc("v1", new Info { Title = "Order Management System", Version = "v1" });
                c.AddSecurityDefinition("Bearer",
                new ApiKeyScheme
                {
                    In = "header",
                    Description = "Please enter into field the word 'Bearer' following by space and JWT",
                    Name = "Authorization",
                    Type = "apiKey"
                });
                c.AddSecurityRequirement(new Dictionary<string, IEnumerable<string>> {
                { "Bearer", Enumerable.Empty<string>() },
                 });



            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            var loggerConfig = new LoggerConfiguration()
                .Enrich.FromLogContext()
                .WriteTo.File("Logs/log.txt").WriteTo.Console();

            Log.Logger = loggerConfig.CreateLogger();           

            
            app.UseAuthentication();
            //app.UseAuthorization();

            app.UseCors(options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

            app.UseMvc();           

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Order Management System");
            });

            

            //app.UseHttpsRedirection();

        }
    }    
    internal class APIInfo : Info
    {
        public string Title { get; set; }
        public string Version { get; set; }
        public string Description { get; set; }
        public Info Contact { get; set; }
        public string Name { get; internal set; }
        public string Email { get; internal set; }
        public Uri Url { get; internal set; }
    }
}
