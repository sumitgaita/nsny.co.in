using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using rg.framework;
using System.Data.SqlClient;
using rg.service.Models;
using rg.framework.Data;
using System.Data;

namespace rg.service.Data
{
    public class ProductData
    {
        Factory myFactory;
        Helpers hlpr;

        public ProductData()
        {
            myFactory = new Factory();
            hlpr = new Helpers();
        }
        public bool CreateProduct(Product product, out string Message)
        {
          
            List<IDbDataParameter> parameters = new List<IDbDataParameter>();
            parameters.Add(myFactory.GetParameter("@Name", product.Name));
            parameters.Add(myFactory.GetParameter("@ShortDescription", product.ShortDescription));
            parameters.Add(myFactory.GetParameter("@CreatedOn", product.CreatedOn));
            parameters.Add(myFactory.GetParameter("@UpdatedOn", product.UpdatedOn));
            IDbDataParameter productId = myFactory.GetParameter("@ProductId", SqlDbType.Int, ParameterDirection.Output);
            IDbDataParameter Result = myFactory.GetParameter("@Result", SqlDbType.Bit, ParameterDirection.Output);
            IDbDataParameter ResultText = myFactory.GetParameter("@ResultText", SqlDbType.VarChar, 100, ParameterDirection.Output);

            parameters.Add(productId);
            parameters.Add(Result);
            parameters.Add(ResultText);

            hlpr.ExecuteStoredProcedure("RG_ProductInsert", ref parameters);

            product.ProductId = Convert.ToInt32(productId.Value);
            Message = ResultText.Value.ToString();
            return Convert.ToBoolean(Result.Value);
        }

        public List<Product> GetAllProducts()
        {
            List<Product> products = new List<Product>();
            List<IDbDataParameter> parameters = new List<IDbDataParameter>();
            string query = "RG_ProductGetAll";
            DataTable tbl = hlpr.GetDataTable(query,ref parameters);
          

            foreach (DataRow row in tbl.Rows)
            {
                products.Add(new Product()
                {
                    ProductId = Convert.ToInt32(row["ProductId"]),
                    Name = row["Name"].ToString(),
                    ShortDescription = row["ShortDescription"].ToString(),
                    CreatedOn = Convert.ToDateTime(row["CreatedOn"]),
                    UpdatedOn = Convert.ToDateTime(row["UpdatedOn"])
                });
            }
            return products;

        }
    }
}