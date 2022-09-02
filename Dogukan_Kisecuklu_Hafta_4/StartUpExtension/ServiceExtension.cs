using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using Service.Containers.Abstract;
using Service.Containers.Concrete;
using Service.Mapper;
using Service.Vehicles.Abstract;
using Service.Vehicles.Concrete;

namespace Dogukan_Kisecuklu_Hafta_3.StartUpExtension
{
    public static class ServiceExtension
    {
        public static void AddServices(this IServiceCollection services)
        {
            // services 
            services.AddScoped<IContainerService, ContainerService>();
            services.AddScoped<IVehicleService, VehicleService>();


            // mapper
            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MappingProfile());
            });
            services.AddSingleton(mapperConfig.CreateMapper());
        }
    }
}
