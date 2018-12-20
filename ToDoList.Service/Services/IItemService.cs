using System.Collections.Generic;
using System.Threading.Tasks;
using ToDoList.Entity;

namespace ToDoList.Service.Services
{
    public interface IItemService
    {
        /// <summary>
        /// Get all items from an user
        /// </summary>
        /// <param name="userId">User id</param>
        /// <returns>List of items</returns>
        Task<IList<Item>> GetAllByUser(int userId);

        /// <summary>
        /// Get item by id and user
        /// </summary>
        /// <param name="id">Item id</param>
        /// <param name="userId">User id</param>
        /// <returns>Found item</returns>
        Task<Item> GetByIdAndUser(int id, int userId);

        /// <summary>
        /// Get item by id
        /// </summary>
        /// <param name="id">Item id</param>
        /// <returns>Found item</returns>
        Task<Item> GetById(int id);

        /// <summary>
        /// Insert a new item
        /// </summary>
        /// <param name="userToInsert">Item to insert</param>
        /// <returns>Inserted item</returns>
        Item Insert(Item itemToInsert);

        /// <summary>
        /// Update an item by id
        /// </summary>
        /// <param name="id">Item id</param>
        /// <param name="description">Item description</param>
        Task Update(int id, string description);

        /// <summary>
        /// Update an item
        /// </summary>
        /// <param name="itemToUpdate">Item to update</param>
        void Update(Item itemToUpdate);

        /// <summary>
        /// Delete an item by id
        /// </summary>
        /// <param name="id">Item id</param>
        Task Delete(int id);

        /// <summary>
        /// Delete an item
        /// </summary>
        /// <param name="itemToDelete">Item to delete</param>
        void Delete(Item itemToDelete);
    }
}
