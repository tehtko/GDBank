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

    public IActionResult Login(AccountModel user)
    {
        if (accountService.ValidateLogin(user) is false)
            return View("Index");
        else
            return View("Account");
    }

    public IActionResult Signup(AccountCreationModel user)
    {
        if (accountService.CreateUser(user) is false)
            return View("Index");
        else
            return View("Account");
    }
}