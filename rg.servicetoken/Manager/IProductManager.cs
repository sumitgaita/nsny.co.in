using rg.service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rg.service.Manager
{
    public interface IProductManager
    {
        List<Product> GetAllProducts();
    }
}
