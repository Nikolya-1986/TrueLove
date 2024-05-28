using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Love.Models;
using Microsoft.AspNetCore.Authorization;

namespace Love.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    [Authorize]
    [Route("Home")]
    public IActionResult Index()
    {
        return View();
    }

    [Authorize]
    [Route("Home/Privacy")]
    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
