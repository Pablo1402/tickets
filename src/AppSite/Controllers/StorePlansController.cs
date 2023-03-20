
using AppSite.ViewModels;
using AutoMapper;
using Business.Entities;
using Business.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace AppSite.Controllers
{
    public class StorePlansController : Controller
    {
        private readonly IStorePlanRepository _repo;
        private readonly IMapper _mapper;

        public StorePlansController(IStorePlanRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {

            var data = await _repo.GetAll();
            return View(_mapper.Map<List<StorePlanViewModel>>(data));
        }

        public async Task<IActionResult> Details(Guid? id)
        {
            var storePlan = await _repo.GetByIdAsync(id.Value);
            if (storePlan == null)
                return NotFound();

            return View(_mapper.Map<StorePlanViewModel>(storePlan));
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(StorePlanViewModel storePlanViewModel)
        {
            if (!ModelState.IsValid)
                return View(storePlanViewModel);

            var storeplan = _mapper.Map<StorePlan>(storePlanViewModel);
            await _repo.Create(storeplan);
        
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(Guid id)
        {
            var storePlan = await _repo.GetByIdAsync(id);
            if (storePlan == null)
                return NotFound();
            return View(_mapper.Map<StorePlanViewModel>(storePlan));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, StorePlanViewModel storePlanViewModel)
        {
            if (id != storePlanViewModel.Id)
                return NotFound();

            if (!ModelState.IsValid)
                return View(storePlanViewModel);

            await _repo.Update(_mapper.Map<StorePlan>(storePlanViewModel));
            
            return RedirectToAction(nameof(Index));

            
        }

        public async Task<IActionResult> Delete(Guid id)
        {
            var storePlan = await _repo.GetByIdAsync(id);
            if (storePlan == null)
                return NotFound();

            return View(_mapper.Map<StorePlanViewModel>(storePlan));
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var storePlan = await _repo.GetByIdAsync(id);
            if (storePlan == null)
                return NotFound();
            if (storePlan != null)
                await _repo.Delete(storePlan);

            return RedirectToAction(nameof(Index));
        }

    }
}
