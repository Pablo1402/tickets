using AppSite.ViewModels;
using AutoMapper;
using Business.Entities;
using Business.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace AppSite.Controllers
{
    public class UserTypeController : BaseController
    {
        private readonly IUserTypeService _service;
        private readonly IMapper _mapper;

        public UserTypeController(IUserTypeService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {

            var data = await _service.GetAllAsync();
            return View(_mapper.Map<List<UserTypeViewModel>>(data));
        }

        //public async Task<IActionResult> Details(Guid? id)
        //{
        //    var userType = await _service.GetByIdAsync(id.Value);
        //    if (userType == null)
        //        return NotFound();

        //    return View(_mapper.Map<UserTypeViewModel>(userType));
        //}

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(UserTypeViewModel userTypeViewModel)
        {
            if (!ModelState.IsValid)
                return View(userTypeViewModel);

            var userType = _mapper.Map<UserType>(userTypeViewModel);
            await _service.CreateAsync(userType);
            TempData["success"] = "Tipo de usuario salvo com sucesso";
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(Guid id)
        {
            var userType = await _service.GetByIdAsync(id);
            if (userType == null)
                return NotFound();
            return View(_mapper.Map<UserTypeViewModel>(userType));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, UserTypeViewModel userTypeViewModel)
        {
            if (id != userTypeViewModel.Id)
                return NotFound();

            if (!ModelState.IsValid)
                return View(userTypeViewModel);

            await _service.UpdateAsync(_mapper.Map<UserType>(userTypeViewModel));

            TempData["success"] = "Tipo de usuario alterado com sucesso";
            return RedirectToAction(nameof(Index));


        }

        public async Task<IActionResult> Delete(Guid id)
        {
            var userType = await _service.GetByIdAsync(id);
            if (userType == null)
                return NotFound();

            return View(_mapper.Map<UserTypeViewModel>(userType));
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var userType = await _service.GetByIdAsync(id);
            if (userType == null)
                return NotFound();
            if (userType != null)
                await _service.DeleteAsync(userType);

            TempData["success"] = "Tipo de usuario removido com sucesso";
            return RedirectToAction(nameof(Index));
        }
    }
}
