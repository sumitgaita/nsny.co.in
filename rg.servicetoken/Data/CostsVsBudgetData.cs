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
    public class CostsVsBudgetData
    {
        Factory myFactory;
        Helpers hlpr;

        public CostsVsBudgetData()
        {
            myFactory = new Factory();
            hlpr = new Helpers();
        }
        public List<CostsVsBudget> CostsVsBudgetDataDetails(CostsVsBudget costsvsbudgets)
        {
            List<CostsVsBudget> costsVsBudgetDetails = new List<CostsVsBudget>();
            List<IDbDataParameter> parameters = new List<IDbDataParameter>();
            parameters.Add(myFactory.GetParameter("@Project_ID", costsvsbudgets.ProjectId));

            string query = "Budget_cost_resource";
            DataTable tbl = hlpr.GetDataTable(query, ref parameters);

            foreach (DataRow row in tbl.Rows)
            {
                costsVsBudgetDetails.Add(new CostsVsBudget()
                {
                     
                    CostCodeId = Convert.ToInt32(row["cost_code_id"]),
                    CostCodeName = row["cost_code"].ToString(),
                    CostCodeDescription = row["cost_code_description"].ToString(),
                    CostCodeBudget = Convert.ToDecimal(row["cost_code_budget"]),
                    Cost = Convert.ToDecimal(row["cost"]),
                    Difference = Convert.ToDecimal(row["diff"])



                });


            }
            return costsVsBudgetDetails;

        }
    }
}