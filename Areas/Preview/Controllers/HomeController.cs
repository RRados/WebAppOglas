﻿using Microsoft.AspNetCore.Mvc;

namespace WebAppOglas.Areas.Preview.Controllers
{
    [Area("Preview")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}