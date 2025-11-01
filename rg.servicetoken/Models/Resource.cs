using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace rg.service.Models
{
    public class Resource
    {
        public int ResourceId { get; set; }
        public int ProjectId { get; set; }
        public string ResourceName { get; set; }
        public string ItemName { get; set; }
        public string Supplier { get; set; }
        public string Unit { get; set; }
        public decimal Qty { get; set; }
        public decimal Rate { get; set; }
        public decimal Cost { get; set; }
        public string Comments { get; set; }
        public int CostCode { get; set; }
        public DateTime CreateDate { get; set; }
        public string DeleteResource { get; set; }
        public string ResourceCostCode { get; set; }
        public bool CheckStaus { get; set; }
        public List<ResourceIds> ResourceIdList { get; set; }
        public List<CostCodeArray> CostCodeList { get; set; }
    }

    public class ResourceIds
    {
        public int ProjectIds { get; set; }
    }
    public class CostCodeArray
    {
        public int CostCodeIds { get; set; }
        public decimal Qty { get; set; }
        public decimal Cost { get; set; }
    }
    public class ResourceNameArray
    {
        public int ProjectId { get; set; }
       public string ResourceName { get; set; }
        public string ItemName { get; set; }
        public string Supplier { get; set; }

    }
}