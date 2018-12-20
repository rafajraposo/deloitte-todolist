using System.Threading.Tasks;
using ToDoList.Data;
using ToDoList.Service.Services;

namespace ToDoList.Service
{
    public class UnitOfWork : IUnitOfWork
    {
        private IUserService _userService;
        private IItemService _itemService;

        private readonly IContext _context;

        public UnitOfWork()
        {
            _context = new Context();
        }

        public async Task<bool> SaveChanges() => await _context.SaveChangesAsync() > 0;

        public IUserService Users
        {
            get
            {
                if (_userService == null)
                    _userService = new UserService(_context);

                return _userService;
            }
        }

        public IItemService Items
        {
            get
            {
                if (_itemService == null)
                    _itemService = new ItemService(_context);

                return _itemService;
            }
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
