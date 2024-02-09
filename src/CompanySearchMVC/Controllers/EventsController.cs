using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CompanySearchMVC.Models;
using CompanySearchMVC.Models.Dto;
using CompanySearchMVC.Services;
using CompanySearchMVC.Services.IServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CompanySearchMVC.Controllers
{
    public class EventsController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IMapper _mapper;
        private readonly IEventService _eventService;
        private readonly ICategoryService _categoryService;
        public EventsController(ILogger<HomeController> logger, IEventService eventService, ICategoryService categoryService, IMapper mapper)
        {
            _eventService = eventService;
            _categoryService = categoryService;
            _logger = logger;
            _mapper = mapper;
        }

        // GET: ShelfsController
        public async Task<ActionResult> Index()
        {
            var model = await _eventService.GetAllEventsAsync<EventsVm>();
            return View(model);
        }

        // GET: ShelfsController/Details/5
        public async Task<ActionResult> Details(Guid id)
        {
            var model = await _eventService.GetEventByIdAsync<EventDetailsVm>(id);
            return View(model);
        }

        public async Task<IActionResult> Create()
        {
            var availableCategories = await _categoryService.GetAllCategoriesAsync<CategoriesVm>();
            // ViewBag.AvailableCategories = availableCategories.Categories;
            var model = new CreateEventVm();
            model.AvailableCategories = availableCategories.Categories;
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateEventVm model)
        {
            if (ModelState.IsValid)
            {
                var availableCategories = await _categoryService.GetAllCategoriesAsync<CategoriesVm>();
                model.EventCategories = availableCategories.Categories
                .Where(c => model.SelectedCategories.Contains(c.Id))
                .ToList();

                var entity = _mapper.Map<CreateEventDto>(model);
                var response = await _eventService.CreateEventAsync<CreateEventDto>(entity);
                // return RedirectToAction(nameof(EventsController.Details), nameof(EventsController).CutController(), new { @Id = entity });
                return RedirectToAction(nameof(EventsController.Index), nameof(EventsController).CutController());

                // return View(model);
            }
            return View(model);
        }

        public IActionResult Update()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Update(UpdateEventDto model)
        {
            if (ModelState.IsValid)
            {
                var entity = await _eventService.UpdateEventAsync<UpdateEventDto>(model);
                return RedirectToAction(nameof(EventsController.Details), nameof(EventsController).CutController(), new { model.Id });
            }
            return View(model);
        }

        [HttpPost]
        public IActionResult Delete(Guid id)
        {
            _eventService.DeleteEventAsync<Object>(id);
            return RedirectToAction(nameof(EventsController.Index), nameof(EventsController).CutController());
        }
    }
}