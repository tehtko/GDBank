using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using GDBank.Models;
using GDBank.Services;
using Newtonsoft.Json;

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
        
        return View("Login");
    }

    public IActionResult Login(AccountModel user)
    {
        if (accountService.ValidateLogin(user) is false)
            return RedirectToAction("Index");
        
        HttpContext.Session.SetString("UserSession", JsonConvert.SerializeObject(user));
        return RedirectToAction("Account");
    }

    public IActionResult Logout()
    {
        HttpContext.Session.Clear();
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
        return RedirectToAction("Account");
    }

    public IActionResult CreateDebitCard(IDebitModel debit)
    {
        return RedirectToAction("Account");
    }
}