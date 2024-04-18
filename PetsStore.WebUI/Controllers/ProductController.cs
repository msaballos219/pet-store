using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PetsStore.Domain.Abstract;
using PetsStore.WebUI.Models;

namespace PetsStore.WebUI.Controllers
{
    public class ProductController : Controller
    {
        private IProductRepository myRepository;

        public ProductController(IProductRepository proRepository)
        {
            this.myRepository = proRepository;
        }
        // GET: Product
        public int PageSize = 4;
        public ViewResult List(string category, int page = 1)
        {
            ProductsListViewModel model = new ProductsListViewModel
            {
                Products = myRepository.Products
                            .Where(p => category == null || p.Category == category)
                            .OrderBy(p => p.ProductID)
                            .Skip((page - 1) * PageSize)
                            .Take(PageSize),

                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = category == null ?
                                    myRepository.Products.Count() :
                                    myRepository.Products.Where
                                        (e => e.Category == category).Count()
                }
            };
            return View(model);
        }
        /*return View(myRepository.Products.OrderBy(p => p.ProductID).Skip((page-1) * PageSize).Take(PageSize));*/



    }
}