using rg.framework.Data;
using rg.service.Models;
using System;
using System.Collections.Generic;
using System.Data;

namespace rg.service.Data
{
    public class MasterCodeData
    {
        private Factory myFactory;
        private Helpers hlpr;

        public MasterCodeData()
        {
            myFactory = new Factory();
            hlpr = new Helpers();
        }

        public int CreateMasterCode(Master_Code masterCode)
        {

            List<IDbDataParameter> parameters = new List<IDbDataParameter>
            {
                myFactory.GetParameter("@id", masterCode.Id),
                myFactory.GetParameter("@name", masterCode.Name),
                myFactory.GetParameter("@contact", masterCode.Contact),
                myFactory.GetParameter("@email", masterCode.Email),
                myFactory.GetParameter("@pass", masterCode.Pass),
                myFactory.GetParameter("@address", masterCode.Address),
                myFactory.GetParameter("@mastercode", masterCode.Mastercode),
                myFactory.GetParameter("@active", masterCode.Active)
               
            };
            return hlpr.ReturnStoredProcedure("Add_MasterCode", ref parameters);
        }
      
        public bool UpdateMasterCode(Master_Code masterCode)
        {
            List<IDbDataParameter> parameters = new List<IDbDataParameter>
            {
                myFactory.GetParameter("@id", masterCode.Id),
                myFactory.GetParameter("@name", masterCode.Name),
                myFactory.GetParameter("@contact", masterCode.Contact),
                myFactory.GetParameter("@email", masterCode.Email),
                myFactory.GetParameter("@pass", masterCode.Pass),
                myFactory.GetParameter("@address", masterCode.Address),
                myFactory.GetParameter("@mastercode", masterCode.Mastercode),
                myFactory.GetParameter("@active", masterCode.Active)
               

             };
            return hlpr.ExecuteStoredProcedure("Add_MasterCode", ref parameters);

        }

        public bool DeleteMasterCode(Master_Code masterCode)
        {
            List<IDbDataParameter> parameters = new List<IDbDataParameter>
            {
                myFactory.GetParameter("@id", masterCode.Id)
            };
            return hlpr.ExecuteStoredProcedure("DeleteMasterCode", ref parameters);

        }
       
        public List<Master_Code> GetAllMasterCode()
        {
            List<Master_Code> brach = new List<Master_Code>();
            List<IDbDataParameter> parameters = new List<IDbDataParameter>();
            string query = "GetMasterCodeList";
            DataTable tbl = hlpr.GetDataTable(query, ref parameters);
            foreach (DataRow row in tbl.Rows)
            {
                brach.Add(new Master_Code()
                {

                    Id = Convert.ToInt32(row["id"]),
                    Mastercode = row["master_code"].ToString(),
                    Name = row["name"].ToString(),
                    Contact = row["contact"].ToString(),
                    Email = row["email"].ToString(),
                    Pass = row["pass"].ToString(),
                    Address = row["address"].ToString(),
                    CreateDate = row["create_date"].ToString(),
                    Active =row["active"].ToString()

                });
            }
            return brach;
        }
       
    }
}