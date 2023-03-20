using AppSite.ViewModels;
using AutoMapper;
using Business.Entities;
using Business.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AppSite.Controllers
{

    public class StoresController : BaseController
    {
        private readonly ILogger<StoresController> _logger;
        private readonly IStoreRepository _repository;
        private readonly IMapper _mapper;
        private readonly IStorePlanRepository  _storePlanRepository;

        public StoresController(ILogger<StoresController> logger
            , IStoreRepository repository, IMapper mapper, IStorePlanRepository storePlanRepository)
        {
            _logger = logger;
            _repository = repository;
            _mapper = mapper;
            _storePlanRepository = storePlanRepository;
        }

        public async Task<ActionResult> Index() 
        {
            var stores = await _repository.GetAllActives();
            return View(_mapper.Map<IEnumerable<StoreViewModel>>(stores));
        }


        public async Task<IActionResult> Create()
        {
            ViewData["StorePlanId"] = new SelectList( await _storePlanRepository.GetAll(), "Id", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(StoreViewModel storeViewModel)
        {
            if (!ModelState.IsValid)
            {
                ViewData["StorePlanId"] = new SelectList(await _storePlanRepository.GetAll(), "Id", "Name");
                return View(storeViewModel);
            }
            var store = _mapper.Map<Store>(storeViewModel);
            store.CreateDate = DateTime.Now;
            await _repository.Create(store);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(Guid id)
        {
            var store = await _repository.GetById(id);
            if (store == null)
                return NotFound();
            ViewData["StorePlanId"] = new SelectList(await _storePlanRepository.GetAll(), "Id", "Name");
            return View(_mapper.Map<StoreViewModel>(store));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, StoreViewModel storeViewModel)
        {
            if (id != storeViewModel.Id)
                return NotFound();

            var store = await _repository.GetById(id);
            if (store == null)
                return NotFound();

            if (!ModelState.IsValid)
            {
                ViewData["StorePlanId"] = new SelectList(await _storePlanRepository.GetAll(), "Id", "Name");
                return View(storeViewModel);
            }

            var storeUpdate = _mapper.Map<Store>(storeViewModel);
            storeUpdate.CreateDate = store.CreateDate; 
            await _repository.Update(storeUpdate);

            return RedirectToAction(nameof(Index));

        }

        public async Task<IActionResult> Delete(Guid id)
        {
            var store = await _repository.GetById(id);
            if (store == null)
                return NotFound();

            return View(_mapper.Map<StoreViewModel>(store));
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var store = await _repository.GetById(id);
            if (store == null)
                return NotFound();
            if (store != null)
                await _repository.Delete(store);

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Details(Guid? id)
        {
            var store = await _repository.GetById(id.Value);
            if (store == null)
                return NotFound();

            return View(_mapper.Map<StoreViewModel>(store));
        }


    }
}
