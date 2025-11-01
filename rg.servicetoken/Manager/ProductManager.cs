using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using rg.service.Models;
using rg.service.Data;

namespace rg.service.Manager
{
    public class ProductManager :IProductManager
    {

        public List<Product> GetAllProducts()
        {
            var data = new ProductData();

            return data.GetAllProducts();
        }

    }
}