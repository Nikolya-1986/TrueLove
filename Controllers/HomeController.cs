using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Love.Models;
using Microsoft.AspNetCore.Authorization;
using Love.ViewModels;
using Love.interfaces;

namespace Love.Controllers;

public class HomeController : Controller
{
    private readonly IMainUserInfo _mainUserInfoRepository;
    
    public HomeController(IMainUserInfo mainUserInfoRepository)
    {
        _mainUserInfoRepository = mainUserInfoRepository;
    }

    [Authorize]
    [Route("Home")]
    public IActionResult Index(string? UserEmail = null)
    {
        var currentUser = _mainUserInfoRepository.getMainUserInfo(UserEmail);
        var homeUserInfo = new HomeViewModel
        {
            mainUserInfo = currentUser,
        };
        return View(homeUserInfo);
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
