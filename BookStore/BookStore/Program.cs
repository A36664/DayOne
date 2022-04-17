using BookStore.Data.Repositories;
using BookStore.Service.Services;
using SimpleInjector;
using SimpleInjector.Diagnostics;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using BookStore.Data.Infrastructure;
using BookStore.Service;
using Microsoft.Extensions.Logging;
using Serilog;

namespace BookStore
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {


            log4net.Config.XmlConfigurator.Configure();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);



         




            var container = Bootstrap();




            Application.Run(container.GetInstance<FrmMain>());



        }
        private static Container Bootstrap()
        {
            // Create the container as usual.
            var container = new Container();

            //Registration registration = container.GetRegistration(typeof(IService)).Registration;

            //registration.SuppressDiagnosticWarning(DiagnosticType.DisposableTransientComponent,
            //    "Reason of suppression");

            
            //Register your types, for instance:
            container.Register<IDbFactory,DbFactory>(Lifestyle.Singleton);
            container.Register<IUnitOfWork, UnitOfWork>();

            // register repositories
            container.Register<ICustomerRepository, CustomerRepository>();
            container.Register<IAuthorRepository, AuthorRepository>();
            container.Register<ICategoryRepository, CategoryRepository>();
            container.Register<IBookRepository, BookRepository>();

            // register services
            container.Register<ICustomerService, CustomerService>();
            container.Register<IBookService, BookService>();
            container.Register<IAuthorService, AuthorService>();
            container.Register<ICategoryService, CategoryService>();
            container.Register<IMainHandler,MainHandler>();
            AutoRegisterWindowsForms(container);

            container.Verify();
           

            return container;
        }

        private static void AutoRegisterWindowsForms(Container container)
        {
            var types = container.GetTypesToRegister<Form>(typeof(Program).Assembly);

            foreach (var type in types)
            {
                var registration =
                    Lifestyle.Transient.CreateRegistration(type, container);

                registration.SuppressDiagnosticWarning(
                    DiagnosticType.DisposableTransientComponent,
                    "Forms should be disposed by app code; not by the container.");

                container.AddRegistration(type, registration);
            }
        }
    }
}
