using System.ComponentModel.DataAnnotations;

namespace ToDoList.Web.Models
{
    public class ToDoEditViewModel
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(255)]
        public string Description { get; set; }
    }
}
