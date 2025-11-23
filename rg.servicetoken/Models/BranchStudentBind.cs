using System;

namespace rg.service.Models
{
    public class BranchStudentBind
    {
        public int Id { get; set; }
        public int Scbid { get; set; }
        public string Scbname { get; set; }
        public string Scstid { get; set; }
        public int Sccid { get; set; }
        public int Scctotal { get; set; }
        public string Scctype { get; set; }
        public int Sccdiscount { get; set; }
        public DateTime Scsjoin { get; set; }
        public int Scamountremaing { get; set; }
        public int Sclastamountpay { get; set; }
        public DateTime Scdateofpayment { get; set; }
        public int SctotalInstallment { get; set; }
        public int Scremainginstallment { get; set; }
        public string Scpaymentclear { get; set; }
        public string Theory { get; set; }
        public string Practical { get; set; }
        public int CourseCatagory { get; set; }
        
    }
}