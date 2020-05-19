using System.Reflection;
using Autofac;
using Microsoft.EntityFrameworkCore;
using Module = Autofac.Module;

namespace Data
{
    public class FleetInstaller : Module
    {
        private readonly string _connectionUrl;
        private readonly Assembly _migrationAssembly;
        private readonly bool _isDev;

        public FleetInstaller(string connectionUrl, Assembly migrationAssembly, bool isDev)
        {
            _connectionUrl = connectionUrl;
            _migrationAssembly = migrationAssembly;
            _isDev = isDev;
        }
        
        protected override void Load(ContainerBuilder builder)
        {
            if (_isDev)
            {
                builder.Register(c =>
                    {
                        var contextBuilder = new DbContextOptionsBuilder<FleetContext>();
                        contextBuilder.UseInMemoryDatabase(typeof(FleetContext).Name);
                        return new FleetContext(contextBuilder.Options);
                    })
                    .AsSelf()
                    .As<FleetContext>()
                    .InstancePerLifetimeScope();
            }
            else
            {
                builder.Register(c =>
                    {
                        var contextBuilder = new DbContextOptionsBuilder<FleetContext>();
                        contextBuilder.UseMySql(
                            _connectionUrl, 
                            action => action.MigrationsAssembly(_migrationAssembly.GetName().Name)
                        );

                        return new FleetContext(contextBuilder.Options);
                    })
                    .AsSelf()
                    .As<FleetContext>()
                    .InstancePerLifetimeScope();
            }
        }
    }
}