using rg.framework.Data;
using rg.service.Models;
using System;
using System.Collections.Generic;
using System.Data;

namespace rg.service.Data
{
    public class BranchStudentBindData
    {
        private Factory myFactory;
        private Helpers hlpr;

        public BranchStudentBindData()
        {
            myFactory = new Factory();
            hlpr = new Helpers();
        }

        public bool CreateBranchStudentBind(BranchStudentBind branchStudentBind)
        {

            List<IDbDataParameter> parameters = new List<IDbDataParameter>
            {
                myFactory.GetParameter("@bid", branchStudentBind.Scbid),
                myFactory.GetParameter("@bname", branchStudentBind.Scbname),
                myFactory.GetParameter("@stid", branchStudentBind.Scstid),
                myFactory.GetParameter("@cid", branchStudentBind.Sccid),
                myFactory.GetParameter("@ctotal", branchStudentBind.Scctotal),
                myFactory.GetParameter("@ctype", branchStudentBind.Scctype),
                myFactory.GetParameter("@cdiscount", branchStudentBind.Sccdiscount),
                myFactory.GetParameter("@sjoin", branchStudentBind.Scsjoin),
                myFactory.GetParameter("@amountremaing", branchStudentBind.Scamountremaing),
                myFactory.GetParameter("@lastamountpay", branchStudentBind.Sclastamountpay),
                myFactory.GetParameter("@dateofpayment", branchStudentBind.Scdateofpayment),
                myFactory.GetParameter("@totalInstallment", branchStudentBind.SctotalInstallment),
                myFactory.GetParameter("@remainginstallment", branchStudentBind.Scremainginstallment),
                myFactory.GetParameter("@paymentclear", branchStudentBind.Scpaymentclear),
                myFactory.GetParameter("@theory", branchStudentBind.Theory==null?"0":branchStudentBind.Theory),
                myFactory.GetParameter("@practical", branchStudentBind.Practical==null?"0":branchStudentBind.Practical)
            };
            return hlpr.ExecuteStoredProcedure("StudentCourseInsert", ref parameters);
        }

        public bool StudentCourseBindUpdate(BranchStudentBind branchStudentBind)
        {
            List<IDbDataParameter> parameters = new List<IDbDataParameter>
            {
                myFactory.GetParameter("@id", branchStudentBind.Id),
                myFactory.GetParameter("@cid", branchStudentBind.Sccid),
                myFactory.GetParameter("@ctotal", branchStudentBind.Scctotal),
                myFactory.GetParameter("@ctype", branchStudentBind.Scctype),
                myFactory.GetParameter("@cdiscount", branchStudentBind.Sccdiscount),
                myFactory.GetParameter("@sjoin", branchStudentBind.Scsjoin),
                myFactory.GetParameter("@amountremaing", branchStudentBind.Scamountremaing),
                myFactory.GetParameter("@lastamountpay", branchStudentBind.Sclastamountpay),
                myFactory.GetParameter("@dateofpayment", branchStudentBind.Scdateofpayment),
                myFactory.GetParameter("@totalInstallment", branchStudentBind.SctotalInstallment),
                myFactory.GetParameter("@remainginstallment", branchStudentBind.Scremainginstallment),
                myFactory.GetParameter("@paymentclear", branchStudentBind.Scpaymentclear),
                myFactory.GetParameter("@theory", branchStudentBind.Theory==null?"0":branchStudentBind.Theory),
                myFactory.GetParameter("@practical", branchStudentBind.Practical==null?"0":branchStudentBind.Practical),
                myFactory.GetParameter("@coursecatagory", branchStudentBind.CourseCatagory)
             };
            return hlpr.ExecuteStoredProcedure("StudentCourseBindUpdate", ref parameters);
        }

        public List<BranchPaymentCollection> GetCourseBindList(string stid)
        {
            List<BranchPaymentCollection> branchcollection = new List<BranchPaymentCollection>();
            List<IDbDataParameter> parameters = new List<IDbDataParameter>
            {
                myFactory.GetParameter("@stid", stid)
            };
            string query = "GetCourseBindList";
            DataTable tbl = hlpr.GetDataTable(query, ref parameters);
            foreach (DataRow row in tbl.Rows)
            {
                branchcollection.Add(new BranchPaymentCollection()
                {
                    Id = !row.IsNull("id") ? Convert.ToInt32(row["id"]) : 0,
                    Bid = !row.IsNull("bid") ? Convert.ToInt32(row["bid"]) : 0,
                    Bname = row["bname"].ToString(),
                    Stid = row["stid"].ToString(),
                    Cid = !row.IsNull("cid") ? Convert.ToInt32(row["cid"]) : 0,
                    Ctotal = !row.IsNull("ctotal") ? Convert.ToInt32(row["ctotal"]) : 0,
                    Ctype = row["ctype"].ToString(),
                    Cdiscount = !row.IsNull("cdiscount") ? Convert.ToInt32(row["cdiscount"]) : 0,
                    Sjoin = row["sjoin"].ToString(),
                    Amountremaing = !row.IsNull("amountremaing") ? Convert.ToInt32(row["amountremaing"]) : 0,
                    Lastamountpay = !row.IsNull("lastamountpay") ? Convert.ToInt32(row["lastamountpay"]) : 0,
                    Binddateofpayment = row["dateofpayment"].ToString(),
                    TotalInstallment = !row.IsNull("totalInstallment") ? Convert.ToInt32(row["totalInstallment"]) : 0,
                    Remainginstallment = !row.IsNull("remainginstallment") ? Convert.ToInt32(row["remainginstallment"]) : 0,
                    Paymentclear = row["paymentclear"].ToString(),
                    Cname = row["cname"].ToString(),
                    PaymentId = !row.IsNull("paymentId") ? Convert.ToInt32(row["paymentId"]) : 0,
                    Amount_crpay = !row.IsNull("amount_cr") ? Convert.ToInt32(row["amount_cr"]) : 0,
                    Amount_repay = !row.IsNull("amount_re") ? Convert.ToInt32(row["amount_re"]) : 0,
                    Theory = !row.IsNull("theory") ? row["theory"].ToString() : "0",
                    Practical = !row.IsNull("practical") ? row["practical"].ToString() : "0",
                    stname = !row.IsNull("name") ? row["name"].ToString() : "",
                    CourseCatagory = !row.IsNull("coursecatagory") ? Convert.ToInt32(row["coursecatagory"]) : 0,
                });
            }
            return branchcollection;

        }
        public bool CreatePaymentollection(BranchPaymentCollection branchPaymentCollection)
        {

            List<IDbDataParameter> parameters = new List<IDbDataParameter>
            {
                myFactory.GetParameter("@stid", branchPaymentCollection.Stid),
                myFactory.GetParameter("@bid", branchPaymentCollection.Bid),
                myFactory.GetParameter("@cid", branchPaymentCollection.Cid),
                myFactory.GetParameter("@ctotal", branchPaymentCollection.Ctotal),
                myFactory.GetParameter("@cpaid", branchPaymentCollection.Cpaid),
                myFactory.GetParameter("@cdiscount", branchPaymentCollection.Cdiscount),
                myFactory.GetParameter("@stpaydate", branchPaymentCollection.Dateofpayment),
                myFactory.GetParameter("@stbalance", branchPaymentCollection.Stbalance),
                myFactory.GetParameter("@stinstall", branchPaymentCollection.TotalInstallment),
                myFactory.GetParameter("@stinstallremain", branchPaymentCollection.Remainginstallment),
                myFactory.GetParameter("@momono", branchPaymentCollection.Momono)
            };
            return hlpr.ExecuteStoredProcedure("StudentPaymentInsert", ref parameters);
        }

        public int CheckWalletBalance(int bid, int cid)
        {
            int exitingBalance = 0;
            List<IDbDataParameter> parameters = new List<IDbDataParameter>
            {
                myFactory.GetParameter("@bid", bid),
                myFactory.GetParameter("@cid", cid)
            };
            string query = "CheckWalletBalanceBYBranch";
            DataTable tbl = hlpr.GetDataTable(query, ref parameters);
            foreach (DataRow row in tbl.Rows)
            {
                exitingBalance = !row.IsNull("exitingAmount") ? Convert.ToInt32(row["exitingAmount"]):0;

            }
            return exitingBalance;
        }

        public bool PaymentLastUpdate(BranchPaymentCollection branchPaymentCollection)
        {
            List<IDbDataParameter> parameters = new List<IDbDataParameter>
            {
                myFactory.GetParameter("@stid", branchPaymentCollection.Stid),
                myFactory.GetParameter("@lastamountpay", branchPaymentCollection.Cpaid),
                myFactory.GetParameter("@dateofpayment", branchPaymentCollection.Dateofpayment),
                myFactory.GetParameter("@remainginstallment", branchPaymentCollection.Remainginstallment),
                myFactory.GetParameter("@amountremaing", branchPaymentCollection.Amountremaing),
                myFactory.GetParameter("@paymentclear", branchPaymentCollection.Paymentclear)
             };
            return hlpr.ExecuteStoredProcedure("PaymentLastUpdate", ref parameters);
        }

        //public bool DeleteCourse(Course per)
        //{
        //    List<IDbDataParameter> parameters = new List<IDbDataParameter>
        //    {
        //        myFactory.GetParameter("@id", per.Id)
        //    };
        //    return hlpr.ExecuteStoredProcedure("DeleteCourse", ref parameters);

        //}
        public List<BranchPaymentCollection> GetBranchPaymentCollection(int branchId)
        {
            List<BranchPaymentCollection> branchcollection = new List<BranchPaymentCollection>();
            List<IDbDataParameter> parameters = new List<IDbDataParameter>
            {
                myFactory.GetParameter("@bid", branchId)
            };
            string query = "Select_StuPayment";
            DataTable tbl = hlpr.GetDataTable(query, ref parameters);
            foreach (DataRow row in tbl.Rows)
            {
                branchcollection.Add(new BranchPaymentCollection()
                {
                    Id = !row.IsNull("id") ? Convert.ToInt32(row["id"]):0,
                    Bid = !row.IsNull("bid") ? Convert.ToInt32(row["bid"]) : 0,
                    Bname = row["Bname"].ToString(),
                    Stid = row["Stid"].ToString(),
                    Sname = row["Sname"].ToString(),
                    Cname = row["Cname"].ToString(),
                    Cid = !row.IsNull("cid") ? Convert.ToInt32(row["cid"]) : 0,
                    Ctotal = !row.IsNull("Ctotal") ? Convert.ToInt32(row["Ctotal"]) : 0,
                    Ctype = row["Ctype"].ToString(),
                    Cdiscount = !row.IsNull("Cdiscount") ? Convert.ToInt32(row["Cdiscount"]) : 0,
                    Sjoin = row["Sjoin"].ToString(),
                    Amountremaing = !row.IsNull("Amountremaing") ? Convert.ToInt32(row["Amountremaing"]) : 0,
                    Lastamountpay = !row.IsNull("Lastamountpay") ? Convert.ToInt32(row["Lastamountpay"]) : 0,
                    Dateofpayment = Convert.ToDateTime(row["Dateofpayment"]),
                    Remainginstallment = !row.IsNull("Remainginstallment") ? Convert.ToInt32(row["Remainginstallment"]) : 0,
                    Paymentclear = row["Paymentclear"].ToString(),
                    TotalInstallment = !row.IsNull("TotalInstallment") ? Convert.ToInt32(row["TotalInstallment"]) : 0
                });
            }
            return branchcollection;

        }

        public List<BranchPaymentCollection> GetBranchPaymenteraning(int branchId, string fromdate, string todate)
        {
            List<BranchPaymentCollection> branchpaymenteraning = new List<BranchPaymentCollection>();
            List<IDbDataParameter> parameters = new List<IDbDataParameter>
            {
                myFactory.GetParameter("@bid", branchId),
                myFactory.GetParameter("@fromdate", Convert.ToDateTime(fromdate)),
                myFactory.GetParameter("@todate", Convert.ToDateTime(todate))
            };
            string query = "Select_Paymenteraning";
            DataTable tbl = hlpr.GetDataTable(query, ref parameters);
            foreach (DataRow row in tbl.Rows)
            {
                branchpaymenteraning.Add(new BranchPaymentCollection()
                {
                    Stid = row["stid"].ToString(),
                    Ctotal = !row.IsNull("ctotal") ? Convert.ToInt32(row["ctotal"]) : 0,
                    Cpaid = !row.IsNull("cpaid") ? Convert.ToInt32(row["cpaid"]) : 0,
                    Cdiscount = !row.IsNull("cdiscount") ? Convert.ToInt32(row["cdiscount"]) : 0,
                    Dateofpayment = Convert.ToDateTime(row["stpaydate"] == DBNull.Value ? null : row["stpaydate"]),
                    Stbalance = !row.IsNull("stbalance") ? Convert.ToInt32(row["stbalance"]) : 0,
                    Stinstall = !row.IsNull("stinstall") ? Convert.ToInt32(row["stinstall"]) : 0,
                    Stinstallremain = !row.IsNull("stinstallremain") ? Convert.ToInt32(row["stinstallremain"]) : 0
                });
            }
            return branchpaymenteraning;

        }

        public int PaymenCount(int branchId, string dt)
        {
            int details = 0;
            List<IDbDataParameter> parameters = new List<IDbDataParameter>
            {
                myFactory.GetParameter("@bid", branchId),
                myFactory.GetParameter("@dt", dt)
            };
            string query = "studentPaymenCount1";
            DataTable tbl = hlpr.GetDataTable(query, ref parameters);
            foreach (DataRow row in tbl.Rows)
            {
                details = !row.IsNull(0) ? Convert.ToInt32(row[0]) : 0;

            }
            return details;
        }

        public List<BranchPaymentCollection> GetRecivedPrint(string stid)
        {
            List<BranchPaymentCollection> branchcollection = new List<BranchPaymentCollection>();
            List<IDbDataParameter> parameters = new List<IDbDataParameter>
            {
                myFactory.GetParameter("@stid", stid)
            };
            string query = "ViewRecipt";
            DataTable tbl = hlpr.GetDataTable(query, ref parameters);
            foreach (DataRow row in tbl.Rows)
            {
                branchcollection.Add(new BranchPaymentCollection()
                {
                    Id = !row.IsNull("id") ? Convert.ToInt32(row["id"]) : 0,
                    Stid = row["stid"].ToString(),
                    Sname = row["nam"].ToString(),
                    Cname = row["cour"].ToString(),
                    Dateofpayment = Convert.ToDateTime(row["stpaydate"] == DBNull.Value ? null : row["stpaydate"]),
                    Momono = row["momono"].ToString(),
                    Cpaid = !row.IsNull("cpaid") ? Convert.ToInt32(row["cpaid"]) : 0
                });
            }
            return branchcollection;

        }

        public List<BranchPaymentCollection> GetStuRegistrationList(int branchId, string fromdate, string todate)
        {
            List<BranchPaymentCollection> branchpaymenteraning = new List<BranchPaymentCollection>();
            List<IDbDataParameter> parameters = new List<IDbDataParameter>
            {
                myFactory.GetParameter("@bid", branchId),
                myFactory.GetParameter("@fromdate", Convert.ToDateTime(fromdate)),
                myFactory.GetParameter("@todate", Convert.ToDateTime(todate))
            };
            string query = "GetStuRegistrationList";
            DataTable tbl = hlpr.GetDataTable(query, ref parameters);
            foreach (DataRow row in tbl.Rows)
            {
                branchpaymenteraning.Add(new BranchPaymentCollection()
                {
                    Bname = row["branch"].ToString(),
                    Stid = row["stid"].ToString(),
                    Cname = row["course"].ToString(),
                    Ctotal = !row.IsNull("ctotal") ? Convert.ToInt32(row["ctotal"]) : 0,
                    Ctype = row["ctype"].ToString(),
                    Cdiscount = !row.IsNull("cdiscount") ? Convert.ToInt32(row["cdiscount"]) : 0,
                    Sjoin = row["sjoin"].ToString(),
                    Paymentclear = row["paymentclear"].ToString()
                });
            }
            return branchpaymenteraning;

        }
        public List<BranchPaymentCollection> GetAdminStudentIcard(int branchId, string fromdate, string todate)
        {
            List<BranchPaymentCollection> branchpaymenteraning = new List<BranchPaymentCollection>();
            List<IDbDataParameter> parameters = new List<IDbDataParameter>
            {
                myFactory.GetParameter("@bid", branchId),
                myFactory.GetParameter("@fromdate", Convert.ToDateTime(fromdate)),
                myFactory.GetParameter("@todate", Convert.ToDateTime(todate))
            };
            string query = "GetAdminStudentIcard";
            DataTable tbl = hlpr.GetDataTable(query, ref parameters);
            foreach (DataRow row in tbl.Rows)
            {
                branchpaymenteraning.Add(new BranchPaymentCollection()
                {
                    Stid = row["stid"].ToString(),
                    Sname = row["name"].ToString(),
                    Guardian = row["guardian"].ToString(),
                    Address = row["address"].ToString(),
                    Mobile = row["mobile"].ToString(),
                    Pic = row["pic"].ToString(),
                    Bname = row["branch"].ToString(),
                    Bid = !row.IsNull("bbid") ? Convert.ToInt32(row["bbid"]) : 0,
                    Cname = row["course"].ToString(),
                    Sjoin = row["sjoin"].ToString(),
                    C1 = row["c1"].ToString(),
                    C2 = row["c2"].ToString(),
                    Duration = row["duration"].ToString(),
                    Dob = row["dob"].ToString(),
                    RemoveExtention = row["pic"].ToString().Replace(".jpg", ""),
                    Theory = row["theory"].ToString(),
                    Practical = row["practical"].ToString(),
                    BnAddress= row["bnadress"].ToString()

                });
            }
            return branchpaymenteraning;

        }
        //public List<Course> GetAllCourse()
        //{
        //    List<Course> course = new List<Course>();
        //    List<IDbDataParameter> parameters = new List<IDbDataParameter>();
        //    string query = "GetCourseList";
        //    DataTable tbl = hlpr.GetDataTable(query, ref parameters);


        //    foreach (DataRow row in tbl.Rows)
        //    {
        //        course.Add(new Course()
        //        {

        //            Id = Convert.ToInt32(row["id"]),
        //            Cname = row["name"].ToString(),
        //            Cabb = row["r1"].ToString(),
        //            Cmodules = row["modules"].ToString(),
        //            Cduration = row["duration"].ToString(),
        //            Cfullpay = !row.IsNull("fullpay") ? Convert.ToInt32(row["fullpay"]) : 0,
        //            Cinspay_f = !row.IsNull("inspay_f") ? Convert.ToInt32(row["inspay_f"]) : 0,
        //            Cr3 = !row.IsNull("r3") ? Convert.ToInt32(row["r3"]) : 0,
        //            Cinspay_m = !row.IsNull("inspay_m") ? Convert.ToInt32(row["inspay_m"]) : 0,
        //            Cinspay_xm = !row.IsNull("inspay_xm") ? Convert.ToInt32(row["inspay_xm"]) : 0,
        //            Hqamount = !row.IsNull("hqamount") ? Convert.ToInt32(row["hqamount"]) : 0
        //        });
        //    }
        //    return course;

        //}

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