namespace rg.service.Models
{
    public class CommissionPay
    {
        public int Id { get; set; }
        public int Bidpay { get; set; }
        public string Bnamepay { get; set; }
        public string Stidpay { get; set; }
        public int Amount_crpay { get; set; }
        public int Amount_repay { get; set; }
        public int Payment_stauspay { get; set; }
        public string Cnamepay { get; set; }
        public string Payment_modepay { get; set; }
        public string Payment_datepay { get; set; }
        public int Payment_dis { get; set; }
        public string Payment_re { get; set; }
        public string Payment_onl { get; set; }
    }
}