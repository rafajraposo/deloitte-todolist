namespace ToDoList.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using ToDoList.Entity;

    internal sealed class Configuration : DbMigrationsConfiguration<ToDoList.Data.Context>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ToDoList.Data.Context context)
        {
            var userDbSet = context.GetDbSet<User>();

            var user = userDbSet.FirstOrDefault(x => x.Username == "deloitte");
            if (user == null)
            {
                user = new User
                {
                    Username = "deloitte",
                    Password = "123456",
                    CreatedAt = DateTime.Now
                };
            }

            userDbSet.AddOrUpdate(user);
        }
    }
}
