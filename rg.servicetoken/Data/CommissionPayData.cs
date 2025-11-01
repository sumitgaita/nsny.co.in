using rg.framework.Data;
using rg.service.Models;
using System;
using System.Collections.Generic;
using System.Data;

namespace rg.service.Data
{
    public class CommissionPayData
    {
        private Factory myFactory;
        private Helpers hlpr;

        public CommissionPayData()
        {
            myFactory = new Factory();
            hlpr = new Helpers();
        }

        public bool CreateCommissionPay(CommissionPay commissionPay)
        {

            List<IDbDataParameter> parameters = new List<IDbDataParameter>
            {
                myFactory.GetParameter("@bid", commissionPay.Bidpay),
                myFactory.GetParameter("@bname", commissionPay.Bnamepay),
                myFactory.GetParameter("@stid", commissionPay.Stidpay),
                myFactory.GetParameter("@amount_cr", commissionPay.Amount_crpay),
                myFactory.GetParameter("@amount_re", commissionPay.Amount_repay),
                myFactory.GetParameter("@payment_staus", commissionPay.Payment_stauspay),
                myFactory.GetParameter("@cname", commissionPay.Cnamepay),
                myFactory.GetParameter("@payment_mode", commissionPay.Payment_modepay),
                myFactory.GetParameter("@payment_date", commissionPay.Payment_datepay),
                myFactory.GetParameter("@payment_discount", commissionPay.Payment_dis),
                myFactory.GetParameter("@payment_remarks", commissionPay.Payment_re),
                myFactory.GetParameter("@payment_online", commissionPay.Payment_onl)
            };
            return hlpr.ExecuteStoredProcedure("BranchCommissionPay", ref parameters);
        }

        public bool UpdateCourseBindPayment(CommissionPay commissionPay)
        {
            List<IDbDataParameter> parameters = new List<IDbDataParameter>
            {
                myFactory.GetParameter("@id", commissionPay.Id),
                myFactory.GetParameter("@cname", commissionPay.Cnamepay),
                myFactory.GetParameter("@amount_cr", commissionPay.Amount_crpay)
             };
            return hlpr.ExecuteStoredProcedure("UpdateCourseBindPayment", ref parameters);
        }
        //public bool CreatePaymentStatus(PaymentStatus paymentStatus)
        //{

        //    List<IDbDataParameter> parameters = new List<IDbDataParameter>
        //    {
        //        myFactory.GetParameter("@bid", commissionPay.Bidpay),
        //        myFactory.GetParameter("@bname", commissionPay.Bnamepay),
        //        myFactory.GetParameter("@stid", commissionPay.Stidpay),
        //        myFactory.GetParameter("@amount_cr", commissionPay.Amount_crpay),
        //        myFactory.GetParameter("@amount_re", commissionPay.Amount_repay),
        //        myFactory.GetParameter("@payment_staus", commissionPay.Payment_stauspay),
        //        myFactory.GetParameter("@cname", commissionPay.Cnamepay),
        //        myFactory.GetParameter("@payment_mode", commissionPay.Payment_modepay),
        //        myFactory.GetParameter("@payment_date", commissionPay.Payment_datepay),
        //        myFactory.GetParameter("@payment_discount", commissionPay.Payment_dis),
        //        myFactory.GetParameter("@payment_remarks", commissionPay.Payment_re),
        //        myFactory.GetParameter("@payment_online", commissionPay.Payment_onl)
        //    };
        //    return hlpr.ExecuteStoredProcedure("BranchCommissionPay", ref parameters);
        //}
        public int PaymentGeneratedforHQ(int branchId)
        {
            int details = 0;
            List<IDbDataParameter> parameters = new List<IDbDataParameter>
                {
                    myFactory.GetParameter("@Center_code", branchId)
                };
            string query = "BranchPaymetRe";
            DataTable tbl = hlpr.GetDataTable(query, ref parameters);
            foreach (DataRow row in tbl.Rows)
            {
                details = !row.IsNull(0) ? Convert.ToInt32(row[0]) : 0;

            }
            return details;
        }
        public int PaymentCompletedtoHQ(int branchId)
        {
            int details = 0;
            List<IDbDataParameter> parameters = new List<IDbDataParameter>
                {
                    myFactory.GetParameter("@Center_code", branchId)
                };
            string query = "BranchPaymetDone";
            DataTable tbl = hlpr.GetDataTable(query, ref parameters);
            foreach (DataRow row in tbl.Rows)
            {
                details = !row.IsNull(0) ? Convert.ToInt32(row[0]) : 0;

            }

            return details;
        }

        public int PaymentRemaining(int branchId)
        {
            int details = 0;
            List<IDbDataParameter> parameters = new List<IDbDataParameter>
                {
                    myFactory.GetParameter("@Center_code", branchId)
                };
            string query = "BranchPaymetBal";
            DataTable tbl = hlpr.GetDataTable(query, ref parameters);
            foreach (DataRow row in tbl.Rows)
            {
                details = !row.IsNull("balbran") ? Convert.ToInt32(row["balbran"]) : 0;

            }
            return details;
        }

        public int AdminPaymentGeneratedforHQ()
        {
            int details = 0;
            List<IDbDataParameter> parameters = new List<IDbDataParameter>();
            string query = "BranchPaymetReHQ";
            DataTable tbl = hlpr.GetDataTable(query, ref parameters);
            foreach (DataRow row in tbl.Rows)
            {
                details = !row.IsNull(0) ? Convert.ToInt32(row[0]) : 0;

            }
            return details;
        }
        public int AdminPaymentCompletedtoHQ()
        {
            int details = 0;
            List<IDbDataParameter> parameters = new List<IDbDataParameter>();
            string query = "BranchPaymetDoneHQ";
            DataTable tbl = hlpr.GetDataTable(query, ref parameters);
            foreach (DataRow row in tbl.Rows)
            {
                details = !row.IsNull(0) ? Convert.ToInt32(row[0]) : 0;

            }

            return details;
        }

        public int AdminPaymentRemaining()
        {
            int details = 0;
            List<IDbDataParameter> parameters = new List<IDbDataParameter>();
            string query = "BranchPaymetBalHQ";
            DataTable tbl = hlpr.GetDataTable(query, ref parameters);
            foreach (DataRow row in tbl.Rows)
            {
                details = !row.IsNull("bal") ? Convert.ToInt32(row["bal"]) : 0;

            }
            return details;
        }
        public int GetBranchOfficeEarning(int branchId, string fromdate, string todate)
        {
            int details = 0;
            List<IDbDataParameter> parameters = new List<IDbDataParameter>
            {
                myFactory.GetParameter("@bid", branchId),
                myFactory.GetParameter("@fromdate", Convert.ToDateTime(fromdate)),
                myFactory.GetParameter("@todate", Convert.ToDateTime(todate))
            };
            string query = "GetBranchOfficeEarning";
            DataTable tbl = hlpr.GetDataTable(query, ref parameters);
            foreach (DataRow row in tbl.Rows)
            {
                details = !row.IsNull("income") ? Convert.ToInt32(row["income"]) : 0;

            }
            return details;
        }

        public int GetHQOfficeEarning(int branchId, string fromdate, string todate)
        {
            int details = 0;
            List<IDbDataParameter> parameters = new List<IDbDataParameter>
            {
                myFactory.GetParameter("@bid", branchId),
                myFactory.GetParameter("@fromdate", Convert.ToDateTime(fromdate)),
                myFactory.GetParameter("@todate", Convert.ToDateTime(todate))
            };
            string query = "GetHQOfficeEarning";
            DataTable tbl = hlpr.GetDataTable(query, ref parameters);
            foreach (DataRow row in tbl.Rows)
            {
                details = !row.IsNull("income") ? Convert.ToInt32(row["income"]) : 0;

            }
            return details;
        }
        public int GetTotalEarning(int branchId, string fromdate, string todate)
        {
            int details = 0;
            List<IDbDataParameter> parameters = new List<IDbDataParameter>
            {
                myFactory.GetParameter("@bid", branchId),
                myFactory.GetParameter("@fromdate", Convert.ToDateTime(fromdate)),
                myFactory.GetParameter("@todate", Convert.ToDateTime(todate))
            };
            string query = "GetTotalEarning";
            DataTable tbl = hlpr.GetDataTable(query, ref parameters);
            foreach (DataRow row in tbl.Rows)
            {
                details = !row.IsNull("income") ? Convert.ToInt32(row["income"]) : 0;

            }
            return details;
        }
        //public bool UpdateCourse(Course course)
        //{
        //    List<IDbDataParameter> parameters = new List<IDbDataParameter>
        //    {
        //        myFactory.GetParameter("@id", course.Id),
        //        myFactory.GetParameter("@name", course.Cname),
        //        myFactory.GetParameter("@modules", course.Cmodules),
        //        myFactory.GetParameter("@duration", course.Cmodules),
        //        myFactory.GetParameter("@fullpay", course.Cfullpay),
        //        myFactory.GetParameter("@inspay_f", course.Cinspay_f),
        //        myFactory.GetParameter("@inspay_m", course.Cinspay_m),
        //        myFactory.GetParameter("@inspay_xm", course.Cinspay_xm),
        //        myFactory.GetParameter("@r1", course.Cabb),
        //        myFactory.GetParameter("@r2", ""),
        //        myFactory.GetParameter("@r3", course.Cr3),
        //        myFactory.GetParameter("@act", 1),
        //        myFactory.GetParameter("@hqamount", course.Hqamount)

        //     };
        //    return hlpr.ExecuteStoredProcedure("CouseUpdate", ref parameters);

        //}

        //public bool DeleteCourse(Course per)
        //{
        //    List<IDbDataParameter> parameters = new List<IDbDataParameter>
        //    {
        //        myFactory.GetParameter("@id", per.Id)
        //    };
        //    return hlpr.ExecuteStoredProcedure("DeleteCourse", ref parameters);

        //}
        public List<PaymentStatus> GetPaymentGeneratedatBranch(int branchId)
        {
            List<PaymentStatus> paymentStatus = new List<PaymentStatus>();
            List<IDbDataParameter> parameters = new List<IDbDataParameter>
                {
                    myFactory.GetParameter("@bid", branchId)
                };
            string query = "GetPaymentGeneratedatBranch";
            DataTable tbl = hlpr.GetDataTable(query, ref parameters);


            foreach (DataRow row in tbl.Rows)
            {
                paymentStatus.Add(new PaymentStatus()
                {
                    Bname = row["bname"].ToString(),
                    Stid = row["stid"].ToString(),
                    Cname = row["cname"].ToString(),
                    Amount_cr = !row.IsNull("amount_cr") ? Convert.ToInt32(row["amount_cr"]) : 0,
                    Paydt = Convert.ToDateTime(row["paydt"] == DBNull.Value ? null : row["paydt"])
                });
            }
            return paymentStatus;

        }
        public List<PaymentStatus> GetPaymentSendtoHQ(int branchId)
        {
            List<PaymentStatus> paymentStatus = new List<PaymentStatus>();
            List<IDbDataParameter> parameters = new List<IDbDataParameter>
                {
                    myFactory.GetParameter("@bid", branchId)
                };
            string query = "PaymentSendtoHQ";
            DataTable tbl = hlpr.GetDataTable(query, ref parameters);


            foreach (DataRow row in tbl.Rows)
            {
                paymentStatus.Add(new PaymentStatus()
                {
                    Id = !row.IsNull("id") ? Convert.ToInt32(row["id"]) : 0,
                    Bname = row["bname"].ToString(),
                    Amount_re = !row.IsNull("amount_re") ? Convert.ToInt32(row["amount_re"]) : 0,
                    Payment_staus = row["payment_staus"].ToString(),
                    Payment_mode = row["payment_mode"].ToString(),
                    Payment_remarks = row["payment_remarks"].ToString(),
                    payment_date = row["payment_date"].ToString(),
                    Paydt = Convert.ToDateTime(row["paydt"] == DBNull.Value ? null : row["paydt"])
                });
            }
            return paymentStatus;

        }
        public List<PaymentStatus> GetAdminPaymentGeneratedatBranch()
        {
            List<PaymentStatus> paymentStatus = new List<PaymentStatus>();
            List<IDbDataParameter> parameters = new List<IDbDataParameter>();
            string query = "GetAdminPaymentGeneratedatBranch";
            DataTable tbl = hlpr.GetDataTable(query, ref parameters);


            foreach (DataRow row in tbl.Rows)
            {
                paymentStatus.Add(new PaymentStatus()
                {
                    Bname = row["bname"].ToString(),
                    Stid = row["stid"].ToString(),
                    Cname = row["cname"].ToString(),
                    Amount_cr = !row.IsNull("amount_cr") ? Convert.ToInt32(row["amount_cr"]) : 0,
                    Paydt = Convert.ToDateTime(row["paydt"] == DBNull.Value ? null : row["paydt"])
                });
            }
            return paymentStatus;

        }
        public List<PaymentStatus> GetAdminPaymentSendHQ()
        {
            List<PaymentStatus> paymentStatus = new List<PaymentStatus>();
            List<IDbDataParameter> parameters = new List<IDbDataParameter>();
            string query = "AdminPaymentSendtoHQ";
            DataTable tbl = hlpr.GetDataTable(query, ref parameters);


            foreach (DataRow row in tbl.Rows)
            {
                paymentStatus.Add(new PaymentStatus()
                {
                    Id = !row.IsNull("id") ? Convert.ToInt32(row["id"]) : 0,
                    Bname = row["bname"].ToString(),
                    Amount_re = !row.IsNull("amount_re") ? Convert.ToInt32(row["amount_re"]) : 0,
                    Payment_staus = row["payment_staus"].ToString(),
                    Payment_mode = row["payment_mode"].ToString(),
                    Payment_remarks = row["payment_remarks"].ToString(),
                    payment_date = row["payment_date"].ToString(),
                    Paydt = Convert.ToDateTime(row["paydt"] == DBNull.Value ? null : row["paydt"])
                });
            }
            return paymentStatus;

        }
        public bool PaymentUpdate(int paymentId)
        {
            List<IDbDataParameter> parameters = new List<IDbDataParameter>
            {
                myFactory.GetParameter("@id", paymentId)
            };
            return hlpr.ExecuteStoredProcedure("payup", ref parameters);
        }
        public bool PaymentUpdatestatus(int paymentId)
        {
            List<IDbDataParameter> parameters = new List<IDbDataParameter>
            {
                myFactory.GetParameter("@id", paymentId)
            };
            return hlpr.ExecuteStoredProcedure("payupsta", ref parameters);
        }

        public List<BranchPaymentCollection> GetViewEarningDetails(int branchId, string fromdate, string todate)
        {
            List<BranchPaymentCollection> branchcollection = new List<BranchPaymentCollection>();
            List<IDbDataParameter> parameters = new List<IDbDataParameter>
            {
                myFactory.GetParameter("@bid", branchId),
                myFactory.GetParameter("@fromdate", Convert.ToDateTime(fromdate)),
                myFactory.GetParameter("@todate", Convert.ToDateTime(todate))
            };
            string query = "GetViewEarningDetails";
            DataTable tbl = hlpr.GetDataTable(query, ref parameters);
            foreach (DataRow row in tbl.Rows)
            {
                branchcollection.Add(new BranchPaymentCollection()
                {
                    Stid = row["Stid"].ToString(),
                    Bname = row["branch"].ToString(),
                    Ctotal = !row.IsNull("Ctotal") ? Convert.ToInt32(row["Ctotal"]) : 0,
                    Cpaid = !row.IsNull("cpaid") ? Convert.ToInt32(row["cpaid"]) : 0,
                    Cdiscount = !row.IsNull("cdiscount") ? Convert.ToInt32(row["cdiscount"]) : 0,
                    Sjoin = row["stpaydate"].ToString(),
                    Stbalance = !row.IsNull("stbalance") ? Convert.ToInt32(row["stbalance"]) : 0,
                    Stinstall = !row.IsNull("stinstall") ? Convert.ToInt32(row["stinstall"]) : 0,
                    Stinstallremain = !row.IsNull("stinstallremain") ? Convert.ToInt32(row["stinstallremain"]) : 0
                });
            }
            return branchcollection;

        }

        public List<BranchPaymentCollection> GetStudentPaymentDetails(string nssy_code)
        {
            List<BranchPaymentCollection> student = new List<BranchPaymentCollection>();
            List<IDbDataParameter> parameters = new List<IDbDataParameter>
            {
                myFactory.GetParameter("@NSSY_code", nssy_code)
            };
            string query = "GetStudentPaymentDetails";
            DataTable tbl = hlpr.GetDataTable(query, ref parameters);


            foreach (DataRow row in tbl.Rows)
            {
                student.Add(new BranchPaymentCollection()
                {


                    Cname = row["scourse"].ToString(),
                    Ctotal = !row.IsNull("ctotal") ? Convert.ToInt32(row["ctotal"]) : 0,
                    Cpaid = !row.IsNull("cpaid") ? Convert.ToInt32(row["cpaid"]) : 0,
                    Cdiscount = !row.IsNull("cdiscount") ? Convert.ToInt32(row["cdiscount"]) : 0,
                    Sjoin = row["stpaydate"].ToString(),
                    Stbalance = !row.IsNull("stbalance") ? Convert.ToInt32(row["stbalance"]) : 0,
                    Stinstall = !row.IsNull("stinstall") ? Convert.ToInt32(row["stinstall"]) : 0,
                    Stinstallremain = !row.IsNull("stinstallremain") ? Convert.ToInt32(row["stinstallremain"]) : 0

                });
            }
            return student;

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