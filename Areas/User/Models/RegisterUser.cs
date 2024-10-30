using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace BlogApp.Areas.User.Models
{
    public class RegisterUser
    {
        public int Id { get; set; }
        [Required]
        [StringLength(10,ErrorMessage ="Name should be less than 10")]
        public string? Name { get; set; }

        [Required]
        [StringLength(10, ErrorMessage = "Last Name should be less than 10")]
        public string? LName { get; set; }

        [Required]
        [RegularExpression("^[\\w-\\.]+@([\\w-]+\\.)+[\\w-]{2,4}$",ErrorMessage ="Enetr valid email")]
        public string? Email { get; set; }

        [Required]

        public string? Password { get; set; }

        public int IsAdmin { get; set; }

    }
}
