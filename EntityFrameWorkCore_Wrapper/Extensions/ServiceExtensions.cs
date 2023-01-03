using EFWrapper_Data_Access.DbContext;
using EFWrapper_Engine.Resources.Implementation;
using EFWrapper_Engine.Resources.Interfaces;
using EFWrapper_Engine.Warehouse.Implementations;
using EFWrapper_Engine.Warehouse.Interfaces;
using EFWrapper_Utilities;
using ERWrapper_Repositroy.DemoDateRepo.Implementation;
using ERWrapper_Repositroy.DemoDateRepo.Interfaces;

namespace EntityFrameWorkCore_Wrapper.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureCors(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.WithOrigins(configuration.GetSection("CorsSettings:AllowUrls").Value.Split(';'))
                    .AllowAnyMethod()
                    .AllowAnyHeader());
            });
        }
        public static void ConfigureServices(this IServiceCollection services)
        {
            services.AddScoped<IApplicationDbContext, ApplicationDbContext>();
            
            services.AddScoped<IGetDataService, GetDataService>();
            services.AddScoped<IDemoData, DemoData>();
            services.AddScoped<IDemoDataRepo, DemoDataRepo>();

            services.AddScoped<IUserAuthService, UserAuthService>();
            services.AddScoped<IUserAuth, UserAuth>();
            services.AddScoped<IDataAuthRepo, DataAuthRepo>();

        }
        public static void ConfigureSettings(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<Connections>(options => configuration.GetSection("ConnectionStrings").Bind(options));
        }
    }
}
