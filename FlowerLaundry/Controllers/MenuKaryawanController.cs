﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace FlowerLaundry.Controllers
{
    public class MenuKaryawanController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}