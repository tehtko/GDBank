using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using GDBank.Models;

namespace GDBank.Controllers;

public class AccountController : Controller
{
    private readonly ILogger<AccountController> _logger;

    public AccountController(ILogger<AccountController> logger)
    {
        _logger = logger;
    }

    public IActionResult Login()
    {
        return View("Account");
    }

    public IActionResult Signup()
    {
        return View("Account");
    }
}