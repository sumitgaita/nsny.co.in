using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace rg.service.Models
{
    public class User
    {
        public int LoginId { get; set; }
        public int LoginType { get; set; }
        public string LoginUserName { get; set; }
        public string LoginPassword { get; set; }
        public string LoginName { get; set; }
        public string LoginContactNumber { get; set; }
        public string LoginEmailId { get; set; }
        public string LoginAddress { get; set; }
        public DateTime LoginCreateDate { get; set; }
        public int LoginActivation { get; set; }
        public string LoginUserType { get; set; }

    }
}