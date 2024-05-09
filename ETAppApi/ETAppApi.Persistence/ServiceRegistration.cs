using ETAppApi.Application.Abtractions;
using ETAppApi.Application.Repostories;
using ETAppApi.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Protocols;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ETAppApi.Persistence.Repostories;
using ETAppApi.Persistence.Concrets;

namespace ETAppApi.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceServices(this IServiceCollection services)
        {
            services.AddSingleton<IProductService, ProductService>();

        }

        public static void AddDbContextSpecial(this IServiceCollection services)
        {

            var builder = new ConfigurationBuilder()
                                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            services.AddDbContext<ETAppContext>(options =>
                                    options.UseSqlServer(builder.Build().GetSection("SqlConnectionString").Value));
            services.AddScoped(typeof(IReadRepostory<>), typeof(ReadRepostory<>));
            services.AddScoped(typeof(IWriteRepostory<>), typeof(WriteRepostory<>));
        }


    }
}
