using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using GDBank.Models;
using GDBank.Services;
using Newtonsoft.Json;
using Serilog;

namespace GDBank.Controllers;

public class AccountController : Controller
{
#pragma warning disable CS8600, CS8602, CS8604,
    private readonly ILogger<AccountController> logger;
    private AccountService accountService = new();
    public AccountController(ILogger<AccountController> _logger)
    {
        logger = _logger;
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
        // If unable to create the account redirect the user to the homepage
        if (accountService.CreateUser(user) is false)
        {
            ViewBag.AccountError = "This email is already taken";
            return View("Sign");
        }
            
        // Log and set session state if signup was successful
        Log.Information("Account {0} created at {1}", user.Email, DateTime.UtcNow);
        HttpContext.Session.SetString("UserSession", JsonConvert.SerializeObject(user));
        return RedirectToAction("Account");
    }

    public IActionResult Login(AccountModel user)
    {
        // If unable to login redirect the user to the homepage
        if (accountService.ValidateLogin(user) is false)
        {
            ViewBag.AccountError = "Username or password is incorrect";
            return View();
        }
            
        // Log and set session state if login was successful
        Log.Information("User {0} logged in at {1}", user.Email, DateTime.UtcNow);
        HttpContext.Session.SetString("UserSession", JsonConvert.SerializeObject(user));
        return RedirectToAction("Account");
    }

    public IActionResult Logout()
    {
        try // Make sure the user is logged in before attempting to clear all sessions
        {
            AccountModel user = JsonConvert.DeserializeObject<AccountModel>(
            HttpContext.Session.GetString("UserSession"));
            Log.Information("User {0} logged out at {1}", user.Email, DateTime.UtcNow);
            HttpContext.Session.Clear();
        }
        catch (ArgumentNullException) { }

        return RedirectToAction("Index");
    }

    [HttpGet]
    public IActionResult Apply()
    {
        try // Check if the user is signed in so they can create a card
        {
            var user = accountService.GetUser(JsonConvert.DeserializeObject<AccountModel>(
            HttpContext.Session.GetString("UserSession")).Email);

            return View("Apply", new CardApplicationModel { FullName = user.FullName, Email = user.Email, AccountId = user.Id });
        }
        catch (ArgumentNullException) { return View("Login"); }
    }

    [HttpPost]
    public IActionResult Apply(CardApplicationModel model)
    {
        return View();
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