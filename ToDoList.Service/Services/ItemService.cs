using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using ToDoList.Data;
using ToDoList.Entity;

namespace ToDoList.Service.Services
{
    public class ItemService : IItemService
    {
        private readonly DbSet<Item> _dbSet;
        private readonly IContext _context;

        public ItemService(IContext context)
        {
            _context = context;
            _dbSet = _context.GetDbSet<Item>();
        }

        /// <summary>
        /// Get all items from an user
        /// </summary>
        /// <param name="userId">User id</param>
        /// <returns>List of items</returns>
        public async Task<IList<Item>> GetAllByUser(int userId)
        {
            return await _dbSet.Where(x => x.User != null && x.User.Id == userId).ToListAsync();
        }

        /// <summary>
        /// Get item by id and user
        /// </summary>
        /// <param name="id">Item id</param>
        /// <param name="userId">User id</param>
        /// <returns>Found item</returns>
        public async Task<Item> GetByIdAndUser(int id, int userId)
        {
            return await _dbSet.FirstOrDefaultAsync(x => x.Id == id && x.User != null && x.User.Id == userId);
        }

        /// <summary>
        /// Get item by id
        /// </summary>
        /// <param name="id">Item id</param>
        /// <returns>Found item</returns>
        public async Task<Item> GetById(int id)
        {
            return await _dbSet.FirstOrDefaultAsync(x => x.Id == id);
        }

        /// <summary>
        /// Insert a new item
        /// </summary>
        /// <param name="userToInsert">Item to insert</param>
        /// <returns>Inserted item</returns>
        public Item Insert(Item itemToInsert)
        {
            itemToInsert.CreatedAt = DateTime.Now;

            return _dbSet.Add(itemToInsert);
        }

        /// <summary>
        /// Update an item
        /// </summary>
        /// <param name="itemToUpdate">Item to update</param>
        public async Task Update(int id, string description)
        {
            var itemToUpdate = await GetById(id);

            itemToUpdate.Description = description;
            itemToUpdate.UpdatedAt = DateTime.Now;

            Update(itemToUpdate);
        }

        /// <summary>
        /// Update an item
        /// </summary>
        /// <param name="itemToUpdate">Item to update</param>
        public void Update(Item itemToUpdate)
        {
            itemToUpdate.UpdatedAt = DateTime.Now;

            _dbSet.Attach(itemToUpdate);
            _context.Entry(itemToUpdate).State = EntityState.Modified;
        }

        /// <summary>
        /// Delete an item by id
        /// </summary>
        /// <param name="id">Item id</param>
        public async Task Delete(int id)
        {
            Item itemToDelete = await GetById(id);
            Delete(itemToDelete);
        }

        /// <summary>
        /// Delete an item
        /// </summary>
        /// <param name="itemToDelete">Item to delete</param>
        public void Delete(Item itemToDelete)
        {
            if (_context.Entry(itemToDelete).State == EntityState.Detached)
                _dbSet.Attach(itemToDelete);

            _dbSet.Remove(itemToDelete);
        }
    }
}
