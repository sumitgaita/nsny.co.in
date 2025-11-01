using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace rg.service.Models
{
    public class CostCode
    {
        public int CostCodeId { get; set; }
        public int ProjectId { get; set; }
        public string CostCodeName { get; set; }
        public string CostCodeDescription { get; set; }
        public decimal CostCodeBudget { get; set; }
        public DateTime CostCodeCreateDate { get; set; }
        public int CostCodeActivation { get; set; }
        public string CostCodeActivity { get; set; }

        public int CostCodeCount { get; set; }

    }
}