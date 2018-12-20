using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Threading.Tasks;

namespace ToDoList.Data
{
    public interface IContext : IDisposable
    {
        /// <summary>
        /// Get DbSet for a specified entity
        /// </summary>
        /// <typeparam name="T">Entity</typeparam>
        /// <returns>Entity DbSet</returns>
        DbSet<T> GetDbSet<T>() where T : class;

        Task<int> SaveChangesAsync();

        DbEntityEntry<T> Entry<T>(T entity) where T : class;
    }
}
