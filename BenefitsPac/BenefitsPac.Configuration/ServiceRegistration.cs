﻿using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using System.Reflection;

namespace BenefitsPac.Configuration
{
    public class ServiceRegistration
    {
        public void ConfigureProjectServices(IServiceCollection services)
        {
            var Assemblies = new[]
            {
                Assembly.Load("OviApi"),
                Assembly.Load("OviApi.DataAccess"),
                Assembly.Load("OviApi.Manufacture"),
                Assembly.Load("OviApi.Transport")
            };

            foreach (var assembly in Assemblies)
            {
                var registrations =
                from type in assembly.GetExportedTypes()
                from i in type.GetInterfaces()
                where type.GetInterfaces().Any()
                select new { Service = i, Implementation = type };

                foreach (var reg in registrations)
                {
                    services.AddTransient(reg.Service, reg.Implementation);
                }
            }
        }
    }
}
