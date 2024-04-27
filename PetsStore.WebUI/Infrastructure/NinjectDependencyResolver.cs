using System.Linq;
using Moq;
using Ninject;
using System;
using System.Web.Mvc;
using System.Collections.Generic;
using PetsStore.Domain.Abstract;
using PetsStore.Domain.Entities;
using PetsStore.Domain.Concrete;
using System.Configuration;
using PetsStore.WebUI.Infrastructure.Abstract;
using PetsStore.WebUI.Infrastructure.Concrete;

namespace PetsStore.WebUI.Infrastructure
{
    public class NinjectDependencyResolver : IDependencyResolver
    {
        private IKernel mykernel;

        public NinjectDependencyResolver(IKernel kernelParam)
        {
            mykernel = kernelParam;
            AddBindings();
        }

        public object GetService(Type myserviceType)
        {
            return mykernel.TryGet(myserviceType);
        }

        public IEnumerable<object> GetServices(Type myserviceType)
        {
            return mykernel.GetAll(myserviceType);
        }

        private void AddBindings()
        {
            mykernel.Bind<IProductRepository>().To<EFProductRepository>();

            EmailSettings emailSettings = new EmailSettings
            {
                WriteAsFile = bool.Parse(ConfigurationManager.AppSettings["Email.WriteAsFile"] ?? "false")
            };

            mykernel.Bind<IOrderProcessor>()
                    .To<EmailOrderProcessor>()
                    .WithConstructorArgument("settings", emailSettings);

            mykernel.Bind<IAuthProvider>().To<FormsAuthProvider>();
        }
    }
}