using System.Collections.Generic;
using ToDoList.Entity;

namespace ToDoList.Web.Models
{
    public class ToDoIndexViewModel
    {
        public IList<Item> Items { get; set; }

        public ToDoIndexViewModel()
        {
        }

        public ToDoIndexViewModel(IList<Item> items)
        {
            Items = items;
        }
    }
}
