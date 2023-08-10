using EP_Task.Domain.IRepository;
using EP_Task.Infrastructure.Repository;
using EP_Task.Infrastructure.Utility;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EP_Task.Infrastructure
{
    public static class InfraDIRegister
    {

        public static void AddInfra(this IServiceCollection services)
        {
            services.AddSingleton<EncriptionUtility>();
            services.AddScoped<IEmployeeSalaryRepository, EmployeeSalaryRepository>();


        }
    }
}
