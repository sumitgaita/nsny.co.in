namespace rg.service.Models
{
    public class AdminLogin :Branch
    {
        //public int Id { get; set; }
        //public string Username { get; set; }
        //public string Pass { get; set; }
        public string LoginType { get; set; }
        public UserPermission AdminPermission { get; set; }
        public AdminLogin()
        {
            AdminPermission = new UserPermission();
        }
    }

}