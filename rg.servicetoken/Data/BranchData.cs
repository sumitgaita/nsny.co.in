using rg.framework.Data;
using rg.service.Models;
using System;
using System.Collections.Generic;
using System.Data;

namespace rg.service.Data
{
    public class BranchData
    {
        private Factory myFactory;
        private Helpers hlpr;

        public BranchData()
        {
            myFactory = new Factory();
            hlpr = new Helpers();
        }

        public bool CreateBranch(Branch branch)
        {

            List<IDbDataParameter> parameters = new List<IDbDataParameter>
            {
                myFactory.GetParameter("@name", branch.Bname),
                myFactory.GetParameter("@contact", branch.Bcontact),
                myFactory.GetParameter("@commission", branch.Bcommission),
                myFactory.GetParameter("@email", branch.Bemail),
                myFactory.GetParameter("@pass", branch.Bpass),
                myFactory.GetParameter("@r1", ""),
                myFactory.GetParameter("@r2", ""),
                myFactory.GetParameter("@r3", Convert.ToInt32(0)),
                myFactory.GetParameter("@act", Convert.ToInt32(1)),
                myFactory.GetParameter("@paymentmode", branch.Paymentmode)
            };
            return hlpr.ExecuteStoredProcedure("BranchInsert", ref parameters);
        }
        public bool CreateBranchNotification(Notification notification)
        {

            List<IDbDataParameter> parameters = new List<IDbDataParameter>
            {
                myFactory.GetParameter("@title", notification.Title),
                myFactory.GetParameter("@content_details", notification.Content_details),
                myFactory.GetParameter("@bid", notification.Bid),
                myFactory.GetParameter("@activation", notification.Activation)
            };
            return hlpr.ExecuteStoredProcedure("NotificationInsert", ref parameters);
        }

        public bool UpdateBranch(Branch branch)
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
                myFactory.GetParameter("@paymentmode", branch.Paymentmode)

             };
            return hlpr.ExecuteStoredProcedure("BranchUpdate", ref parameters);

        }

        public bool DeleteBranch(Branch per)
        {
            List<IDbDataParameter> parameters = new List<IDbDataParameter>
            {
                myFactory.GetParameter("@id", per.Id)
            };
            return hlpr.ExecuteStoredProcedure("BranchDelete", ref parameters);

        }
        //public List<Project> GetAllProjects()
        //{
        //    List<Project> projects = new List<Project>();
        //    List<IDbDataParameter> parameters = new List<IDbDataParameter>();
        //    string query = "GetProjectList";
        //    DataTable tbl = hlpr.GetDataTable(query, ref parameters);


        //    foreach (DataRow row in tbl.Rows)
        //    {
        //        projects.Add(new Project()
        //        {

        //            ProjectId = Convert.ToInt32(row["ProjectID"]),
        //            ProjectName = row["project_name"].ToString(),
        //            ProjrctCode = row["project_code"].ToString(),
        //            ProjectAddress = row["project_address"].ToString(),
        //            ProjectClient = row["project_client"].ToString(),
        //            ProjectStartDate = Convert.ToDateTime(row["project_start_date"] == DBNull.Value ? null : row["project_start_date"]),
        //            ProjectCompletionDate = Convert.ToDateTime(row["finith_date"] == DBNull.Value ? null : row["finith_date"])
        //        });
        //    }
        //    return projects;

        //}

        public List<Branch> GetAllBranch()
        {
            List<Branch> brach = new List<Branch>();
            List<IDbDataParameter> parameters = new List<IDbDataParameter>();
            string query = "GetBranchList";
            DataTable tbl = hlpr.GetDataTable(query, ref parameters);
            foreach (DataRow row in tbl.Rows)
            {
                brach.Add(new Branch()
                {

                    Id = Convert.ToInt32(row["id"]),
                    Bname = row["name"].ToString(),
                    Bcontact = row["contact"].ToString(),
                    Bemail = row["email"].ToString(),
                    Bcommission = !row.IsNull("commission") ? Convert.ToInt32(row["commission"]) : 0,
                    Bpass = row["pass"].ToString(),
                    Paymentmode= row["paymentmode"].ToString()

                });
            }
            return brach;
        }
        public int CurrntBranchId()
        {
            int student = 0;
            List<IDbDataParameter> parameters = new List<IDbDataParameter>();
            string query = "GetcurrentBranchId";
            DataTable tbl = hlpr.GetDataTable(query, ref parameters);
            foreach (DataRow row in tbl.Rows)
            {
                student = Convert.ToInt32(row["currntId"]);

            }
            return student;
        }

        public List<Notification> GetBranchNotification(int bid)
        {
            List<Notification> notification = new List<Notification>();
            List<IDbDataParameter> parameters = new List<IDbDataParameter>
            {
                myFactory.GetParameter("@bid", bid)
            };
            string query = "GetBranchNotification";
            DataTable tbl = hlpr.GetDataTable(query, ref parameters);
            foreach (DataRow row in tbl.Rows)
            {
                notification.Add(new Notification()
                {

                    Id = Convert.ToInt32(row["id"]),
                    Bid = !row.IsNull("bid") ? Convert.ToInt32(row["bid"]) : 0,
                    Title = row["title"].ToString(),
                    Content_details = row["content_details"].ToString()

                });
            }
            return notification;
        }
        public List<Notification> GetAllNotification()
        {
            List<Notification> notification = new List<Notification>();
            List<IDbDataParameter> parameters = new List<IDbDataParameter>();
            string query = "GetAllNotification";
            DataTable tbl = hlpr.GetDataTable(query, ref parameters);
            foreach (DataRow row in tbl.Rows)
            {
                notification.Add(new Notification()
                {

                    Id = Convert.ToInt32(row["id"]),
                    Bid = !row.IsNull("bid") ? Convert.ToInt32(row["bid"]) : 0,
                    Title = row["title"].ToString(),
                    Content_details = row["content_details"].ToString(),
                    Bname= row["name"].ToString()
                });
            }
            return notification;
        }
        public bool DeleteNotification(Notification id)
        {
            List<IDbDataParameter> parameters = new List<IDbDataParameter>
            {
                myFactory.GetParameter("@id", id.Id)
            };
            return hlpr.ExecuteStoredProcedure("DeleteNotification", ref parameters);

        }
        //public Project ProjectDetails(Project resources)
        //{
        //   var projectDetails = new Project();
        //    List<IDbDataParameter> parameters = new List<IDbDataParameter>();
        //    parameters.Add(myFactory.GetParameter("@Project_ID", resources.ProjectId));

        //    string query = "Shows_Project_Details";
        //    DataTable tbl = hlpr.GetDataTable(query, ref parameters);

        //    foreach (DataRow row in tbl.Rows)
        //    {

        //        projectDetails.ProjectId = Convert.ToInt32(row["ProjectID"]);
        //        projectDetails.ProjectName = row["project_name"].ToString();
        //        projectDetails.ProjrctCode = row["project_code"].ToString();
        //        projectDetails.ProjectAddress = row["project_address"].ToString();
        //        projectDetails.ProjectDescription = row["project_description"].ToString();
        //        projectDetails.ProjectClient = row["project_client"].ToString();
        //        projectDetails.ProjectClientAddress = row["project_client_address"].ToString();
        //        projectDetails.ProjectStartDate = Convert.ToDateTime(row["project_start_date"]);
        //        projectDetails.ProjectCompletionDate = Convert.ToDateTime(row["project_completion_date"]);
        //        projectDetails.RainbowProjectManager = row["rainbow_project_manager"].ToString();
        //        projectDetails.RainbowSiteManager = row["rainbow_site_manager"].ToString();
        //        projectDetails.ProjectClientProjectManager = row["project_client_project_manager"].ToString();
        //        projectDetails.ProjectClientSiteManager = row["project_client_site_manager"].ToString();
        //        projectDetails.ProjectActivation = Convert.ToInt32(row["project_activation"]);



        //    }
        //    return projectDetails;

        //}

        ////public bool CreateUser(User users)
        ////{

        ////    List<IDbDataParameter> parameters = new List<IDbDataParameter>();
        ////    parameters.Add(myFactory.GetParameter("@login_type", users.LoginType));
        ////    parameters.Add(myFactory.GetParameter("@login_username", users.LoginUserName));
        ////    parameters.Add(myFactory.GetParameter("@login_user_password", users.LoginPassword));
        ////    parameters.Add(myFactory.GetParameter("@login_name", users.LoginName));
        ////    parameters.Add(myFactory.GetParameter("@login_contact_number", users.LoginContactNumber));
        ////    parameters.Add(myFactory.GetParameter("@login_email_id", users.LoginEmailId));
        ////    parameters.Add(myFactory.GetParameter("@login_address", users.LoginAddress));
        ////    parameters.Add(myFactory.GetParameter("@login_create_date", DateTime.UtcNow));
        ////    //return hlpr.ExecuteDmlQuery("Add_New_user", ref parameters); 
        ////    return hlpr.ExecuteStoredProcedure("Add_New_user", ref parameters);
        ////}
        ////public bool UpdateUser(User users)
        ////{
        ////    List<IDbDataParameter> parameters = new List<IDbDataParameter>();

        ////    parameters.Add(myFactory.GetParameter("@login_id", users.LoginId));
        ////    parameters.Add(myFactory.GetParameter("@login_type", users.LoginType));
        ////    parameters.Add(myFactory.GetParameter("@login_username", users.LoginUserName));
        ////    parameters.Add(myFactory.GetParameter("@login_user_password", users.LoginPassword));
        ////    parameters.Add(myFactory.GetParameter("@login_name", users.LoginName));
        ////    parameters.Add(myFactory.GetParameter("@login_contact_number", users.LoginContactNumber));
        ////    parameters.Add(myFactory.GetParameter("@login_email_id", users.LoginEmailId));
        ////    parameters.Add(myFactory.GetParameter("@login_address", users.LoginAddress));
        ////    parameters.Add(myFactory.GetParameter("@login_create_date", DateTime.UtcNow));
        ////    //return hlpr.ExecuteDmlQuery("update_User_Details", ref parameters);
        ////    return hlpr.ExecuteStoredProcedure("update_User_Details", ref parameters);
        ////}

        //public bool ShowProject(Project projects)
        //{
        //    List<IDbDataParameter> parameters = new List<IDbDataParameter>();
        //    parameters.Add(myFactory.GetParameter("@Project_ID", projects.ProjectId));
        //   return hlpr.ExecuteStoredProcedure("ShowProject", ref parameters);

        //}
        //public bool HideProject(Project projects)
        //{
        //    List<IDbDataParameter> parameters = new List<IDbDataParameter>();
        //    parameters.Add(myFactory.GetParameter("@Project_ID", projects.ProjectId));
        //    return hlpr.ExecuteStoredProcedure("ShowHideProject", ref parameters);

        //}

        ////public Project ProjectNameClientName(Project resources)
        ////{
        ////    var projectDetails = new Project();
        ////    List<IDbDataParameter> parameters = new List<IDbDataParameter>();
        ////    parameters.Add(myFactory.GetParameter("@ProjectID", resources.ProjectId));
        ////    parameters.Add(myFactory.GetParameter("@Date", resources.ProjectStartDate));
        ////    string query = "project_selection_update_Cost";
        ////    DataTable tbl = hlpr.GetDataTable(query, ref parameters);

        ////    foreach (DataRow row in tbl.Rows)
        ////    {
        ////     projectDetails.ProjectName = row["project_name"].ToString();
        ////      projectDetails.ProjectClient = row["project_client"].ToString();
        ////      projectDetails.ProjectStartDate = Convert.ToDateTime(row["Date"]);
        ////    }
        ////    return projectDetails;

        ////}

        //public List<Project> GetAdminUserProjects(Project loginId)
        //{
        //    List<Project> projects = new List<Project>();
        //    List<IDbDataParameter> parameters = new List<IDbDataParameter>();
        //    parameters.Add(myFactory.GetParameter("@login_id", loginId.LoginId));
        //    string query = "user_Project_Details";
        //    DataTable tbl = hlpr.GetDataTable(query, ref parameters);


        //    foreach (DataRow row in tbl.Rows)
        //    {
        //        projects.Add(new Project()
        //        {

        //            ProjectId = Convert.ToInt32(row["ProjectID"]),
        //            ProjectName = row["project_name"].ToString(),
        //            ProjrctCode = row["project_code"].ToString(),
        //            ProjectAddress = row["project_address"].ToString(),
        //            ProjectClient = row["project_client"].ToString(),
        //            ProjectStartDate = Convert.ToDateTime(row["project_start_date"] == DBNull.Value ? null : row["project_start_date"]),
        //            ProjectCompletionDate = Convert.ToDateTime(row["finith_date"] == DBNull.Value ? null : row["finith_date"])
        //        });
        //    }
        //    return projects;

        //}

        //public List<Project> GetAdminUserHiddenProjects(Project loginId)
        //{
        //    List<Project> projects = new List<Project>();
        //    List<IDbDataParameter> parameters = new List<IDbDataParameter>();
        //    parameters.Add(myFactory.GetParameter("@login_id", loginId.LoginId));
        //    string query = "Hidden_user_Project_Details";
        //    DataTable tbl = hlpr.GetDataTable(query, ref parameters);


        //    foreach (DataRow row in tbl.Rows)
        //    {
        //        projects.Add(new Project()
        //        {

        //            ProjectId = Convert.ToInt32(row["ProjectID"]),
        //            ProjectName = row["project_name"].ToString(),
        //            ProjrctCode = row["project_code"].ToString(),
        //            ProjectAddress = row["project_address"].ToString(),
        //            ProjectClient = row["project_client"].ToString(),
        //            ProjectStartDate = Convert.ToDateTime(row["project_start_date"] == DBNull.Value ? null : row["project_start_date"]),
        //            ProjectCompletionDate = Convert.ToDateTime(row["finith_date"] == DBNull.Value ? null : row["finith_date"])
        //        });
        //    }
        //    return projects;

        //}
        //public List<Project> AdminUserProjectList(Project loginId)
        //{
        //    List<Project> projects = new List<Project>();
        //    List<IDbDataParameter> parameters = new List<IDbDataParameter>();
        //    parameters.Add(myFactory.GetParameter("@login_id", loginId.LoginId));
        //    string query = "ShowsProjectList_admin";
        //    DataTable tbl = hlpr.GetDataTable(query, ref parameters);


        //    foreach (DataRow row in tbl.Rows)
        //    {
        //        projects.Add(new Project()
        //        {
        //            ProjectId = Convert.ToInt32(row["ProjectID"]),
        //            ProjectName = row["project_name"].ToString(),
        //         });
        //    }
        //    return projects;

        //}
    }
}