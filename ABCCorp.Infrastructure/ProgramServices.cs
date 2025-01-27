using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ABCCorp.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ABCCorp.Infrastructure
{
    public static class ProgramServices
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ABCCorpDbContext>(o => o.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
            services.AddScoped<ITaskRepository, TaskRepositiory>();
            services.AddScoped<ITaskEmpoyeeRepository, TaskEmployeeRepository>();

            return services;
        }
    }
}
