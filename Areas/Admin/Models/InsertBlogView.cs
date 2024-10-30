namespace BlogApp.Areas.Admin.Models
{
    public class InsertBlogView
    {
        public int id { get; set; }

        public String Blogname { get; set; }

        public String AuthName { get; set; }

        public String ShortDesc { get; set; }

        public IFormFile? Image { get; set; }

        public String Descript { get; set; }

        public String Category { get; set; }
    }
}
