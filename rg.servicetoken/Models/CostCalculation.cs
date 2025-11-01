using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace rg.service.Models
{
    public class CostCalculation
    {
      
        public int ProjectId { get; set; }
        public string ProjectName { get; set; }
        public int CostCodeIid { get; set; }
        public string CostCode { get; set; }
        public DateTime  SearchDate { get; set; }

        public DateTime SearchStartDate { get; set; }
        public DateTime CreateDate { get; set; }
        public decimal TotalCost { get; set; }
    }
}