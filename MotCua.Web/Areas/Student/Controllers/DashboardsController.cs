﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MotCua.Web.Areas.Student.Controllers
{
    public class DashboardsController : Controller
    {
        // GET: Student/Dashboards
        public ActionResult Index()
        {
            return View();
        }
    }
}