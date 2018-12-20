using AutoMapper;
using System.Threading.Tasks;
using System.Web.Mvc;
using ToDoList.Entity;
using ToDoList.Service;
using ToDoList.Web.Models;

namespace ToDoList.Web.Controllers
{
    [Authorize]
    public class ToDoController : BaseController
    {
        private readonly IUnitOfWork _uow;

        public ToDoController(IUnitOfWork uow)
        {
            _uow = uow;
        }

        [Route("")]
        public async Task<ActionResult> Index()
        {
            var items = await _uow.Items.GetAllByUser(CurrentUser.Id);
            var vm = new ToDoIndexViewModel(items);

            return View(vm);
        }

        public ActionResult Create()
        {
            var vm = new ToDoCreateViewModel();

            return View(vm);
        }

        public async Task<ActionResult> Edit(int id)
        {
            var item = await _uow.Items.GetByIdAndUser(id, CurrentUser.Id);
            var vm = Mapper.Map<ToDoEditViewModel>(item);

            return View(vm);
        }

        public async Task<ActionResult> Delete(int id)
        {
            await _uow.Items.Delete(id);
            await _uow.SaveChanges();

            return RedirectToAction("Index", "ToDo");
        }

        public async Task<ActionResult> ToggleDone(int id)
        {
            var item = await _uow.Items.GetByIdAndUser(id, CurrentUser.Id);

            item.Done = !item.Done;

            _uow.Items.Update(item);
            await _uow.SaveChanges();

            return RedirectToAction("Index", "ToDo");
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(ToDoCreateViewModel vm)
        {
            var item = Mapper.Map<Item>(vm);
            var user = await _uow.Users.GetById(CurrentUser.Id);

            user.ToDoList.Add(item);
            _uow.Users.Update(user);
            await _uow.SaveChanges();

            return RedirectToAction("Index", "ToDo");
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(ToDoEditViewModel vm)
        {
            await _uow.Items.Update(vm.Id, vm.Description);
            await _uow.SaveChanges();

            return RedirectToAction("Index", "ToDo");
        }
    }
}
