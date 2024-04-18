using PetsStore.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PetsStore.WebUI.Controllers
{
    public class ProductController : Controller
    {
        private IProductRepository myrepository;

        public ProductController (IProductRepository prodRepo)
        {
            this.myrepository = prodRepo;
        }

        public ViewResult List()
        {
            return View(myrepository.Products);
        }
    }
}