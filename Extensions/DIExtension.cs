using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using SPS.Core.Helper;
using SPS.Core.Helper.EmailSender;
using SPS.Core.Helper.Photos;
using SPS.Data.Repositories;
using SPS.Data.UnitOfWork;
using System.Reflection;

namespace SPS.API.Extensions
{
    public static class DIExtension
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IPageList, PageList>();
            services.AddTransient<IEmailSenderService, EmailSenderService>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<IPhotoAccessor, PhotoAccessor>();


            services.Scan(scan =>
            {
                scan.FromAssemblies(Assembly.Load("SPS.Service"))
                    .AddClasses(classes =>
                    {
                        classes.Where(type => type.Namespace.Contains("Services"));
                    })
                    .AsImplementedInterfaces()
                    .WithScopedLifetime();
            });

            services.Scan(scan =>
            {
                scan.FromAssemblies(Assembly.Load("SPS.Data"))
                    .AddClasses(classes =>
                    {
                        classes.Where(type => type.Namespace.Contains("Repositories"));
                    })
                    .AsImplementedInterfaces()
                    .WithScopedLifetime();
            });
        }
    }
}
