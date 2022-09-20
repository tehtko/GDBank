using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using GDBank.Models;
using Newtonsoft.Json;

namespace GDBank.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult About()
    {
        return View();
    }

    public IActionResult Contact()
    {
        return View();
    }

    public IActionResult Debit()
    {
        return View();
    }

    public IActionResult Credit()
    {
        return View();
    }

    public IActionResult Login()
    {
        try // Check if the user is already signed in
        {
            JsonConvert.DeserializeObject<AccountModel>(
                HttpContext.Session.GetString("UserSession"));

            return RedirectToAction("Account");
        } catch (ArgumentNullException) { return View(); } // Otherwise proceed to login page
    }

    public IActionResult Sign()
    {
        return View();
    }

    public IActionResult Account()
    {
        return View();
    }

    public IActionResult Store()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
