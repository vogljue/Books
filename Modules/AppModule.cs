using Autofac;
using Autofac.Extras.NLog;
using Books.Services;

namespace Books.Modules
{
    public class AppModule
    {
        private IContainer Container { get; set; }

        public AppModule()
        {

        }

        public IContainer BuildContainer()
        {
            // Register Components with Service Interface
            // BookService with Default Instance Per Dependency (Factory)
            // PersonService with Single Incstance
            // another variant is Instance Per Lifetime Scope (nested lifetimes)
            ContainerBuilder builder = new ContainerBuilder();
            builder.RegisterModule<NLogModule>();
            builder.RegisterType<BookService>().As<IBookService>();
            //builder.RegisterType<PersonService>().As<IPersonService>().SingleInstance();
            builder.RegisterType<PersonService>().As<IPersonService>();
            Container = builder.Build();

            return Container;
        }
    }
}
