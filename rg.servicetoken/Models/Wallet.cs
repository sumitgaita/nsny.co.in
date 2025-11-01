using System;

namespace rg.service.Models
{
    public class Wallet
    {
        public int WalletId { get; set; }
        public int WalletDetailsId { get; set; }
        public int BranchId { get; set; }
        public string Comment { get; set; }
        public decimal Walletamount { get; set; }
        public decimal Extraoffer { get; set; }
        public decimal Totalamount { get; set; }

        public decimal Existingamount { get; set; }
        public decimal Extrachargesfine { get; set; }
        public string Paymentnote { get; set; }
        public DateTime Createddate { get; set; }
        public DateTime Lastupdateddate { get; set; }
        public string Bname { get; set; }
        public string Cname { get; set; }
        public string Stid { get; set; }
    }
}