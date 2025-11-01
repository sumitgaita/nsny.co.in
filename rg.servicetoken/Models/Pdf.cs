using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace rg.service.Models
{
    public class Pdf
    {
       public string ProjectName { get; set; }
        public string ClientName { get; set; }
        public string Note { get; set; }
        public string Weather { get; set; }
        public List<GetPdfArray> PdfDetDetails{ get; set; }
        public string CreateDate { get; set; }
    }
   public class GetPdfArray
    {
       public CostDetails  costCodeDetails { get; set; }
       public List<ResourceDetails> resourceList{ get; set; }
       
    }
  public class CostDetails
    {
        public int costCodeId{ get; set; }
        public string costCodeActivity{ get; set; }
        public string costCodeName{ get; set; }
       
    }

   public class ResourceDetails
    {
        public DateTime CreateDate { get; set; }
        public int costCode{ get; set; }
        public decimal Qty { get; set; }
        public decimal Cost { get; set; }
        public string itemName{ get; set; }
        public string resourceName{ get; set; }
        public string supplier{ get; set; }
        public string unit{ get; set; }
        public string comments{ get; set; }

       
    }
}