using rg.framework.Data;
using rg.service.Models;
using System;
using System.Collections.Generic;
using System.Data;

namespace rg.service.Data
{
    public class CenterData
    {
        private Factory myFactory;
        private Helpers hlpr;

        public CenterData()
        {
            myFactory = new Factory();
            hlpr = new Helpers();
        }

        public bool CreateCenter(Branch branch)
        {

            List<IDbDataParameter> parameters = new List<IDbDataParameter>
            {
                myFactory.GetParameter("@branchid", branch.BranchId),
                myFactory.GetParameter("@name", branch.Bname),
                myFactory.GetParameter("@contact", branch.Bcontact),
                myFactory.GetParameter("@commission", branch.Bcommission),
                myFactory.GetParameter("@email", branch.Bemail),
                myFactory.GetParameter("@pass", branch.Bpass),
                myFactory.GetParameter("@r1", ""),
                myFactory.GetParameter("@r2", ""),
                myFactory.GetParameter("@r3", Convert.ToInt32(0)),
                myFactory.GetParameter("@act", Convert.ToInt32(1)),
                myFactory.GetParameter("@paymentmode", branch.Paymentmode),
                myFactory.GetParameter("@mastercode", branch.Mastercode),
                myFactory.GetParameter("@code", branch.Code),
                myFactory.GetParameter("@address", branch.Address),
                myFactory.GetParameter("@coursecatagory", branch.CourseCatagory)
            };
            return hlpr.ExecuteStoredProcedure("CenterInsert", ref parameters);
        }

        public bool UpdateCenter(Branch branch)
        {
            List<IDbDataParameter> parameters = new List<IDbDataParameter>
            {
                myFactory.GetParameter("@id", branch.Id),
                myFactory.GetParameter("@name", branch.Bname),
                myFactory.GetParameter("@contact", branch.Bcontact),
                myFactory.GetParameter("@commission", branch.Bcommission),
                myFactory.GetParameter("@email", branch.Bemail),
                myFactory.GetParameter("@pass", branch.Bpass),
                myFactory.GetParameter("@r1", ""),
                myFactory.GetParameter("@r2", ""),
                myFactory.GetParameter("@r3", Convert.ToInt32(0)),
                myFactory.GetParameter("@act", Convert.ToInt32(1)),
                myFactory.GetParameter("@paymentmode", branch.Paymentmode),
                myFactory.GetParameter("@address", branch.Address),
                myFactory.GetParameter("@coursecatagory", branch.CourseCatagory)
             };
            return hlpr.ExecuteStoredProcedure("CenterUpdate", ref parameters);

        }

        public bool DeleteCenter(Branch per)
        {
            List<IDbDataParameter> parameters = new List<IDbDataParameter>
            {
                myFactory.GetParameter("@id", per.Id)
            };
            return hlpr.ExecuteStoredProcedure("CenterDelete", ref parameters);

        }


        public int CurrntCenterId(int branchid)
        {
            int student = 0;
            List<IDbDataParameter> parameters = new List<IDbDataParameter>
            {
                myFactory.GetParameter("@branchid", branchid)
            };
            string query = "GetcurrentCenterId";
            DataTable tbl = hlpr.GetDataTable(query, ref parameters);
            foreach (DataRow row in tbl.Rows)
            {
                student = Convert.ToInt32(row["currntId"]);

            }
            return student;
        }

        public List<Branch> GetBranchCenter(int bid)
        {
            List<Branch> center = new List<Branch>();
            List<IDbDataParameter> parameters = new List<IDbDataParameter>
            {
                myFactory.GetParameter("@bid", bid)
            };
            string query = "GetBranchCenter";
            DataTable tbl = hlpr.GetDataTable(query, ref parameters);
            foreach (DataRow row in tbl.Rows)
            {
                center.Add(new Branch()
                {

                    Id = Convert.ToInt32(row["id"]),
                    BranchId = !row.IsNull("branchid") ? Convert.ToInt32(row["branchid"]) : 0,
                    Bname = row["name"].ToString(),
                    Bcontact = row["contact"].ToString(),
                    Bemail = row["email"].ToString(),
                    Bpass = row["pass"].ToString(),
                    Bcommission = !row.IsNull("commission") ? Convert.ToInt32(row["commission"]) : 0,
                    Paymentmode = row["paymentmode"].ToString(),
                    CourseCatagory = row["coursecatagory"].ToString(),//!row.IsNull("coursecatagory") ? Convert.ToInt32(row["coursecatagory"]) : 0,
                    Code = row["code"].ToString(),
                    Mastercode = row["mastercode"].ToString(),
                    Address = row["address"].ToString()

                });
            }
            return center;
        }




    }
}