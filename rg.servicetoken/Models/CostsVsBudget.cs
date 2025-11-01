using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace rg.service.Models
{
    public class CostsVsBudget
    {
        public int ProjectId { get; set; }
        public string CostCodeName { get; set; }
        public decimal CostCodeBudget { get; set; }
        public decimal Cost { get; set; }
        public decimal Difference { get; set; }
        public string CostCodeDescription { get; set; }
        public int CostCodeId { get; set; }
    }
}