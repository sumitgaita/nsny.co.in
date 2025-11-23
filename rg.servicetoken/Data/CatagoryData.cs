using rg.framework.Data;
using rg.service.Models;
using System;
using System.Collections.Generic;
using System.Data;

namespace rg.service.Data
{
    public class CatagoryData
    {
        private Factory myFactory;
        private Helpers hlpr;

        public CatagoryData()
        {
            myFactory = new Factory();
            hlpr = new Helpers();
        }

        public bool CreateCatagory(Catagory catagory)
        {

            List<IDbDataParameter> parameters = new List<IDbDataParameter>
            {
                myFactory.GetParameter("@id", catagory.Id),
                myFactory.GetParameter("@name", catagory.Name),
                myFactory.GetParameter("@active", catagory.Active)
               
            };
            return hlpr.ExecuteStoredProcedure("Add_Catagory", ref parameters);
        }
      
        public bool UpdateCatagory(Catagory catagory)
        {
            List<IDbDataParameter> parameters = new List<IDbDataParameter>
            {
                myFactory.GetParameter("@id", catagory.Id),
                myFactory.GetParameter("@name", catagory.Name),
                myFactory.GetParameter("@active", catagory.Active)
               

             };
            return hlpr.ExecuteStoredProcedure("Add_Catagory", ref parameters);

        }

        public bool DeleteCatagory(Catagory per)
        {
            List<IDbDataParameter> parameters = new List<IDbDataParameter>
            {
                myFactory.GetParameter("@id", per.Id)
            };
            return hlpr.ExecuteStoredProcedure("DeleteCatagory", ref parameters);

        }
       
        public List<Catagory> GetAllCatagory()
        {
            List<Catagory> brach = new List<Catagory>();
            List<IDbDataParameter> parameters = new List<IDbDataParameter>();
            string query = "GetCatagoryList";
            DataTable tbl = hlpr.GetDataTable(query, ref parameters);
            foreach (DataRow row in tbl.Rows)
            {
                brach.Add(new Catagory()
                {

                    Id = Convert.ToInt32(row["id"]),
                    Name = row["name"].ToString(),
                    CreateDate = row["create_date"].ToString(),
                    Active =row["active"].ToString()

                });
            }
            return brach;
        }
       
    }
}