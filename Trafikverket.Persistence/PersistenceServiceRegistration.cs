using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Trafikverket.Application.Contracts.Persistence;
using Trafikverket.Persistence.Repositories;
using Trafikverket_ConsoleApp.Infrastructure;

namespace Trafikverket.Persistence
{
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<TrafikverketContext>(options =>
                                   options.UseInMemoryDatabase("Trafikverket"));            

            services.AddScoped(typeof(IAsyncRepository<>), typeof(BaseRepository<>));
            services.AddScoped<ITrafikverketCameraRepository, TrafikverketCameraRepository>();
        
            return services;
        }
    }
}
