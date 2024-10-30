using System.ComponentModel.DataAnnotations;

namespace BlogApp.Areas.User.Models
{
    public class Login
    {
     
        public int id { get; set; }


        public String name { get; set; }

        [Required]       
        public String Email { get; set; }

        [Required]
        public String Password { get; set; }

      
        public int isAdmin { get; set; }
    }
}
