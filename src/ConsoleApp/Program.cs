using static System.Console;
using Ataoge.SafSystem;
using Microsoft.Extensions.DependencyInjection;
using System;
using Ataoge.Application;
using Microsoft.Extensions.Logging;
using Ataoge.Logging;
using Ataoge.Dependency;

namespace ConsoleApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int i = 29;
            WriteLine($"The answer is {new Thing().Get(i, 23)}");

            IApp app = AppRuntime.Create();
            app.Start();

            IServiceCollection services = new ServiceCollection();
            IServiceProvider serviceProvider = ConfigureServices(services); //构建容器
            
            ILoggerFactory loggerFactory = serviceProvider.GetService<ILoggerFactory>();
            loggerFactory.AddConsole()
                         .AddDebug();
            app.UseCoreLogging(loggerFactory);

            var transientOpertion1 = serviceProvider.GetService<IOperationTransient>();
            var scopepOperation1 = serviceProvider.GetService<IOperationScoped>();
            var sigletonOperation1 = serviceProvider.GetService<IOperationSingleton>();

            var transientOpertion2 = serviceProvider.GetService<IOperationTransient>();
            var scopepOperation2 = serviceProvider.GetService<IOperationScoped>();
            var sigletonOperation2 = serviceProvider.GetService<IOperationSingleton>();
            
            IServiceScopeFactory[] scopeFactories = IocManager.Instance.ResolveAll<IServiceScopeFactory>();
            IServiceScopeFactory scopeFactory = serviceProvider.GetService<IServiceScopeFactory>();
            using(var scope = scopeFactory.CreateScope())
            {
                IServiceProvider scopeProvider = scope.ServiceProvider;
                var transientOpertion3 = scopeProvider.GetService<IOperationTransient>();
                var scopepOperation3 = scopeProvider.GetService<IOperationScoped>();
                var sigletonOperation3 = scopeProvider.GetService<IOperationSingleton>();
            
                var transientOpertion4 = scopeProvider.GetService<IOperationTransient>();
                var scopepOperation4 = scopeProvider.GetService<IOperationScoped>();
                var sigletonOperation4 = scopeProvider.GetService<IOperationSingleton>();
            }
            IServiceProvider newServiceProvider = serviceProvider.GetService<IServiceProvider>();

            ILog log = LogManager.GetLogger(typeof(Program));
            log.Info("This is a LogManager Log");


        }

        /// <summary>
        /// This method gets called by the runtime. Use this method to add services to the container.
        /// </summary>
        public static  IServiceProvider ConfigureServices(IServiceCollection services)
        {
            IocManager.Instance.ObjectContainer = new MsObjectContainer(services);

            SafServiceProvider safServiceProvider =new SafServiceProvider(IocManager.Instance);
            IocManager.Instance.Register<IServiceProvider>(safServiceProvider); 
            IocManager.Instance.Register<IServiceScopeFactory, SafScopeFactory>();
            //services.AddTransient<ILoggerFactory, LoggerFactory>();
            IocManager.Instance.Register<ILoggerFactory, LoggerFactory>(LifeTimeStyle.Transient);

            IocManager.Instance.Register<IOperationTransient, Operation>(LifeTimeStyle.Transient);
            IocManager.Instance.Register<IOperationScoped, Operation>(LifeTimeStyle.Scoped);
            IocManager.Instance.Register<IOperationSingleton, Operation>();
            IocManager.Instance.Register<IOperationSingletonInstance,Operation>();

            return safServiceProvider;//new SafServiceProvider(IocManager.Instance);
            //return services.BuildServiceProvider();
        }
    }
}
