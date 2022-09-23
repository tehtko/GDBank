using Microsoft.AspNetCore.Mvc;
using GDBank.Models;
using GDBank.Services;
using Newtonsoft.Json;
using Serilog;
using GDBank.Models.Card;

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
    public IActionResult ApplyDebit()
    {
        try // Check if the user is signed in so they can create a card
        {
            var user = accountService.GetUser(JsonConvert.DeserializeObject<AccountModel>(
            HttpContext.Session.GetString("UserSession")).Email);

            return View("ApplyDebit", new CardApplicationModel { FullName = user.FullName, Email = user.Email, AccountId = user.Id, CardType = "Debit" });
        }
        catch (ArgumentNullException) { return View("Login"); }
    }

    [HttpGet]
    public IActionResult ApplyCredit()
    {
        try // Check if the user is signed in so they can create a card
        {
            var user = accountService.GetUser(JsonConvert.DeserializeObject<AccountModel>(
            HttpContext.Session.GetString("UserSession")).Email);

            return View("ApplyCredit", new CardApplicationModel { FullName = user.FullName, Email = user.Email, AccountId = user.Id, CardType = "Credit" });
        }
        catch (ArgumentNullException) { return View("Login"); }
    }

    public IActionResult Apply(CardApplicationModel model)
    {
        switch (model.AccountType)
        {
            case "Cashback": 
                CreateCard(new CashbackModel(model), model.AccountId);
                break;
            case "Travel":
                CreateCard(new TravelModel(model), model.AccountId);
                break;
            case "Student":
                CreateCard(new StudentModel(model), model.AccountId);
                break;
            case "Rewards":
                CreateCard(new RewardsModel(model), model.AccountId);
                break;
            case "Business":
                CreateCard(new BusinessModel(model), model.AccountId);
                break;
        }

        return View("Account");
    }

    public IActionResult CreateCard(ICardModel card, int id)
    {
        if (accountService.CreateCard(card, id) is false)
        {
            ViewBag.Error = "Couldn't process your request at this time";
            return View("Profile");
        }

        Log.Information("{0} card {1} created at {2} for user {3}", card.CardType, card.Id, DateTime.UtcNow, card.AccountId);
        return RedirectToAction("Account");
    }

}