using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PetsStore.Domain.Entities;
using System.Collections.Generic;

namespace PetsStore.Domain.Abstract
{
    public interface IProductRepository
    {
        IEnumerable<Product> Products { get; }

    }
}
