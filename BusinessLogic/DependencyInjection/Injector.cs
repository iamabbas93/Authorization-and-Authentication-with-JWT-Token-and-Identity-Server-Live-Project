using BusinessLogic.Interface;
using BusinessLogic.Repository;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.DependencyInjection
{
    public static class Injector
    {
        public static void Register(this IServiceCollection services)
        {
            services.AddTransient<ISettings, SettingsRepo>();
            services.AddTransient<IFacilities, FacilitiesRepo>();
        }
        }
}
