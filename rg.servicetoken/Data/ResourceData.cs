using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using rg.framework.Data;
using rg.service.Models;

namespace rg.service.Data
{
    public class ResourceData
    {
        Factory myFactory;
        Helpers hlpr;
        public ResourceData()
        {
            myFactory = new Factory();
            hlpr = new Helpers();
        }
        public List<Resource> ResourceDetails(Resource resources)
        {
            List<Resource> resourceDetails = new List<Resource>();
            List<IDbDataParameter> parameters = new List<IDbDataParameter>();
            parameters.Add(myFactory.GetParameter("@Project_ID", resources.ProjectId));
           
            string query = "View_select_Project_New";
            DataTable tbl = hlpr.GetDataTable(query, ref parameters);

            foreach (DataRow row in tbl.Rows)
            {
                resourceDetails.Add(new Resource()
                {

                    ResourceId = Convert.ToInt32(row["resource_id"]),
                    ResourceName= row["resource"].ToString(),
                    ItemName = row["item_name"].ToString(),
                    Supplier = row["supplier"].ToString(),
                    Unit = row["unit"].ToString(),
                    Qty = Convert.ToDecimal(row["qty"]),
                    Rate = Convert.ToDecimal(row["rate"]),
                    Cost = Convert.ToDecimal(row["cost"]),
                    Comments = row["comments"].ToString(),
                    CreateDate = Convert.ToDateTime( row["create_date"]),
                    ResourceCostCode = row["cost_code"].ToString(),
                    CostCode = Convert.ToInt32(row["cost_code_id"]),
                    CheckStaus= Convert.ToBoolean(row["checkStatus"])


                });


            }
            return resourceDetails;

        }

        public List<Resource> ResourceDetails(Resource resources, int startIndex, out int totalRecords, out decimal totalCost)
        {
            List<Resource> resourceDetails = new List<Resource>();
            List<IDbDataParameter> parameters = new List<IDbDataParameter>();
            parameters.Add(myFactory.GetParameter("@TableOrView", "VW_SELECT_PROJECT_NEW"));


            parameters.Add(myFactory.GetParameter("@SelectedPage", startIndex));
            parameters.Add(myFactory.GetParameter("@PageSize", ConfigurationSettings.AppSettings["pageSize"]));
            parameters.Add(myFactory.GetParameter("@Columns", "resource_id,resource,item_name,supplier,unit,qty,rate,cost,comments,create_date,cost_code,cost_code_id,checkStatus"));
            parameters.Add(myFactory.GetParameter("@OrderByColumn", "create_date"));
            parameters.Add(myFactory.GetParameter("@OrderByDirection", "DESC"));
            parameters.Add(myFactory.GetParameter("@WhereClause", "AND project_id=" + resources.ProjectId));


            string query = "USP_GET_DETAILS_DYNAMICALLY";

            DataSet ds = hlpr.GetDataSet(query, ref parameters);
            DataRow dr = ds.Tables[1].Rows[0];
            totalRecords = Convert.ToInt32(dr["ListingCount"]);
            totalCost = Convert.ToDecimal(dr["TotalCost"]);
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                resourceDetails.Add(new Resource()
                {

                    ResourceId = Convert.ToInt32(row["resource_id"]),
                    ResourceName = row["resource"].ToString(),
                    ItemName = row["item_name"].ToString(),
                    Supplier = row["supplier"].ToString(),
                    Unit = row["unit"].ToString(),
                    Qty = Convert.ToDecimal(row["qty"]),
                    Rate = Convert.ToDecimal(row["rate"]),
                    Cost = Convert.ToDecimal(row["cost"]),
                    Comments = row["comments"].ToString(),
                    CreateDate = Convert.ToDateTime(row["create_date"]),
                    ResourceCostCode = row["cost_code"].ToString(),
                    CostCode = Convert.ToInt32(row["cost_code_id"]),
                    CheckStaus = Convert.ToBoolean(row["checkStatus"])

                });


            }
            return resourceDetails;

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="resources"></param>
        /// <returns></returns>
        public List<Resource> CostCalclationCostCoderpt(Resource resources)
        {
            List<Resource> resourceDetails = new List<Resource>();
            List<IDbDataParameter> parameters = new List<IDbDataParameter>();
            parameters.Add(myFactory.GetParameter("@Project_ID", resources.ProjectId));
            parameters.Add(myFactory.GetParameter("@cost_code", resources.CostCode));

            string query = "Cost_calculation_costcode_Pro";
            DataTable tbl = hlpr.GetDataTable(query, ref parameters);

            foreach (DataRow row in tbl.Rows)
            {
                resourceDetails.Add(new Resource()
                {

                    ResourceName = row["resource"].ToString(),
                    ItemName = row["item_name"].ToString(),
                    Supplier = row["supplier"].ToString(),
                    Unit = row["unit"].ToString(),
                    Qty = Convert.ToDecimal(row["qty"]),
                    Rate = Convert.ToDecimal(row["rate"]),
                    Cost = Convert.ToDecimal(row["cost"]),
                    Comments = row["comments"].ToString(),
                    CreateDate = Convert.ToDateTime(row["create_date"]),
                    ResourceCostCode = row["cost_code"].ToString()


                });


            }
            return resourceDetails;

        }
        public List<Resource> CostCodeWiseResource(Resource resources)
        {
            List<Resource> resourceDetails = new List<Resource>();
            List<IDbDataParameter> parameters = new List<IDbDataParameter>();
            parameters.Add(myFactory.GetParameter("@Project_ID", resources.ProjectId));
            parameters.Add(myFactory.GetParameter("@cost_code", resources.CostCode));
            parameters.Add(myFactory.GetParameter("@create_date", resources.CreateDate));
            string query = "select_resource_for_project_costcodeWise";
            DataTable tbl = hlpr.GetDataTable(query, ref parameters);

            foreach (DataRow row in tbl.Rows)
            {
                resourceDetails.Add(new Resource()
                {
                    ResourceId = Convert.ToInt32(row["resource_id"]),
                    ProjectId = Convert.ToInt32(row["project_id"]),
                    ResourceName = row["resource"].ToString(),
                    ItemName = row["item_name"].ToString(),
                    Supplier = row["supplier"].ToString(),
                    Unit = row["unit"].ToString(),
                    Qty = Convert.ToDecimal(row["qty"]),
                    Rate = Convert.ToDecimal(row["rate"]),
                    Cost = Convert.ToDecimal(row["cost"]),
                    Comments = row["comments"].ToString(),
                    CreateDate = Convert.ToDateTime(row["create_date"]),
                    CostCode = Convert.ToInt32(row["cost_code"])


                });


            }
            return resourceDetails;

        }
        public Resource GetResourceDetails(Resource resourceId)
        {
            var details = new Resource();
            List<IDbDataParameter> parameters = new List<IDbDataParameter>();
            parameters.Add(myFactory.GetParameter("@resource_id", resourceId.ResourceId));

            string query = "Edit_Resource_details_for_project";
            DataTable tbl = hlpr.GetDataTable(query, ref parameters);

            foreach (DataRow row in tbl.Rows)
            {
                details.ResourceId = Convert.ToInt32(row["resource_id"]);
                details.ResourceName = row["resource"].ToString();
                details.ItemName = row["item_name"].ToString();
                details.Supplier = row["supplier"].ToString();
                details.Unit = row["unit"].ToString();
                details.Qty = Convert.ToDecimal(row["qty"]);
                details.Rate = Convert.ToDecimal(row["rate"]);
                details.Cost = Convert.ToDecimal(row["cost"]);
                details.Comments = row["comments"].ToString();
                details.CreateDate = Convert.ToDateTime(row["create_date"]);
                details.ResourceCostCode = row["cost_code"].ToString();
            }
            return details;

        }

        public bool CreateResource(Resource res)
        {


            List <IDbDataParameter> parameters = new List<IDbDataParameter>();
            parameters.Add(myFactory.GetParameter("@project_id", res.ProjectId));
            parameters.Add(myFactory.GetParameter("@resource", res.ResourceName));
            parameters.Add(myFactory.GetParameter("@item_name", res.ItemName));
            parameters.Add(myFactory.GetParameter("@supplier", res.Supplier));
            parameters.Add(myFactory.GetParameter("@unit", res.Unit));
            parameters.Add(myFactory.GetParameter("@qty", res.Qty));
            parameters.Add(myFactory.GetParameter("@rate", res.Rate));
            parameters.Add(myFactory.GetParameter("@cost", res.Cost));
            parameters.Add(myFactory.GetParameter("@comments", res.Comments));
            parameters.Add(myFactory.GetParameter("@cost_code", res.CostCode));
            parameters.Add(myFactory.GetParameter("@create_date", res.CreateDate));
           return hlpr.ExecuteStoredProcedure("Add_resource", ref parameters);
        }
        public bool UpdateResource(Resource res)
        {
            List <IDbDataParameter> parameters = new List<IDbDataParameter>();
            parameters.Add(myFactory.GetParameter("@resource_id", res.ResourceId));
            parameters.Add(myFactory.GetParameter("@resource", res.ResourceName));
            parameters.Add(myFactory.GetParameter("@item_name", res.ItemName));
            parameters.Add(myFactory.GetParameter("@supplier", res.Supplier));
            parameters.Add(myFactory.GetParameter("@unit", res.Unit));
            parameters.Add(myFactory.GetParameter("@qty", res.Qty));
            parameters.Add(myFactory.GetParameter("@rate", res.Rate));
            parameters.Add(myFactory.GetParameter("@cost", res.Cost));
            parameters.Add(myFactory.GetParameter("@comments", res.Comments));
            parameters.Add(myFactory.GetParameter("@cost_code", res.CostCode));
            parameters.Add(myFactory.GetParameter("@create_date", res.CreateDate));
           return hlpr.ExecuteStoredProcedure("updateResourceDetailsforproject", ref parameters);
        }

        public bool DeleteResource(Resource res)
        {
            List<IDbDataParameter> parameters = new List<IDbDataParameter>();

            parameters.Add(myFactory.GetParameter("@resource_id", res.ResourceId));
            //return hlpr.ExecuteDmlQuery("DeleteUserDetails", ref parameters);
            return hlpr.ExecuteStoredProcedure("DeleteResourceDetails", ref parameters);

        }

     
        public Resource GetTotalCost(Resource resourceId)
        {
            var details = new Resource();
            List<IDbDataParameter> parameters = new List<IDbDataParameter>();
            parameters.Add(myFactory.GetParameter("@project_id", resourceId.ProjectId));

            string query = "GetAllProjectViewRecordTotal";
            DataTable tbl = hlpr.GetDataTable(query, ref parameters);

            foreach (DataRow row in tbl.Rows)
            {
                details.Cost = Convert.ToDecimal(row["cost"]);

            }
            return details;

        }
        public bool DeleteAllResource(Resource res)
        {
            List<IDbDataParameter> parameters = new List<IDbDataParameter>();

            parameters.Add(myFactory.GetParameter("@projectID", res.ProjectId));
            parameters.Add(myFactory.GetParameter("@create_date", res.CreateDate));
            //return hlpr.ExecuteDmlQuery("DeleteUserDetails", ref parameters);
            return hlpr.ExecuteStoredProcedure("UpdateDeleteResource", ref parameters);

        }
        public bool UpdateViewCostStatus(Resource res)
        {

            List<IDbDataParameter> parameters = new List<IDbDataParameter>();
            parameters.Add(myFactory.GetParameter("@resource_id", res.ResourceId));
            parameters.Add(myFactory.GetParameter("@checkStatus", res.CheckStaus));
            
            return hlpr.ExecuteStoredProcedure("updateVieCostSatus", ref parameters);
        }
        public List<ResourceNameArray> GetResourceName(ResourceNameArray resources)
        {
            List<ResourceNameArray> resourceName = new List<ResourceNameArray>();
            List<IDbDataParameter> parameters = new List<IDbDataParameter>();
            parameters.Add(myFactory.GetParameter("@projectID", resources.ProjectId));
            parameters.Add(myFactory.GetParameter("@resource", resources.ResourceName));
            string query = "Getresource";
            DataTable tbl = hlpr.GetDataTable(query, ref parameters);

            foreach (DataRow row in tbl.Rows)
            {
                resourceName.Add(new ResourceNameArray()
                {
                   
                    ResourceName = row["resource"].ToString(),
                   ItemName= row["item_name"].ToString(),
                    Supplier= row["supplier"].ToString()
                });


            }
            return resourceName;

        }
    }
}