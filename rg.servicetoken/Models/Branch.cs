namespace rg.service.Models
{
    public class Branch
    {
        public int Id { get; set; }
        public string Bname { get; set; }
        public string Bcontact { get; set; }
        public string Bemail { get; set; }
        public string Bpass { get; set; }
        public int Bcommission { get; set; }

        public string Paymentmode { get; set; }
    }
}