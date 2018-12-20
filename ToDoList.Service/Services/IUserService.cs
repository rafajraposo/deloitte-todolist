using System.Threading.Tasks;
using ToDoList.Entity;

namespace ToDoList.Service.Services
{
    public interface IUserService
    {
        /// <summary>
        /// Get user by id
        /// </summary>
        /// <param name="id">User id</param>
        /// <returns>Found user</returns>
        Task<User> GetById(int id);

        /// <summary>
        /// Insert a new user
        /// </summary>
        /// <param name="userToInsert">User to insert</param>
        /// <returns>Inserted user</returns>
        User Insert(User userToInsert);

        /// <summary>
        /// Update an user
        /// </summary>
        /// <param name="userToUpdate">User to update</param>
        void Update(User userToUpdate);

        /// <summary>
        /// Delete an user by id
        /// </summary>
        /// <param name="id">User id</param>
        Task Delete(int id);

        /// <summary>
        /// Delete an user
        /// </summary>
        /// <param name="userToDelete">User to delete</param>
        void Delete(User userToDelete);

        /// <summary>
        /// Get an user by username and password
        /// </summary>
        /// <param name="username">Username</param>
        /// <param name="password">Password</param>
        /// <returns>User</returns>
        Task<User> GetByUsernameAndPassword(string username, string password);
    }
}
