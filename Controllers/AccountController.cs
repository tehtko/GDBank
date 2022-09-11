using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using GDBank.Models;
using GDBank.Services;
using Newtonsoft.Json;
using Serilog;

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

    public IActionResult Account()
    {
        return View();
    }

    public IActionResult Signup(AccountCreationModel user)
    {
        if (accountService.CreateUser(user) is false)
            return RedirectToAction("Index");

        Log.Information("Account {0} created at {1}", user.Email, DateTime.UtcNow);
        HttpContext.Session.SetString("UserSession", JsonConvert.SerializeObject(user));
        return RedirectToAction("Account");
    }

    public IActionResult Login(AccountModel user)
    {
        if (accountService.ValidateLogin(user) is false)
            return RedirectToAction("Index");

        Log.Information("User {0} logged in at {1}", user.Email, DateTime.UtcNow);
        HttpContext.Session.SetString("UserSession", JsonConvert.SerializeObject(user));
        return RedirectToAction("Account");
    }

    public IActionResult Logout()
    {
        try
        {
            AccountModel user = JsonConvert.DeserializeObject<AccountModel>(
            HttpContext.Session.GetString("UserSession"));
            Log.Information("User {0} logged out at {1}", user.Email, DateTime.UtcNow);
            HttpContext.Session.Clear();
        }
        catch (ArgumentNullException) { }

        return RedirectToAction("Index");
    }

    public IActionResult Apply()
    {
        try // Check if the user is signed in so they can create a card
        {
            JsonConvert.DeserializeObject<AccountModel>(
            HttpContext.Session.GetString("UserSession"));

            return View();
        }
        catch (ArgumentNullException) { return View("Login"); }
    }

    public IActionResult CreateCreditCard(ICreditModel credit)
    {
        Log.Information("Credit card {0} created at {1} for user {2}", credit.Id, DateTime.UtcNow, credit.AccountId);
        return RedirectToAction("Account");
    }

    public IActionResult CreateDebitCard(IDebitModel debit)
    {
        Log.Information("Debit card {0} created at {1} for user {2}", debit.Id, DateTime.UtcNow, debit.AccountId);
        return RedirectToAction("Account");
    }
}