using Microsoft.Extensions.DependencyInjection;
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
                Assembly.Load("BenefitsPac"),
                Assembly.Load("BenefitsPac.DataAccess"),
                Assembly.Load("BenefitsPac.Business"),
                Assembly.Load("BenefitsPac.Service")
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
