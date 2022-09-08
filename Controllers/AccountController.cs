using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using GDBank.Models;
using GDBank.Services;

namespace GDBank.Controllers;

public class AccountController : Controller
{
    private readonly ILogger<AccountController> _logger;
    private AccountService accountService = new();
    public AccountController(ILogger<AccountController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Profile()
    {
        return View("Account");
    }

    public IActionResult Login(AccountModel user)
    {
        if (accountService.ValidateLogin(user) is false)
            return RedirectToAction("Index");
        else
            return RedirectToAction("Profile");
    }

    public IActionResult Signup(AccountCreationModel user)
    {
        if (accountService.CreateUser(user) is false)
            return RedirectToAction("Index");
        else
            return RedirectToAction("Profile");
    }
}