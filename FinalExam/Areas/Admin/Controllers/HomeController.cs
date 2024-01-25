﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FinalExam.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    [AutoValidateAntiforgeryToken]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
