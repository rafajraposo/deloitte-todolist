using System.ComponentModel.DataAnnotations;

namespace ToDoList.Web.Models
{
    public class AuthLoginViewModel
    {
        [Required]
        [Display(Name = "Username")]
        public string Username { get; set; }

        [Required]
        [Display(Name = "Password")]
        public string Password { get; set; }
    }
}