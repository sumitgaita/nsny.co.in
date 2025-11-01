using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using rg.framework.Data;
using rg.service.Models;

namespace rg.service.Data
{
    public class CostCalculationData
    {
        Factory myFactory;
        Helpers hlpr;

        public CostCalculationData()
        {
            myFactory = new Factory();
            hlpr = new Helpers();
        }
        public CostCalculation ProjectMonthWiseDetails(CostCalculation costcalculations)
        {
           var costCalculationDetails = new CostCalculation();
            List<IDbDataParameter> parameters = new List<IDbDataParameter>();
            parameters.Add(myFactory.GetParameter("@project_id", costcalculations.ProjectId));
            parameters.Add(myFactory.GetParameter("@create_date", costcalculations.SearchDate));

            string query = "totalcostDatewithprojectanddate";
            DataTable tbl = hlpr.GetDataTable(query, ref parameters);

            foreach (DataRow row in tbl.Rows)
            {
                costCalculationDetails.ProjectId = Convert.ToInt32(row["ProjectID"]);
                costCalculationDetails.ProjectName = row["project_name"].ToString();
                costCalculationDetails.TotalCost = Convert.ToDecimal(row["cost"]);
                costCalculationDetails.SearchDate = Convert.ToDateTime(row["create_date"]);



            }
            return costCalculationDetails;

        }


        public List<CostCalculation> MonthInBeteenDetails(CostCalculation monthBetween)
        {
            List<CostCalculation> monthBetweenDetails = new List<CostCalculation>();
            List<IDbDataParameter> parameters = new List<IDbDataParameter>();
            parameters.Add(myFactory.GetParameter("@from_date", monthBetween.SearchStartDate));
            parameters.Add(myFactory.GetParameter("@to_date", monthBetween.SearchDate));

            string query = "TodayCost_Total";
            DataTable tbl = hlpr.GetDataTable(query, ref parameters);

            foreach (DataRow row in tbl.Rows)
            {
                monthBetweenDetails.Add(new CostCalculation()
                {
                    ProjectName = row["project_name"].ToString(),
                    TotalCost = Convert.ToDecimal(row["cost"])
                   
                });


            }
            return monthBetweenDetails;

        }
        public List<CostCalculation> PojectwiseDetails(CostCalculation projectwise)
        {
            List<CostCalculation> projectWiseDetails = new List<CostCalculation>();
            List<IDbDataParameter> parameters = new List<IDbDataParameter>();
            parameters.Add(myFactory.GetParameter("@project_id", projectwise.ProjectId));
            

            string query = "totalcostDatewithproject";
            DataTable tbl = hlpr.GetDataTable(query, ref parameters);

            foreach (DataRow row in tbl.Rows)
            {
                projectWiseDetails.Add(new CostCalculation()
                {
                    
                   ProjectId = Convert.ToInt32(row["ProjectID"]),
                   ProjectName = row["project_name"].ToString(),
                   TotalCost = Convert.ToDecimal(row["cost"]),
                    CreateDate = Convert.ToDateTime(row["create_date"]),
            });


            }
            return projectWiseDetails;

        }

        public List<CostCalculation> GetAllProjects()
        {
            List<CostCalculation> projects = new List<CostCalculation>();
            List<IDbDataParameter> parameters = new List<IDbDataParameter>();
            string query = "ShowsProjectList";
            DataTable tbl = hlpr.GetDataTable(query, ref parameters);


            foreach (DataRow row in tbl.Rows)
            {
                projects.Add(new CostCalculation()
                {

                    ProjectId = Convert.ToInt32(row["ProjectID"]),
                    ProjectName = row["project_name"].ToString()
                   
                });
            }
            return projects;

        }
        public List<CostCalculation> PojectwiseCostCodeDetails(CostCalculation costCodes)
        {
            List<CostCalculation> costCodesDetails = new List<CostCalculation>();
            List<IDbDataParameter> parameters = new List<IDbDataParameter>();
            parameters.Add(myFactory.GetParameter("@Project_ID", costCodes.ProjectId));


            string query = "Pro_Cost_Code";
            DataTable tbl = hlpr.GetDataTable(query, ref parameters);

            foreach (DataRow row in tbl.Rows)
            {
                costCodesDetails.Add(new CostCalculation()
                {

                    CostCodeIid = Convert.ToInt32(row["cost_code_id"]),
                    CostCode = row["cost_code"].ToString(),
                    
                });


            }
            return costCodesDetails;

        }
    }
}