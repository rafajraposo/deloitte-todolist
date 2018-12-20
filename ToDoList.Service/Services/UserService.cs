using System;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using ToDoList.Data;
using ToDoList.Entity;

namespace ToDoList.Service.Services
{
    public class UserService : IUserService
    {
        private readonly DbSet<User> _dbSet;
        private readonly IContext _context;

        public UserService(IContext context)
        {
            _context = context;
            _dbSet = _context.GetDbSet<User>();
        }

        /// <summary>
        /// Get user by id
        /// </summary>
        /// <param name="id">User id</param>
        /// <returns>Found user</returns>
        public async Task<User> GetById(int id)
        {
            return await _dbSet.FirstOrDefaultAsync(x => x.Id == id);
        }

        /// <summary>
        /// Insert a new user
        /// </summary>
        /// <param name="userToInsert">User to insert</param>
        /// <returns>Inserted user</returns>
        public User Insert(User userToInsert)
        {
            userToInsert.CreatedAt = DateTime.Now;

            return _dbSet.Add(userToInsert);
        }

        /// <summary>
        /// Update an user
        /// </summary>
        /// <param name="userToUpdate">User to update</param>
        public void Update(User userToUpdate)
        {
            userToUpdate.UpdatedAt = DateTime.Now;

            _dbSet.Attach(userToUpdate);
            _context.Entry(userToUpdate).State = EntityState.Modified;
        }

        /// <summary>
        /// Delete an user by id
        /// </summary>
        /// <param name="id">User id</param>
        public async Task Delete(int id)
        {
            User userToDelete = await _dbSet.FirstOrDefaultAsync(x => x.Id == id);
            Delete(userToDelete);
        }

        /// <summary>
        /// Delete an user
        /// </summary>
        /// <param name="userToDelete">User to delete</param>
        public void Delete(User userToDelete)
        {
            if (_context.Entry(userToDelete).State == EntityState.Detached)
                _dbSet.Attach(userToDelete);

            _dbSet.Remove(userToDelete);
        }

        /// <summary>
        /// Get an user by username and password
        /// </summary>
        /// <param name="username">Username</param>
        /// <param name="password">Password</param>
        /// <returns>User</returns>
        public async Task<User> GetByUsernameAndPassword(string username, string password)
        {
            return await _dbSet
                .Where(x => x.Username.ToLower() == username.ToLower())
                .Where(x => x.Password == password)
                .SingleOrDefaultAsync();
        }
    }
}
