namespace BlogApp.Areas.Blog.Models
{
    public class Comment
    {
        public int id { get; set; }
        public int user_id { get; set; }
        public int blog_id { get; set; }
        public String cmt { get; set; }
        public String Name { get; set; }

        public String Blogname { get; set; }

       
    }
}
