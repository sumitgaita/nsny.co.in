namespace rg.service.Models
{
    public class UserPermission
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Pass { get; set; }
        public string Name { get; set; }
        public bool Addcatagory { get; set; }
        public bool Editcatagory { get; set; }
        public bool Addcourse { get; set; }
        public bool Editcourse { get; set; }
        public bool Addbranch { get; set; }
        public bool Editbranch { get; set; }
        public bool Editstudent { get; set; }
        public bool Editbranchstudentbind { get; set; }
        public bool Noticetobranch { get; set; }
        public bool Allnoticetobranch { get; set; }
        public bool Studentregistration { get; set; }
        public bool Studenticard { get; set; }
        public bool Active { get; set; }
    }
}