using Repositorypattern.core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorypattern.core.IDatabaseRepository
{
    public interface IProductRepository :  IDatabaseRepository<Product>
    {
        IEnumerable<Product> GetSpeciality(string special);
        IEnumerable<Product> GetFilter(string brand, decimal priceMax, decimal priceMin, string rate);
    }
}
