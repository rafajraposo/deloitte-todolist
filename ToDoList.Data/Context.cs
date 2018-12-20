using System.Data.Entity;
using ToDoList.Data.Configuration;

namespace ToDoList.Data
{
    public class Context : DbContext, IContext
    {
        /// <summary>
        /// Get DbSet for a specified entity
        /// </summary>
        /// <typeparam name="T">Entity</typeparam>
        /// <returns>Entity DbSet</returns>
        public DbSet<T> GetDbSet<T>() where T : class
        {
            return Set<T>();
        }

        /// <summary>
        /// Entity binding to context
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new UserConfiguration());
            modelBuilder.Configurations.Add(new ItemConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
