using Animal.Infrastructure;
using Animal.Infrastructure.Entities;
using Animal.Infrastructure.Interfaces;
using Animal.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
namespace PostgresProject{
    public static class DIConfiguration{
        public static IServiceProvider GetServiceProvider(){
            
            var host = Host.CreateDefaultBuilder()
                .ConfigureServices(services =>
                {
                    services.AddDbContext<AppAnimalContext>(options =>
                        options.UseNpgsql("Host=ep-restless-tree-a87x17dk-pooler.eastus2.azure.neon.tech;Database=neondb;Username=neondb_owner;Password=npg_Xw3F4AUMkluV"));
                    services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
                    services.AddScoped<ISpecieService, SpecieService>();
                    services.AddScoped<IAnimalService, AnimalService>();
                    services.AddScoped<DatabaseSeeder>();
                })
                .Build();
            var score = host.Services.CreateScope();
            return score.ServiceProvider;
        }
    }
}