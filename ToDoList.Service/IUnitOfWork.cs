using System;
using System.Threading.Tasks;
using ToDoList.Service.Services;

namespace ToDoList.Service
{
    public interface IUnitOfWork : IDisposable
    {
        #region Methods

        Task<bool> SaveChanges();

        #endregion

        #region Properties

        IUserService Users { get; }

        IItemService Items { get; }

        #endregion
    }
}
