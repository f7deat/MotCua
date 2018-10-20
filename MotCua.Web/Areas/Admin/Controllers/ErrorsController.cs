using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MotCua.Web.Areas.Admin.Controllers
{
    public class ErrorsController : Controller
    {
        // GET: Admin/Errors
        public ActionResult Index()
        {
            return View();
        }
        public ViewResult Authorized()
        {
            return View();
        }
    }
}