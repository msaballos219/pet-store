using System;
using System.Linq;
using System.Web;
using System.Collections.Generic;
using PetsStore.Domain.Entities;

namespace PetsStore.WebUI.Models
{
    public class ProductsListViewModel
    {
        public IEnumerable<Product> Products { get; set; }

        public PagingInfo PagingInfo { get; set; }

        public string CurrentCategory { get; set; }

    }
}