using AppSite.Helpers;
using AppSite.ViewModels;
using AutoMapper;
using Business.Entities;
using Business.Interfaces.Repositories;
using Business.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AppSite.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _service;
        private readonly IMapper _mapper;
        private readonly IUserTypeService _userTypeService;

        public UserController(IUserService service
            , IMapper mapper
            , IUserTypeService userTypeService)
        {
            _service = service;
            _mapper = mapper;
            _userTypeService = userTypeService;
        }

        public async Task<ActionResult> Index()
        {
            var storeId = new Guid(User?.Claims.FirstOrDefault(x => x.Type == "StoreId")?.Value);
            var users = await _service.GetAllByStoreAsync(storeId);
            return View(_mapper.Map<IEnumerable<UserViewModel>>(users));
        }


        public async Task<IActionResult> Create()
        {
            ViewData["UserTypeId"] = new SelectList(await _userTypeService.GetAllAsync(), "Id", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(UserViewModel userViewModel)
        {
            if (!ModelState.IsValid)
            {
                ViewData["UserTypeId"] = new SelectList(await _userTypeService.GetAllAsync(), "Id", "Name");
                return View(userViewModel);
            }
            var user = _mapper.Map<User>(userViewModel);
            user.setDateCreate(DateTime.Now);
            user.setStoreId(new Guid(User?.Claims.FirstOrDefault(x => x.Type == "StoreId")?.Value));
            await _service.CreateAsync(user );
            TempData["success"] = "Usuario salvo com sucesso";
            return RedirectToAction(nameof(Index));
        }

        //public async Task<IActionResult> Edit(Guid id)
        //{
        //    var store = await _repository.GetById(id);
        //    if (store == null)
        //        return NotFound();
        //    ViewData["StorePlanId"] = new SelectList(await _storePlanRepository.GetAll(), "Id", "Name");
        //    return View(_mapper.Map<StoreViewModel>(store));
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(Guid id, StoreViewModel storeViewModel)
        //{
        //    if (id != storeViewModel.Id)
        //        return NotFound();

        //    var store = await _repository.GetById(id);
        //    if (store == null)
        //        return NotFound();

        //    if (!ModelState.IsValid)
        //    {
        //        ViewData["StorePlanId"] = new SelectList(await _storePlanRepository.GetAll(), "Id", "Name");
        //        return View(storeViewModel);
        //    }

        //    var storeUpdate = _mapper.Map<Store>(storeViewModel);
        //    storeUpdate.CreateDate = store.CreateDate;
        //    await _repository.Update(storeUpdate);

        //    return RedirectToAction(nameof(Index));

        //}

        //public async Task<IActionResult> Delete(Guid id)
        //{
        //    var store = await _repository.GetById(id);
        //    if (store == null)
        //        return NotFound();

        //    return View(_mapper.Map<StoreViewModel>(store));
        //}

        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(Guid id)
        //{
        //    var store = await _repository.GetById(id);
        //    if (store == null)
        //        return NotFound();
        //    if (store != null)
        //        await _repository.Delete(store);

        //    return RedirectToAction(nameof(Index));
        //}

        //public async Task<IActionResult> Details(Guid? id)
        //{
        //    var store = await _repository.GetById(id.Value);
        //    if (store == null)
        //        return NotFound();

        //    return View(_mapper.Map<StoreViewModel>(store));
        //}
    }
}
