using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using rg.framework.Data;
using rg.service.Models;

namespace rg.service.Data
{
    public class ProjectData
    {
        Factory myFactory;
        Helpers hlpr;

        public ProjectData()
        {
            myFactory = new Factory();
            hlpr = new Helpers();
        }

        public bool CreateProject(Project projects)
        {
           
            List < IDbDataParameter> parameters = new List<IDbDataParameter>();
            parameters.Add(myFactory.GetParameter("@project_name", projects.ProjectName));
            parameters.Add(myFactory.GetParameter("@project_code", projects.ProjrctCode));
            parameters.Add(myFactory.GetParameter("@project_address", projects.ProjectAddress));
            parameters.Add(myFactory.GetParameter("@project_description", projects.ProjectDescription));
            parameters.Add(myFactory.GetParameter("@project_client", projects.ProjectClient));
            parameters.Add(myFactory.GetParameter("@project_client_address", projects.ProjectClientAddress));
            parameters.Add(myFactory.GetParameter("@project_start_date", projects.ProjectStartDate));
            parameters.Add(myFactory.GetParameter("@project_completion_date", projects.ProjectCompletionDate));
            parameters.Add(myFactory.GetParameter("@rainbow_project_manager", projects.RainbowProjectManager));
            parameters.Add(myFactory.GetParameter("@rainbow_site_manager", projects.RainbowSiteManager));
            parameters.Add(myFactory.GetParameter("@project_client_project_manager", projects.ProjectClientProjectManager));
            parameters.Add(myFactory.GetParameter("@project_client_site_manager", projects.ProjectClientSiteManager));
            hlpr.ExecuteStoredProcedure("Add_Project", ref parameters);

            //product.ProductId = Convert.ToInt32(productId.Value);
            //Message = ResultText.Value.ToString();
            return true;
        }
        public bool UpdateProject(Project projects)
        {

            List<IDbDataParameter> parameters = new List<IDbDataParameter>();
            parameters.Add(myFactory.GetParameter("@ProjectID", projects.ProjectId));
            parameters.Add(myFactory.GetParameter("@project_name", projects.ProjectName));
            parameters.Add(myFactory.GetParameter("@project_code", projects.ProjrctCode));
            parameters.Add(myFactory.GetParameter("@project_address", projects.ProjectAddress));
            parameters.Add(myFactory.GetParameter("@project_description", projects.ProjectDescription));
            parameters.Add(myFactory.GetParameter("@project_client", projects.ProjectClient));
            parameters.Add(myFactory.GetParameter("@project_client_address", projects.ProjectClientAddress));
            parameters.Add(myFactory.GetParameter("@project_start_date", projects.ProjectStartDate));
            parameters.Add(myFactory.GetParameter("@project_completion_date", projects.ProjectCompletionDate));
            parameters.Add(myFactory.GetParameter("@rainbow_project_manager", projects.RainbowProjectManager));
            parameters.Add(myFactory.GetParameter("@rainbow_site_manager", projects.RainbowSiteManager));
            parameters.Add(myFactory.GetParameter("@project_client_project_manager", projects.ProjectClientProjectManager));
            parameters.Add(myFactory.GetParameter("@project_client_site_manager", projects.ProjectClientSiteManager));


            return hlpr.ExecuteStoredProcedure("update_project_Details", ref parameters); 

        }
        public List<Project> GetAllProjects()
        {
            List<Project> projects = new List<Project>();
            List<IDbDataParameter> parameters = new List<IDbDataParameter>();
            string query = "GetProjectList";
            DataTable tbl = hlpr.GetDataTable(query, ref parameters);


            foreach (DataRow row in tbl.Rows)
            {
                projects.Add(new Project()
                {
                   
                    ProjectId = Convert.ToInt32(row["ProjectID"]),
                    ProjectName = row["project_name"].ToString(),
                    ProjrctCode = row["project_code"].ToString(),
                    ProjectAddress = row["project_address"].ToString(),
                    ProjectClient = row["project_client"].ToString(),
                    ProjectStartDate = Convert.ToDateTime(row["project_start_date"] == DBNull.Value ? null : row["project_start_date"]),
                    ProjectCompletionDate = Convert.ToDateTime(row["finith_date"] == DBNull.Value ? null : row["finith_date"])
                });
            }
            return projects;

        }

        public List<Project> GetAllHiddenProjects()
        {
            List<Project> projects = new List<Project>();
            List<IDbDataParameter> parameters = new List<IDbDataParameter>();
            string query = "HideProjectList";
            DataTable tbl = hlpr.GetDataTable(query, ref parameters);


            foreach (DataRow row in tbl.Rows)
            {
                projects.Add(new Project()
                {

                    ProjectId = Convert.ToInt32(row["ProjectID"]),
                    ProjectName = row["project_name"].ToString(),
                    ProjrctCode = row["project_code"].ToString(),
                    ProjectAddress = row["project_address"].ToString(),
                    ProjectClient = row["project_client"].ToString(),
                    ProjectStartDate = Convert.ToDateTime(row["project_start_date"] == DBNull.Value ? null : row["project_start_date"]),
                    ProjectCompletionDate = Convert.ToDateTime(row["finith_date"] == DBNull.Value ? null : row["finith_date"])
                });
            }
            return projects;

        }

        public Project ProjectDetails(Project resources)
        {
           var projectDetails = new Project();
            List<IDbDataParameter> parameters = new List<IDbDataParameter>();
            parameters.Add(myFactory.GetParameter("@Project_ID", resources.ProjectId));

            string query = "Shows_Project_Details";
            DataTable tbl = hlpr.GetDataTable(query, ref parameters);

            foreach (DataRow row in tbl.Rows)
            {
               
                projectDetails.ProjectId = Convert.ToInt32(row["ProjectID"]);
                projectDetails.ProjectName = row["project_name"].ToString();
                projectDetails.ProjrctCode = row["project_code"].ToString();
                projectDetails.ProjectAddress = row["project_address"].ToString();
                projectDetails.ProjectDescription = row["project_description"].ToString();
                projectDetails.ProjectClient = row["project_client"].ToString();
                projectDetails.ProjectClientAddress = row["project_client_address"].ToString();
                projectDetails.ProjectStartDate = Convert.ToDateTime(row["project_start_date"]);
                projectDetails.ProjectCompletionDate = Convert.ToDateTime(row["project_completion_date"]);
                projectDetails.RainbowProjectManager = row["rainbow_project_manager"].ToString();
                projectDetails.RainbowSiteManager = row["rainbow_site_manager"].ToString();
                projectDetails.ProjectClientProjectManager = row["project_client_project_manager"].ToString();
                projectDetails.ProjectClientSiteManager = row["project_client_site_manager"].ToString();
                projectDetails.ProjectActivation = Convert.ToInt32(row["project_activation"]);
               


            }
            return projectDetails;

        }

        //public bool CreateUser(User users)
        //{

        //    List<IDbDataParameter> parameters = new List<IDbDataParameter>();
        //    parameters.Add(myFactory.GetParameter("@login_type", users.LoginType));
        //    parameters.Add(myFactory.GetParameter("@login_username", users.LoginUserName));
        //    parameters.Add(myFactory.GetParameter("@login_user_password", users.LoginPassword));
        //    parameters.Add(myFactory.GetParameter("@login_name", users.LoginName));
        //    parameters.Add(myFactory.GetParameter("@login_contact_number", users.LoginContactNumber));
        //    parameters.Add(myFactory.GetParameter("@login_email_id", users.LoginEmailId));
        //    parameters.Add(myFactory.GetParameter("@login_address", users.LoginAddress));
        //    parameters.Add(myFactory.GetParameter("@login_create_date", DateTime.UtcNow));
        //    //return hlpr.ExecuteDmlQuery("Add_New_user", ref parameters); 
        //    return hlpr.ExecuteStoredProcedure("Add_New_user", ref parameters);
        //}
        //public bool UpdateUser(User users)
        //{
        //    List<IDbDataParameter> parameters = new List<IDbDataParameter>();

        //    parameters.Add(myFactory.GetParameter("@login_id", users.LoginId));
        //    parameters.Add(myFactory.GetParameter("@login_type", users.LoginType));
        //    parameters.Add(myFactory.GetParameter("@login_username", users.LoginUserName));
        //    parameters.Add(myFactory.GetParameter("@login_user_password", users.LoginPassword));
        //    parameters.Add(myFactory.GetParameter("@login_name", users.LoginName));
        //    parameters.Add(myFactory.GetParameter("@login_contact_number", users.LoginContactNumber));
        //    parameters.Add(myFactory.GetParameter("@login_email_id", users.LoginEmailId));
        //    parameters.Add(myFactory.GetParameter("@login_address", users.LoginAddress));
        //    parameters.Add(myFactory.GetParameter("@login_create_date", DateTime.UtcNow));
        //    //return hlpr.ExecuteDmlQuery("update_User_Details", ref parameters);
        //    return hlpr.ExecuteStoredProcedure("update_User_Details", ref parameters);
        //}

        public bool ShowProject(Project projects)
        {
            List<IDbDataParameter> parameters = new List<IDbDataParameter>();
            parameters.Add(myFactory.GetParameter("@Project_ID", projects.ProjectId));
           return hlpr.ExecuteStoredProcedure("ShowProject", ref parameters);

        }
        public bool HideProject(Project projects)
        {
            List<IDbDataParameter> parameters = new List<IDbDataParameter>();
            parameters.Add(myFactory.GetParameter("@Project_ID", projects.ProjectId));
            return hlpr.ExecuteStoredProcedure("ShowHideProject", ref parameters);

        }

        //public Project ProjectNameClientName(Project resources)
        //{
        //    var projectDetails = new Project();
        //    List<IDbDataParameter> parameters = new List<IDbDataParameter>();
        //    parameters.Add(myFactory.GetParameter("@ProjectID", resources.ProjectId));
        //    parameters.Add(myFactory.GetParameter("@Date", resources.ProjectStartDate));
        //    string query = "project_selection_update_Cost";
        //    DataTable tbl = hlpr.GetDataTable(query, ref parameters);

        //    foreach (DataRow row in tbl.Rows)
        //    {
        //     projectDetails.ProjectName = row["project_name"].ToString();
        //      projectDetails.ProjectClient = row["project_client"].ToString();
        //      projectDetails.ProjectStartDate = Convert.ToDateTime(row["Date"]);
        //    }
        //    return projectDetails;

        //}

        public List<Project> GetAdminUserProjects(Project loginId)
        {
            List<Project> projects = new List<Project>();
            List<IDbDataParameter> parameters = new List<IDbDataParameter>();
            parameters.Add(myFactory.GetParameter("@login_id", loginId.LoginId));
            string query = "user_Project_Details";
            DataTable tbl = hlpr.GetDataTable(query, ref parameters);


            foreach (DataRow row in tbl.Rows)
            {
                projects.Add(new Project()
                {

                    ProjectId = Convert.ToInt32(row["ProjectID"]),
                    ProjectName = row["project_name"].ToString(),
                    ProjrctCode = row["project_code"].ToString(),
                    ProjectAddress = row["project_address"].ToString(),
                    ProjectClient = row["project_client"].ToString(),
                    ProjectStartDate = Convert.ToDateTime(row["project_start_date"] == DBNull.Value ? null : row["project_start_date"]),
                    ProjectCompletionDate = Convert.ToDateTime(row["finith_date"] == DBNull.Value ? null : row["finith_date"])
                });
            }
            return projects;

        }

        public List<Project> GetAdminUserHiddenProjects(Project loginId)
        {
            List<Project> projects = new List<Project>();
            List<IDbDataParameter> parameters = new List<IDbDataParameter>();
            parameters.Add(myFactory.GetParameter("@login_id", loginId.LoginId));
            string query = "Hidden_user_Project_Details";
            DataTable tbl = hlpr.GetDataTable(query, ref parameters);


            foreach (DataRow row in tbl.Rows)
            {
                projects.Add(new Project()
                {

                    ProjectId = Convert.ToInt32(row["ProjectID"]),
                    ProjectName = row["project_name"].ToString(),
                    ProjrctCode = row["project_code"].ToString(),
                    ProjectAddress = row["project_address"].ToString(),
                    ProjectClient = row["project_client"].ToString(),
                    ProjectStartDate = Convert.ToDateTime(row["project_start_date"] == DBNull.Value ? null : row["project_start_date"]),
                    ProjectCompletionDate = Convert.ToDateTime(row["finith_date"] == DBNull.Value ? null : row["finith_date"])
                });
            }
            return projects;

        }
        public List<Project> AdminUserProjectList(Project loginId)
        {
            List<Project> projects = new List<Project>();
            List<IDbDataParameter> parameters = new List<IDbDataParameter>();
            parameters.Add(myFactory.GetParameter("@login_id", loginId.LoginId));
            string query = "ShowsProjectList_admin";
            DataTable tbl = hlpr.GetDataTable(query, ref parameters);


            foreach (DataRow row in tbl.Rows)
            {
                projects.Add(new Project()
                {
                    ProjectId = Convert.ToInt32(row["ProjectID"]),
                    ProjectName = row["project_name"].ToString(),
                 });
            }
            return projects;

        }
    }
}