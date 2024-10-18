namespace MyApi.Data
{
    public class BlogUser
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string DisplayName { get; set; }
        public DateTime CreatedAt { get; set; }
        public List<BlogPost> BlogPosts { get; set; }

    }

    public class BlogPost
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public int BlogUserId { get; set; }
        public BlogUser BlogUser { get; set; }
    }
}