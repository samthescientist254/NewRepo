using LoanAppraisalApi.Models;
using LoanAppraisalApi.Models.DataManager;
using LoanAppraisalApi.Models.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;
using System.Reflection;
using System.IO;

namespace LoanAppraisalApi
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

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddDbContext<LoanAppraisalContext>(Options => Options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            //services.AddScoped<IDataRepository>();
            //services.AddScoped<IDataRepository, UserManager>();
            services.AddScoped(typeof(IDataRepository<Users, long>), typeof(UserManager));
            services.AddScoped(typeof(IDataRepository<LoanAppraisalDetails, long>), typeof(LoanAppraisalDetailsManager));
            services.AddScoped(typeof(IDataRepository<Inspection, long>), typeof(InspectionManager));
            services.AddSwaggerGen(c =>
            {
    /*            c.SwaggerDoc("V1", new OpenApiInfo { Title = "Loan Appraisal", Version = "V1" });*/

                c.SwaggerDoc("V1", new OpenApiInfo
                {
                    Version = "V1",
                    Title = "Loan Appraisal",
                    Description = "A loan Appraisal API",
                    TermsOfService = new Uri("https://example.com/terms"),
                    Contact = new OpenApiContact
                    {
                        Name = "Samuel Wainaina",
                        Email = "samthescientist2542gmail.com",
                        Url = new Uri("https://www.linkedin.com/in/samuel-wainaina-71b709177/"),
                    },
                    License = new OpenApiLicense
                    {
                        Name = "Use under LICX",
                        Url = new Uri("https://example.com/license"),
                    }
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

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/V1/swagger.json", "My API V1");
                c.RoutePrefix = string.Empty;
            });


            app.UseMvc();
        }
    }
}
