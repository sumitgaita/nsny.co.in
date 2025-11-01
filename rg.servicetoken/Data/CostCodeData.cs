using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using rg.framework.Data;
using rg.service.Models;

namespace rg.service.Data
{
    public class CostCodeData
    {
        Factory myFactory;
        Helpers hlpr;

        public CostCodeData()
        {
            myFactory = new Factory();
            hlpr = new Helpers();
        }
        public List<CostCode> CostCodeDetails(CostCode costcodes)
        {
            List<CostCode> costCodeDetails = new List<CostCode>();
            List<IDbDataParameter> parameters = new List<IDbDataParameter>();
            parameters.Add(myFactory.GetParameter("@Project_ID", costcodes.ProjectId));

            string query = "Budget_cost_Code_for_all";
            DataTable tbl = hlpr.GetDataTable(query, ref parameters);

            foreach (DataRow row in tbl.Rows)
            {
                costCodeDetails.Add(new CostCode()
                {

                    CostCodeId = Convert.ToInt32(row["cost_code_id"]),
                    CostCodeName = row["cost_code"].ToString(),
                    CostCodeDescription = row["cost_code_description"].ToString(),
                    CostCodeBudget = Convert.ToDecimal(row["cost_code_budget"]),
                    CostCodeCreateDate = Convert.ToDateTime(row["cost_code_create_date"])
                });


            }
            return costCodeDetails;

        }

        public List<CostCode> CountCostCode(CostCode costcodes)
        {
            List<CostCode> costCodeDetails = new List<CostCode>();
            List<IDbDataParameter> parameters = new List<IDbDataParameter>();
            parameters.Add(myFactory.GetParameter("@Project_ID", costcodes.ProjectId));
            parameters.Add(myFactory.GetParameter("@create_date", costcodes.CostCodeCreateDate));
            string query = "Countcostcode";
            DataTable tbl = hlpr.GetDataTable(query, ref parameters);

            foreach (DataRow row in tbl.Rows)
            {
                costCodeDetails.Add(new CostCode()
                {

                    CostCodeId = Convert.ToInt32(row["cost_code"]),
                    CostCodeName = row["cost"].ToString(),
                    CostCodeActivity = row["costcodeactivity"].ToString(),
                    CostCodeDescription = row["cost_code_description"].ToString()
                    

                });


            }
            return costCodeDetails;

        }

        public CostCode CostCodeEditDetails(CostCode codeDetails)
        {
            var details = new CostCode();
            List<IDbDataParameter> parameters = new List<IDbDataParameter>();
            parameters.Add(myFactory.GetParameter("@cost_code_id", codeDetails.CostCodeId));

            string query = "Edit_cost_Code_for_all";
            DataTable tbl = hlpr.GetDataTable(query, ref parameters);

            foreach (DataRow row in tbl.Rows)
            {
                
                details.CostCodeName = row["cost_code"].ToString();
                details.CostCodeDescription = row["cost_code_description"].ToString();
                details.CostCodeBudget = Convert.ToDecimal(row["cost_code_budget"]);
                
            }
            return details;

        }
        public bool CreateCostCodeActivity(CostCode code)
        {
           

            List <IDbDataParameter> parameters = new List<IDbDataParameter>();
            parameters.Add(myFactory.GetParameter("@ProjectID", code.ProjectId));
            parameters.Add(myFactory.GetParameter("@Date", code.CostCodeCreateDate));
            parameters.Add(myFactory.GetParameter("@Daily_Completed", "false"));
            parameters.Add(myFactory.GetParameter("@Weatheram", "false"));
            parameters.Add(myFactory.GetParameter("@Weatherpm", "false"));
            parameters.Add(myFactory.GetParameter("@costcodeactivity", code.CostCodeActivity));
            parameters.Add(myFactory.GetParameter("@cost_code_id", code.CostCodeId));
           
            return hlpr.ExecuteStoredProcedure("InsertDailyProjectReport", ref parameters);
        }

        public bool CreateCostCode(CostCode cc)
        {
          
            List <IDbDataParameter> parameters = new List<IDbDataParameter>();
            parameters.Add(myFactory.GetParameter("@projectID", cc.ProjectId));
            parameters.Add(myFactory.GetParameter("@cost_code", cc.CostCodeName));
            parameters.Add(myFactory.GetParameter("@cost_code_description", cc.CostCodeDescription));
            parameters.Add(myFactory.GetParameter("@cost_code_budget", cc.CostCodeBudget));
            parameters.Add(myFactory.GetParameter("@cost_code_create_date", cc.CostCodeCreateDate));
          
            return hlpr.ExecuteStoredProcedure("Add_Cost_code_for_all", ref parameters);
        }
        public bool UpdateCostCode(CostCode cc)
        {

           
            List <IDbDataParameter> parameters = new List<IDbDataParameter>();
            parameters.Add(myFactory.GetParameter("@cost_code_id", cc.CostCodeId));
            parameters.Add(myFactory.GetParameter("@cost_code", cc.CostCodeName));
            parameters.Add(myFactory.GetParameter("@cost_code_description", cc.CostCodeDescription));
            parameters.Add(myFactory.GetParameter("@cost_code_budget", cc.CostCodeBudget));
            return hlpr.ExecuteStoredProcedure("updateCostCode", ref parameters);
        }

        public CostCode CostCodeCount(CostCode cc)
        {
            var details = new CostCode();
            List<IDbDataParameter> parameters = new List<IDbDataParameter>();
            parameters.Add(myFactory.GetParameter("@cost_code_id", cc.CostCodeId));

            string query = "CountCostCodefromresource";
            DataTable tbl = hlpr.GetDataTable(query, ref parameters);

            foreach (DataRow row in tbl.Rows)
            {
                details.CostCodeCount =Convert.ToInt32(row["ccc"]);
               
            }
            return details;
        }
        public bool DeleteCostCode(CostCode cc)
        {
            List<IDbDataParameter> parameters = new List<IDbDataParameter>();
            parameters.Add(myFactory.GetParameter("@cost_code_id", cc.CostCodeId));
           return hlpr.ExecuteStoredProcedure("DeleteCostCode", ref parameters);

        }

    }
}