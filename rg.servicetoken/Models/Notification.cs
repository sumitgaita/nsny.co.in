using System.Collections.Generic;

namespace rg.service.Models
{
    public class Notification
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content_details { get; set; }
        public int Bid { get; set; }
        public int Activation { get; set; }
        public string Bname { get; set; }
    }
 
}