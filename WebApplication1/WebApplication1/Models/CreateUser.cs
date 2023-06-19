namespace WebApplication1.Models
{
    public class CreateUserRequest
    {
        public String name { get; set; }

        public String job { get; set; }
    }

    public class CreateUserResponse
    {
        public String name { get; set; }

        public String job { get; set; }

        public String id { get; set; }

        public String createdAt { get; set; }
    }
}
