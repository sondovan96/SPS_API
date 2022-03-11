using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using SPS.API.Extensions;
using SPS.Core.Extensions;
using SPS.Core.Models.Account;
using SPS.Service.Accounts.Mapper;
using SPS.Service.Categorys.Mapper;
using SPS.Service.Orders.Mapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace SPS_API
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
            services.AddDb(Configuration);

            services.AddServices();

            services.AddControllers();

            services.AddCORSExtension();

            services.ConfigureAutoMapper();

            //add extension JWT
            services.AddJWT(configuration: Configuration);

            //add extension Swagger
            services.AddVersioning();

            services.AddOptions();

            services.AddMediatR(AppDomain.CurrentDomain.GetAssemblies());
            //Register AutoMapper
            services.AddAutoMapper(typeof(AccountRequestMapper).Assembly);
            services.AddAutoMapper(typeof(CategoryRequestMapper).Assembly);
            services.AddAutoMapper(typeof(OrderMapper).Assembly);
            services.AddAutoMapper(typeof(Startup));

            //Config Options
            services.Configure<JwtOptions>(Configuration.GetSection(JwtOptions.Key));
            services.Configure<GmailOption>(Configuration.GetSection(GmailOption.Key));
            services.Configure<YandexOption>(Configuration.GetSection(YandexOption.Key));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

                app.UseSwagger();

                app.UseSwaggerUI(options =>
                {
                    options.SwaggerEndpoint("/swagger/v1/swagger.json", "Web API v1");
                });
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
