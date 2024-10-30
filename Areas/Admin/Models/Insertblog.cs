namespace BlogApp.Areas.Admin.Models
{
    public class Insertblog
    {
        public int Id { get; set; }
        public String Blogname {  get; set; }

        public String AuthName { get; set; }

        public String ShortDesc { get; set; }

        public String Image { get; set; }

        public String Descript { get; set; }

        public String Category { get; set; }
    }
}
