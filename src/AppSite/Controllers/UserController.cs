using AppSite.Helpers;
using AppSite.ViewModels;
using AutoMapper;
using Business.Entities;
using Business.Enumerators;
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

        private List<string> GetUserTypeNames()
        {
            var names = new List<string> 
            {
                UserTypeEnum.USER.ToString(),
                UserTypeEnum.CLIENT.ToString(),
                UserTypeEnum.ADMIN.ToString(),
            };
            if(User.IsInRole(UserTypeEnum.SYSTEM.ToString()))
                names.Add(UserTypeEnum.SYSTEM.ToString());
            return names;

        }

        public async Task<IActionResult> Create()
        {
            ViewData["UserTypeId"] = new SelectList(await _userTypeService.GetDropdownAsync(GetUserTypeNames()), "Id", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(UserViewModel userViewModel)
        {
            if (!ModelState.IsValid)
            {
                ViewData["UserTypeId"] = new SelectList(await _userTypeService.GetDropdownAsync(GetUserTypeNames()), "Id", "Name");
                return View(userViewModel);
            }

            var userLoginExistis = _service.GetByLogin(userViewModel.Login);
            if (userLoginExistis != null)
            {
                ViewData["UserTypeId"] = new SelectList(await _userTypeService.GetDropdownAsync(GetUserTypeNames()), "Id", "Name");
                TempData["warning"] = "Já existe um usuário com este login!";
                return View(userViewModel);
            }

            var user = _mapper.Map<User>(userViewModel);
            user.setDateCreate(DateTime.Now);
            user.setStoreId(new Guid(User?.Claims.FirstOrDefault(x => x.Type == "StoreId")?.Value));
            await _service.CreateAsync(user );
            TempData["success"] = "Usuario salvo com sucesso!";
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(Guid id)
        {
            var user = await _service.GetByIdAsync(id);
            if (user == null)
                return NotFound();
            ViewData["UserTypeId"] = new SelectList(await _userTypeService.GetDropdownAsync(GetUserTypeNames()), "Id", "Name");
            return View(_mapper.Map<UserViewModel>(user));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, UserViewModel userViewModel)
        {
            if (id != userViewModel.Id)
                return NotFound();

            var user = await _service.GetByIdAsync(id);
            if (user == null)
                return NotFound();

            if (!ModelState.IsValid)
            {
                ViewData["UserTypeId"] = new SelectList(await _userTypeService.GetDropdownAsync(GetUserTypeNames()), "Id", "Name");
                return View(userViewModel);
            }

            var userUpdate = _mapper.Map<User>(userViewModel);
            userUpdate.setDateCreate(user.CreateDate);
            userUpdate.setStoreId(new Guid(User?.Claims.FirstOrDefault(x => x.Type == "StoreId")?.Value));
            await _service.UpdateAsync(userUpdate);
            TempData["success"] = "Usuario atualizado com sucesso!";
            return RedirectToAction(nameof(Index));

        }

        public async Task<IActionResult> Delete(Guid id)
        {
            var user = await _service.GetByIdAsync(id);
            if (user == null)
                return NotFound();

            return View(_mapper.Map<UserViewModel>(user));
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var user = await _service.GetByIdAsync(id);
            if (user == null)
                return NotFound();
            if (user != null)
                await _service.DeleteAsync(user);

            TempData["success"] = "Usuario removido com sucesso!";
            return RedirectToAction(nameof(Index));
        }

        //public async Task<IActionResult> Details(Guid? id)
        //{
        //    var store = await _repository.GetById(id.Value);
        //    if (store == null)
        //        return NotFound();

        //    return View(_mapper.Map<StoreViewModel>(store));
        //}
    }
}
