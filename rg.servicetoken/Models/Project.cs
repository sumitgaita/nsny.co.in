using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace rg.service.Models
{
    public class Project
    {

        public int ProjectId { get; set; }
        public string ProjectName { get; set; }
        public string ProjrctCode { get; set; }
        public string ProjectAddress { get; set; }
        public string ProjectDescription { get; set; }
        public string ProjectClient { get; set; }
        public string ProjectClientAddress { get; set; }
        public DateTime ProjectStartDate { get; set; }
        public DateTime ProjectCompletionDate { get; set; }
        public string RainbowProjectManager { get; set; }
        public string RainbowSiteManager { get; set; }
        public string ProjectClientProjectManager { get; set; }
        public string ProjectClientSiteManager { get; set; }
        public int ProjectActivation { get; set; }
        public int LoginId { get; set; }
    }
}