using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using rg.framework.Data;
using rg.service.Models;

namespace rg.service.Data
{
    public class UserTypeData
    {
        Factory myFactory;
        Helpers hlpr;

        public UserTypeData()
        {
            myFactory = new Factory();
            hlpr = new Helpers();
        }
        public UserType UserTypeDetails(UserType userTypes)
        {
            var details = new UserType();
            List<IDbDataParameter> parameters = new List<IDbDataParameter>();
            parameters.Add(myFactory.GetParameter("@login_id", userTypes.LoginId));

            string query = "Show_user_Type";
            DataTable tbl = hlpr.GetDataTable(query, ref parameters);

            foreach (DataRow row in tbl.Rows)
            {
                details.UserTypeName = row["User_Type_name"].ToString();
            }
            return details;

        }
    }
}