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

    public IActionResult Login(AccountModel user)
    {
        return View("Account");
    }

    public IActionResult Signup(AccountCreationModel user)
    {
        if (false == false)
            return View("Index");                
        else
            return View("Account");
    }
}