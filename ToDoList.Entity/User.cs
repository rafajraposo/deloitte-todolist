using System.Collections.Generic;

namespace ToDoList.Entity
{
    public class User : BaseEntity
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public IList<Item> ToDoList { get; set; }

        public User()
        {
            ToDoList = new List<Item>();
        }
    }
}
