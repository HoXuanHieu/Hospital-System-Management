using HospitalManagementSystem.Data;
using HospitalManagementSystem.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementSystem
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
            //context 
            services.AddDbContext<HospitalManagermentContext>(otp => otp.UseSqlServer(Configuration.GetConnectionString("DbConnection")));
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            //scoped
            services.AddScoped<IBloodTestInforRepo, BloodTestInforRepo>();
            services.AddScoped<IPatientRepo, PatientRepo>();
            services.AddScoped<IDishargeRepo, DischargeRepo>();
            services.AddScoped<IInPatientRepo, InPataitRepo>();
            services.AddScoped<IOutPatientRepo, OutPatientRepo>();
            services.AddScoped<IPharmacyInforRepo, PharmacyInforRepo>();
            services.AddScoped<IStaffRepo, StaffRepo>();
            services.AddScoped<ISurgeryInforRepo, SurgeryInforRepo>();
            services.AddScoped<ISurgeryRequestRepo, SurguryRequestRepo>();
            services.AddScoped<IUrineTestInforRepo, UrineTestInforRepo>();
            services.AddScoped<IMedicineRepo, MedicineRepo>();
            //jwt 
            services.AddAuthentication(option =>
            {
                option.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                option.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }
           ).AddJwtBearer(options =>
           {
               options.TokenValidationParameters = new TokenValidationParameters
               {
                   ValidateIssuer = true,
                   ValidateAudience = true,
                   ValidateLifetime = true,
                   ValidateIssuerSigningKey = true,
                   ValidIssuer = Configuration["Jwt:Issuer"],
                   ValidAudience = Configuration["Jwt:Audience"],
                   IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:Key"]))
               };
           });
            services.AddMvc();
            services.AddCors();
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "HopitalManagementSystem", Version = "v1" });
            });
        }
        //"HopitalManagementSystem v1"
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCors(option => option.WithOrigins("http://localhost:4200").AllowAnyMethod().AllowAnyHeader());
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "HopitalManagementSystem v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
