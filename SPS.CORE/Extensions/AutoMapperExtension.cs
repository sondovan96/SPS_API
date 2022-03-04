using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using SPS.Core.Mapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace SPS.Core.Extensions
{
    public static class AutoMapperExtension
    {
        public static void ConfigureAutoMapper(this IServiceCollection services)
        {
            services.AddAutoMapper(config =>
            {
                var files = (typeof(AccountMapper).Assembly)
                    .GetTypes()
                    .Where(t => typeof(Profile).IsAssignableFrom(t));

                foreach (var file in files)
                {
                    config.AddProfile(Activator.CreateInstance(file) as Profile);
                }
            });

        }
    }
}
