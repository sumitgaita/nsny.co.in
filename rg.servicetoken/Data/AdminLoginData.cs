using rg.framework.Data;
using rg.service.Models;
using System;
using System.Collections.Generic;
using System.Data;

namespace rg.service.Data
{
    public class AdminLoginData
    {
        private Factory myFactory;
        private Helpers hlpr;

        public AdminLoginData()
        {
            myFactory = new Factory();
            hlpr = new Helpers();
        }
        public AdminLogin LoginDetails(AdminLogin login)
        {
            AdminLogin details = new AdminLogin();
            List<IDbDataParameter> parameters = new List<IDbDataParameter>();
            string[] usernameList = login.Bemail.Split('$');
            parameters.Add(myFactory.GetParameter("@mm_Auth_Username", usernameList[1]));
            parameters.Add(myFactory.GetParameter("@mm_Auth_Pass", login.Bpass));
            parameters.Add(myFactory.GetParameter("@login_type", usernameList[0]));
            string query = "AddminBranchPass";
            DataTable tbl = hlpr.GetDataTable(query, ref parameters);

            foreach (DataRow row in tbl.Rows)
            {
                details.Id = Convert.ToInt32(row["id"]);
                details.Bname = row["name"].ToString();
                details.Bcontact = row["contact"].ToString();
                details.Bemail = row["email"].ToString();
                // details.Bcommission = Convert.ToInt32(row["commission"].ToString());
                details.Bpass = row["pass"].ToString();
                details.Paymentmode = row["paymentmode"].ToString();
            }
            return details;

        }
        //public List<User> GetAllUsers()
        //{
        //    List<User> users = new List<User>();
        //    List<IDbDataParameter> parameters = new List<IDbDataParameter>();
        //    string query = "ShowsUserDetails";
        //    DataTable tbl = hlpr.GetDataTable(query, ref parameters);


        //    foreach (DataRow row in tbl.Rows)
        //    {
        //        users.Add(new User()
        //        {


        //            LoginId = Convert.ToInt32(row["login_id"]),
        //            LoginUserType = row["User_Type_name"].ToString(),
        //            LoginUserName = row["login_username"].ToString(),
        //            LoginPassword = row["login_user_password"].ToString(),
        //            LoginName = row["login_name"].ToString(),
        //            LoginContactNumber = row["login_contact_number"].ToString(),
        //            LoginEmailId = row["login_email_id"].ToString(),
        //            LoginAddress = row["login_address"].ToString(),
        //            LoginType = Convert.ToInt32(row["User_Type_id"])


        //        });
        //    }
        //    return users;

        //}

        public bool ChangeBranchPassword(int id, string password)
        {
            List<IDbDataParameter> parameters = new List<IDbDataParameter>
            {
                myFactory.GetParameter("@id", id),
                myFactory.GetParameter("@password", password)
            };
            return hlpr.ExecuteStoredProcedure("ChangeBranchPassword", ref parameters);
        }
        public bool ChangeAdminPassword(int id, string username,string password)
        {
            List<IDbDataParameter> parameters = new List<IDbDataParameter>
            {
                myFactory.GetParameter("@id", id),
                myFactory.GetParameter("@username", username),
                myFactory.GetParameter("@password", password)
            };
            return hlpr.ExecuteStoredProcedure("ChangeAdminPassword", ref parameters);
        }
        //public User UserDetails(User login)
        //{
        //    var details = new User();
        //    List<IDbDataParameter> parameters = new List<IDbDataParameter>();
        //    parameters.Add(myFactory.GetParameter("@login_id", login.LoginId));

        //    string query = "EditUserDetails";
        //    DataTable tbl = hlpr.GetDataTable(query, ref parameters);

        //    foreach (DataRow row in tbl.Rows)
        //    {

        //        details.LoginId = Convert.ToInt32(row["login_id"]);
        //        details.LoginType = Convert.ToInt32(row["login_type"]);
        //        details.LoginUserName = row["login_username"].ToString();
        //        details.LoginPassword = row["login_user_password"].ToString();
        //        details.LoginName = row["login_name"].ToString();
        //        details.LoginContactNumber = row["login_contact_number"].ToString();
        //        details.LoginEmailId = row["login_email_id"].ToString();
        //        details.LoginAddress = row["login_address"].ToString();
        //        details.LoginCreateDate =Convert.ToDateTime(row["login_create_date"]);


        //    }
        //    return details;

        //}

        //public bool CreateUser(User users)
        //{

        //    List <IDbDataParameter> parameters = new List<IDbDataParameter>();
        //    parameters.Add(myFactory.GetParameter("@login_type", users.LoginType));
        //    parameters.Add(myFactory.GetParameter("@login_username", users.LoginUserName));
        //    parameters.Add(myFactory.GetParameter("@login_user_password", users.LoginPassword));
        //    parameters.Add(myFactory.GetParameter("@login_name", users.LoginName));
        //    parameters.Add(myFactory.GetParameter("@login_contact_number", users.LoginContactNumber));
        //    parameters.Add(myFactory.GetParameter("@login_email_id", users.LoginEmailId));
        //    parameters.Add(myFactory.GetParameter("@login_address", users.LoginAddress));
        //    parameters.Add(myFactory.GetParameter("@login_create_date", users.LoginCreateDate));
        //    //return hlpr.ExecuteDmlQuery("Add_New_user", ref parameters); 
        //    return hlpr.ExecuteStoredProcedure("Add_New_user", ref parameters);
        //}
        //public bool UpdateUser(User users)
        //{
        //    List < IDbDataParameter> parameters = new List<IDbDataParameter>();

        //    parameters.Add(myFactory.GetParameter("@login_id", users.LoginId));
        //    parameters.Add(myFactory.GetParameter("@login_type", users.LoginType));
        //    parameters.Add(myFactory.GetParameter("@login_username", users.LoginUserName));
        //    parameters.Add(myFactory.GetParameter("@login_user_password", users.LoginPassword));
        //    parameters.Add(myFactory.GetParameter("@login_name", users.LoginName));
        //    parameters.Add(myFactory.GetParameter("@login_contact_number", users.LoginContactNumber));
        //    parameters.Add(myFactory.GetParameter("@login_email_id", users.LoginEmailId));
        //    parameters.Add(myFactory.GetParameter("@login_address", users.LoginAddress));
        //    parameters.Add(myFactory.GetParameter("@login_create_date", users.LoginCreateDate));
        //    //return hlpr.ExecuteDmlQuery("update_User_Details", ref parameters);
        //    return hlpr.ExecuteStoredProcedure("update_User_Details", ref parameters);
        //}

        //public bool DeleteUser(User users)
        //{
        //    List<IDbDataParameter> parameters = new List<IDbDataParameter>();

        //    parameters.Add(myFactory.GetParameter("@login_id", users.LoginId));
        //    //return hlpr.ExecuteDmlQuery("DeleteUserDetails", ref parameters);
        //   return  hlpr.ExecuteStoredProcedure("DeleteUserDetails", ref parameters);

        //}
    }
}