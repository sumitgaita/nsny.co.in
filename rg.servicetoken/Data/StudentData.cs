using rg.framework.Data;
using rg.service.Models;
using System;
using System.Collections.Generic;
using System.Data;

namespace rg.service.Data
{
    public class StudentData
    {
        private Factory myFactory;
        private Helpers hlpr;

        public StudentData()
        {
            myFactory = new Factory();
            hlpr = new Helpers();
        }

        public int CreateStudent(Student student)
        {

            List<IDbDataParameter> parameters = new List<IDbDataParameter>
            {
                myFactory.GetParameter("@name", student.Stu_name),
                myFactory.GetParameter("@p_address", student.Paddress),
                myFactory.GetParameter("@pic", student.Fileup_ins),
                myFactory.GetParameter("@nationality", student.Nationality),
                myFactory.GetParameter("@per_address", student.Peraddress),
                myFactory.GetParameter("@mobile", student.Mobile),
                myFactory.GetParameter("@guardian", student.Guardian),
                myFactory.GetParameter("@emaiid", student.Emaiid),
                myFactory.GetParameter("@casts", student.Casts),
                myFactory.GetParameter("@exam", student.Exam),
                myFactory.GetParameter("@duration", ""),
                myFactory.GetParameter("@dob", student.Dob),
                myFactory.GetParameter("@sex", student.Sex),
                myFactory.GetParameter("@religion", student.Religion),
                myFactory.GetParameter("@university", student.University),
                myFactory.GetParameter("@percentage", student.Percentage),
                myFactory.GetParameter("@Center_name", student.Center_name),
                myFactory.GetParameter("@regno", ""),
                myFactory.GetParameter("@class_per", ""),
                myFactory.GetParameter("@NSSY_code", student.NSSY_code),
                myFactory.GetParameter("@Center_code", student.Center_code),
                myFactory.GetParameter("@r4", student.R4),
                myFactory.GetParameter("@r1", ""),
                myFactory.GetParameter("@r2", ""),
                myFactory.GetParameter("@r3", "Couse Ongoing"),
                myFactory.GetParameter("@r5", ""),
                myFactory.GetParameter("@act", 1),
                myFactory.GetParameter("@passingoutyear", student.Passingoutyear)
        };
            return hlpr.ReturnStoredProcedure("Admission_StudentInsert", ref parameters);
        }

        public bool UpdateStudent(Student student)
        {
            try
            {
                List<IDbDataParameter> parameters = new List<IDbDataParameter>
            {
                myFactory.GetParameter("@id", student.Id),
                myFactory.GetParameter("@name", student.Stu_name),
                myFactory.GetParameter("@p_address", student.Paddress),
                myFactory.GetParameter("@pic", student.Fileup_ins),
                myFactory.GetParameter("@nationality", student.Nationality),
                myFactory.GetParameter("@per_address", student.Peraddress),
                myFactory.GetParameter("@mobile", student.Mobile),
                myFactory.GetParameter("@guardian", student.Guardian),
                myFactory.GetParameter("@emaiid", student.Emaiid),
                myFactory.GetParameter("@casts", student.Casts),
                myFactory.GetParameter("@exam", student.Exam),
                myFactory.GetParameter("@duration", ""),
                myFactory.GetParameter("@dob", student.Dob),
                myFactory.GetParameter("@sex", student.Sex),
                myFactory.GetParameter("@religion", student.Religion),
                myFactory.GetParameter("@university", student.University),
                myFactory.GetParameter("@percentage", student.Percentage),
                myFactory.GetParameter("@Center_name", student.Center_name),
                myFactory.GetParameter("@regno", ""),
                myFactory.GetParameter("@class_per", ""),
                myFactory.GetParameter("@NSSY_code", student.NSSY_code),
                myFactory.GetParameter("@Center_code", student.Center_code),
                myFactory.GetParameter("@r4", Convert.ToInt32(student.R4)),
                myFactory.GetParameter("@r1", student.R1),
                myFactory.GetParameter("@r2", student.R2),
                myFactory.GetParameter("@r3", student.R3),
                myFactory.GetParameter("@r5", Convert.ToInt32(0)),
                myFactory.GetParameter("@act", Convert.ToInt32(1))

             };
                return hlpr.ExecuteStoredProcedure("Admission_StudentUpdate", ref parameters);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public bool DeleteStudent(Student per)
        {
            List<IDbDataParameter> parameters = new List<IDbDataParameter>
            {
                myFactory.GetParameter("@id", per.Id)
            };
            return hlpr.ExecuteStoredProcedure("DeleteAdmission_Student", ref parameters);

        }
        public bool UpdateStudentImageName(Student student)
        {
            List<IDbDataParameter> parameters = new List<IDbDataParameter>
            {
                myFactory.GetParameter("@NSSY_code", student.NSSY_code),
                myFactory.GetParameter("@pic", student.Fileup_ins)
            };
            return hlpr.ExecuteStoredProcedure("Admission_StudentImageUpdate", ref parameters);

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

        public List<Student> GetStudent(string nssy_code)
        {
            List<Student> student = new List<Student>();
            List<IDbDataParameter> parameters = new List<IDbDataParameter>
            {
                myFactory.GetParameter("@NSSY_code", nssy_code)
            };
            string query = "GetAdmission_StudentList";
            DataTable tbl = hlpr.GetDataTable(query, ref parameters);


            foreach (DataRow row in tbl.Rows)
            {
                student.Add(new Student()
                {

                    Id = Convert.ToInt32(row["id"]),
                    Stu_name = row["name"].ToString(),
                    Paddress = row["p_address"].ToString(),
                    Peraddress = row["per_address"].ToString(),
                    Emaiid = row["emaiid"].ToString(),
                    Mobile = row["mobile"].ToString(),
                    Dob = row["dob"].ToString(),
                    Sex = row["sex"].ToString(),
                    Nationality = row["nationality"].ToString(),
                    Guardian = row["guardian"].ToString(),
                    Religion = row["religion"].ToString(),
                    Casts = row["casts"].ToString(),
                    Exam = row["exam"].ToString(),
                    Duration = row["duration"].ToString(),
                    University = row["university"].ToString(),
                    Regno = row["regno"].ToString(),
                    Percentage = row["percentage"].ToString(),
                    Class_per = row["class_per"].ToString(),
                    Fileup_ins = row["pic"].ToString(), //HttpContext.Current.Server.MapPath("~/Files/" + row["pic"].ToString()),
                    NSSY_code = row["NSSY_code"].ToString(),
                    Center_code = row["Center_code"].ToString(),
                    Center_name = row["Center_name"].ToString(),
                    Act = !row.IsNull("act") ? Convert.ToInt32(row["act"]) : 0,
                    R1 = row["r1"].ToString(),
                    R2 = row["r2"].ToString(),
                    R3 = row["r3"].ToString(),
                    R4 = !row.IsNull("r4") ? Convert.ToInt32(row["r4"]) : 0,
                    R5 = !row.IsNull("r5") ? Convert.ToInt32(row["r5"]) : 0

                });
            }
            return student;

        }

        public List<Student> GetStudentVerification(string name, string nssy_code)
        {
            List<Student> student = new List<Student>();
            List<IDbDataParameter> parameters = new List<IDbDataParameter>
            {
                myFactory.GetParameter("@name", name),
                //myFactory.GetParameter("@dob", dob),
                myFactory.GetParameter("@NSSY_code", nssy_code)
            };
            string query = "Select_StudentID";
            DataTable tbl = hlpr.GetDataTable(query, ref parameters);


            foreach (DataRow row in tbl.Rows)
            {
                student.Add(new Student()
                {

                    Stu_name = row["name"].ToString(),
                    R3 = row["r3"].ToString(),
                    R1 = row["r1"].ToString(),
                    R2 = row["r2"].ToString(),
                    Dob = row["dob"].ToString(),
                    NSSY_code = row["NSSY_code"].ToString(),
                    Paddress = row["p_address"].ToString(),
                    Center_name = row["Center_name"].ToString(),
                    Guardian = row["guardian"].ToString(),
                    Cname = row["cname"].ToString(),
                    Duration = row["cdu"].ToString(),
                    Pic = row["pic"].ToString(),
                    Theory= row["theory"].ToString(),
                    Practical = row["practical"].ToString()
                });
            }
            return student;

        }
        public List<Student> GetByCenterCodeStudent(string center_code)
        {
            List<Student> student = new List<Student>();
            List<IDbDataParameter> parameters = new List<IDbDataParameter>
            {
                myFactory.GetParameter("@Center_code", center_code)
            };
            string query = "GetStudentByCentercode";
            DataTable tbl = hlpr.GetDataTable(query, ref parameters);


            foreach (DataRow row in tbl.Rows)
            {
                student.Add(new Student()
                {
                    NSSY_code = row["NSSY_code"].ToString(),
                    Stu_name = row["name"].ToString(),
                    Center_code = row["Center_code"].ToString(),
                    Act = !row.IsNull("act") ? Convert.ToInt32(row["act"]) : 0

                });
            }
            return student;

        }

        public List<Student> GetAdminVerifyStudent()
        {
            List<Student> student = new List<Student>();
            List<IDbDataParameter> parameters = new List<IDbDataParameter>();
            string query = "GetAdminVerifyStudent";
            DataTable tbl = hlpr.GetDataTable(query, ref parameters);


            foreach (DataRow row in tbl.Rows)
            {
                student.Add(new Student()
                {
                    Id = !row.IsNull("id") ? Convert.ToInt32(row["id"]) : 0,
                    NSSY_code = row["NSSY_code"].ToString()

                });
            }
            return student;

        }

        public List<BranchPaymentCollection> GetStudentIDJdate(string nssy_code)
        {
            List<BranchPaymentCollection> student = new List<BranchPaymentCollection>();
            List<IDbDataParameter> parameters = new List<IDbDataParameter>
            {
                myFactory.GetParameter("@NSSY_code", nssy_code)
            };
            string query = "StudentID_Jdate";
            DataTable tbl = hlpr.GetDataTable(query, ref parameters);


            foreach (DataRow row in tbl.Rows)
            {
                student.Add(new BranchPaymentCollection()
                {
                    Sname = row["nam"].ToString(),
                    Address = row["address"].ToString(),
                    Guardian = row["gar"].ToString(),
                    Holo = row["holo"].ToString(),
                    Marks = row["marks"].ToString(),
                    Cname = row["course"].ToString(),
                    Duration = row["dura"].ToString(),
                    Sjoin = row["sjoin"].ToString()

                });
            }
            return student;

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

        public int BranchStudentRegisCount(Student student)
        {
            int details = 0;
            List<IDbDataParameter> parameters = new List<IDbDataParameter>
            {
                myFactory.GetParameter("@Center_code", student.Center_code),
                myFactory.GetParameter("@likestr", student.NSSY_code)
            };
            string query = "BranchstudentCount";
            DataTable tbl = hlpr.GetDataTable(query, ref parameters);
            foreach (DataRow row in tbl.Rows)
            {
                details = Convert.ToInt32(row[0]);

            }
            return details;

        }
        //public bool HideProject(Project projects)
        //{
        //    List<IDbDataParameter> parameters = new List<IDbDataParameter>();
        //    parameters.Add(myFactory.GetParameter("@Project_ID", projects.ProjectId));
        //    return hlpr.ExecuteStoredProcedure("ShowHideProject", ref parameters);

        //}

        public int CurrntStudentId()
        {
            int student = 0;
            List<IDbDataParameter> parameters = new List<IDbDataParameter>();
            string query = "GetStudent_currentId";
            DataTable tbl = hlpr.GetDataTable(query, ref parameters);
            foreach (DataRow row in tbl.Rows)
            {
                student = Convert.ToInt32(row["currntId"]);

            }
            return student;
        }

        public List<BranchViewStudent> GetBranchViewStudent(int branchId)
        {
            List<BranchViewStudent> branch = new List<BranchViewStudent>();
            List<IDbDataParameter> parameters = new List<IDbDataParameter>
            {
                myFactory.GetParameter("@bid", branchId)
            };
            string query = "Select_Studetails";
            DataTable tbl = hlpr.GetDataTable(query, ref parameters);


            foreach (DataRow row in tbl.Rows)
            {
                branch.Add(new BranchViewStudent()
                {

                    Id = Convert.ToInt32(row["id"]),
                    Bid = row["bid"].ToString(),
                    Bname = row["bname"].ToString(),
                    Stid = row["stid"].ToString(),
                    Sjoin = row["sjoin"].ToString(),
                    Sname = row["sname"].ToString(),
                    Cname = row["cname"].ToString(),
                    Stuaddress = row["stuaddress"].ToString(),
                    Stumobile = row["stumobile"].ToString(),
                    Studob = row["studob"].ToString(),
                    Stusex = row["stusex"].ToString(),
                    Stupic = row["stupic"].ToString(),
                    Guardian = row["guardian"].ToString(),
                    Passingoutyear = row["passingoutyear"].ToString()
                });
            }
            return branch;

        }

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