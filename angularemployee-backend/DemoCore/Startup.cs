using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DemoCore.Business;
using DemoCore.DBContext;
using DemoCore.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace DemoCore
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
            //Lưu lại configuration values
            services.Configure<IConfiguration>(Configuration);

            //Biến thành API keys
            services.ConfigureAPIServices();

            //Sử dụng DBContext chung cho 1 source => Dùng cái này
            services.AddDbContext<CoreContext>(opt => opt.UseSqlServer(Configuration["DataConnectionString"]));

            //Thêm Business (Phụ thuộc Services + DBContext)
            services.AddScoped<EmployeeBusiness>();
            services.AddScoped<DepartmentBusiness>();

            //Thêm Controllers files (Phụ thuộc Business)
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.ConfigureApiApp("");
        }


    }
}
