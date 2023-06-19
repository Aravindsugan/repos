namespace WebApplication1.Models
{
    public class UserDetails
    {
        public User_Data data { get; set; }
        public User_Support support { get; set; }
    }

    public class User_Data
    {
        public int id { get; set; }
        public String email { get; set; }
        public String first_name { get; set; }
        public String last_name { get; set; }
        public String avatar { get; set; }
    }

    public class User_Support
    {
        public String url { get; set; }
        public String text { get; set; }
    }
}
