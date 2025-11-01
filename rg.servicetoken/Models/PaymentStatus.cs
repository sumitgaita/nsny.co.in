using System;

namespace rg.service.Models
{
    public class PaymentStatus
    {
        public int Id { get; set; }
        public string Stid { get; set; }
        public string Bname { get; set; }
        public string Cname { get; set; }
        public int Amount_cr { get; set; }
        public int Amount_re { get; set; }
        public DateTime Paydt { get; set; }
        public string Payment_staus { get; set; }
        public string Payment_mode { get; set; }
        public string payment_date { get; set; }
        public string Payment_remarks { get; set; }
    }
}