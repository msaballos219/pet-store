using System.Linq;
using Moq;
using Ninject;
using System;
using System.Web.Mvc;
using System.Collections.Generic;
using PetsStore.Domain.Abstract;
using PetsStore.Domain.Concrete;

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
            /*Mock<IProductRepository> myMock = new Mock<IProductRepository>();

            myMock.Setup(m => m.Products).Returns(new List<Product> {
                 new Product { Name = "Bird Seed", Price = 25},
                 new Product { Name = "Chew Toy", Price = 179},
                 new Product { Name = "Training Treats", Price = 95},
                 });*/
            mykernel.Bind<IProductRepository>().To<EFProductRepository>();
        }
    }
}