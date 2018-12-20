using System;
using System.ComponentModel.DataAnnotations;

namespace ToDoList.Web.Models
{
    public class ToDoCreateViewModel
    {
        [Required]
        [MaxLength(255)]
        public string Description { get; set; }

        public DateTime CreatedAt { get; set; }

        public ToDoCreateViewModel()
        {
            CreatedAt = DateTime.Now;
        }
    }
}
