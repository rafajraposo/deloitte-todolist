namespace ToDoList.Entity
{
    public class Item : BaseEntity
    {
        public string Description { get; set; }
        public bool Done { get; set; }
        public User User { get; set; }
    }
}
