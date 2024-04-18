using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PetsStore.Domain.Abstract;
using PetsStore.Domain.Entities;

namespace PetsStore.Domain.Concrete
{
    public class EFProductRepository : IProductRepository
    {
        private EFDbContext context = new EFDbContext();

        public IEnumerable<Product> Products
        { 
            get { return context.Products; }
        } 
    }
}
