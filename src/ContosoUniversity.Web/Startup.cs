using AutoMapper;
using System.Reflection;
using ContosoUniversity.Application.Infrastructure.AutoMapper;
using ContosoUniversity.Application.Validators;
using ContosoUniversity.Infrastructure.DbContexts;
using ContosoUniversity.Infrastructure.Interfaces;
using ContosoUniversity.Infrastructure.Repositories;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ContosoUniversity.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            // Add AutoMapper
            services.AddAutoMapper(typeof(AutoMapperProfile).GetTypeInfo().Assembly);

            services.Configure<CookiePolicyOptions>(options =>
            {
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddScoped(typeof(IAsyncRepository<>), typeof(EfRepository<>));

            services.AddMvc()
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_1)
                .AddFluentValidation(o =>
                {
                    o.RegisterValidatorsFromAssemblyContaining<CourseValidator>();
                    o.RegisterValidatorsFromAssemblyContaining<DepartmentValidator>();
                    o.RegisterValidatorsFromAssemblyContaining<InstructorValidator>();
                    o.RegisterValidatorsFromAssemblyContaining<StudentValidator>();
                }); ;

            services.AddScoped<ISchoolContext>(provider => provider.GetService<SchoolContext>());

            services.AddDbContext<SchoolContext>(options =>
                {
                    options.UseSqlServer(Configuration.GetConnectionString("SchoolContext"));
                    options.EnableDetailedErrors(true);
                    options.EnableSensitiveDataLogging(true);
                });

            // Repositories
            services.AddScoped<ICourseRepository, CourseRepository>();
            services.AddScoped<IDepartmentRepository, DepartmentRepository>();
            services.AddScoped<IEnrollmentRepository, EnrollmentRepository>();
            services.AddScoped<IInstructorRepository, InstructorRepository>();
            services.AddScoped<IStudentRepository, StudentRepository>();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }

            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseMvc();
        }
    }
}
