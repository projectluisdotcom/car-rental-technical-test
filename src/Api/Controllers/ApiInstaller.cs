using Autofac;
using Data;
using Domain;

namespace Api
{
    public class ApiInstaller : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<CustomerRepository>()
                .As<ICustomerRepository>()
                .SingleInstance();
            
            builder.RegisterType<CarRepository>()
                .As<ICarRepository>()
                .SingleInstance();
            
            builder.RegisterType<CarPriceCalculator>()
                .As<ICarPriceCalculator>()
                .SingleInstance();
            
            builder.RegisterType<CarBonusCalculator>()
                .As<ICarBonusCalculator>()
                .SingleInstance();
       
            builder.Register(c => new FetchAvailableCars(c.Resolve<ICarRepository>()))
                .As<IFetchAvailableCars>();
            
            //  builder.RegisterControllers(_mvcAssembly);
            builder.Register(c => new FetchAvailableCarsController(c.Resolve<IFetchAvailableCars>()));
        }
    }
}