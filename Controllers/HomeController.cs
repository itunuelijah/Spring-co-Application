﻿using Microsoft.AspNetCore.Mvc;
using SpringCoApplication.Models;
using System.Diagnostics;

namespace SpringCoApplication.Controllers
{
    public class HomeController : Controller
    {
       // private readonly ILogger<HomeController> _logger;

       // public HomeController(ILogger<HomeController> logger)
       // {
       //     _logger = logger;
       // }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
        //[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]


    }