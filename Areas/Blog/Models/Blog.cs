namespace BlogApp.Areas.Blog.Models
{
    public class Blog
    {
        public int Id { get; set; }
        public string blogname { get; set; }

        public string authname { get; set; }

        public DateTime date { get; set; }

        public string shortdesc { get; set; }

        public string image { get; set; }

        public string descript { get; set; }
    }
}
