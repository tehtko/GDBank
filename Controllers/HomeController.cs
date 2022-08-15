﻿using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using GDBank.Models;

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

    public IActionResult FAQ()
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
        return View();
    }

    public IActionResult Signup()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
