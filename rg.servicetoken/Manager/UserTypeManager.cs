using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using rg.service.Data;
using rg.service.Models;

namespace rg.service.Manager
{
    public class UserTypeManager : IUserTypeManager
    {
        public UserType UserTypeDetails(UserType userTypes)
        {
            var data = new UserTypeData();

            return data.UserTypeDetails(userTypes);
        }
    }
}