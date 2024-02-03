using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CompanySearchMVC.Models;
using CompanySearchMVC.Models.Dto;
using CompanySearchMVC.Services;
using CompanySearchMVC.Services.IServices;
using Microsoft.AspNetCore.Mvc;

namespace CompanySearchMVC.Controllers
{
    public class EventsController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IEventService _eventService;
        public EventsController(ILogger<HomeController> logger, IEventService eventService)
        {
            _eventService = eventService;
            _logger = logger;
        }

        // GET: ShelfsController
        public async Task<ActionResult> Index()
        {
            var model = await _eventService.GetAllEventsAsync<EventDetailsVm>();
            return View(model);
        }

        // GET: ShelfsController/Details/5
        public async Task<ActionResult> Details(Guid id)
        {
            var model = await _eventService.GetEventByIdAsync<EventDetailsVm>(id);
            return View(model);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateEventDto model)
        {
            if (ModelState.IsValid)
            {
                var entity = await _eventService.CreateEventAsync<ApiResponse>(model);
                return RedirectToAction(nameof(EventsController.Details), nameof(EventsController).CutController(), new { @Id = entity });
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