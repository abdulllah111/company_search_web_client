using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using CompanySearchMVC.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using CompanySearchMVC.Services;
using CompanySearchMVC.Services.IServices;
using CompanySearchMVC.Models.Dto;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http.HttpResults;

namespace CompanySearchMVC.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IEventService _eventService;
    public HomeController(ILogger<HomeController> logger, IEventService eventService)
    {
        _eventService = eventService;
        _logger = logger;
    }

    // [Authorize]
    public async Task<IActionResult> IndexAsync()
    {
        using (var client = new HttpClient())
        {
            // var events = await _eventService.GetAllEventsAsync<EventDetailsVm>();

            return View();
        }
    }

    public IActionResult Login(string returnUrl = "/")
    {
        // await HttpContext.SignInAsync
        return Challenge(new AuthenticationProperties
        {
            RedirectUri = returnUrl
        }, OpenIdConnectDefaults.AuthenticationScheme);
    }

    public async Task<IActionResult> Logout(string returnUrl = "/")
    {
        return SignOut(new AuthenticationProperties
        {
            RedirectUri = returnUrl
        },  CookieAuthenticationDefaults.AuthenticationScheme, OpenIdConnectDefaults.AuthenticationScheme);

    }
}
