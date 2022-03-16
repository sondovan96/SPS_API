using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using SPS.API.Extensions;
using SPS.Core.Extensions;
using SPS.Core.Models.Account;
using SPS.Core.Models.Photos;
using SPS.Service.Accounts.Mapper;
using SPS.Service.Categories.Mapper;
using SPS.Service.OrderDetails.Mapper;
using SPS.Service.Orders.Mapper;
using SPS.Service.ProductImages.Mapper;
using SPS.Service.Products.Mapper;
using System;


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
            services.AddHttpContextAccessor();

            services.AddDb(Configuration);

            services.AddServices();

            services.AddControllers().AddNewtonsoftJson
                (
                    x => x.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
                );

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
            services.AddAutoMapper(typeof(OrderDetailMapper).Assembly);
            services.AddAutoMapper(typeof(ProductImageMapper).Assembly);
            services.AddAutoMapper(typeof(ProductMapper).Assembly);

            services.AddAutoMapper(typeof(Startup));

            //Config Options
            services.Configure<JwtOptions>(Configuration.GetSection(JwtOptions.Key));
            services.Configure<GmailOption>(Configuration.GetSection(GmailOption.Key));
            services.Configure<YandexOption>(Configuration.GetSection(YandexOption.Key));
            services.Configure<CloudinarySetting>(Configuration.GetSection("Cloudinary"));
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
