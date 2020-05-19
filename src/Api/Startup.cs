using Autofac;
using Autofac.Extensions.DependencyInjection;
using Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Api
{
    public class Startup
    {
        private readonly IConfiguration _configuration;
        private readonly bool _isDev;
        private IServiceCollection _services;

        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            _configuration = configuration;
            _isDev = env.IsDevelopment();
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddHealthChecks();
            services.AddOptions();
            services.AddMvc().AddControllersAsServices();
            
            _services = services;
        }
        public void ConfigureContainer(ContainerBuilder container)
        {
            var dataSourceUrl = _configuration[EnvVarSchema.DataSourceUrl];
            var assembly = typeof(Startup).Assembly;

            container.RegisterModule(new FleetInstaller(dataSourceUrl, assembly, _isDev));
            container.RegisterModule(new ApiInstaller());
        }

        public void Configure(IApplicationBuilder app)
        {
            var root = app.ApplicationServices.GetAutofacRoot();
            var context = root.Resolve<FleetContext>();
            
            if (_isDev)
            {
                app.UseDeveloperExceptionPage();
            }
            
            app.UseMiddleware<ExceptionsMiddleware>(); 
            
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapHealthChecks("/healthcheck");
                endpoints.MapControllers();
            });

            DataStartup.Migrate(context, _isDev);
        }
    }
}