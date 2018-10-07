using MotCua.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using MotCua.Web.Models;

namespace MotCua.Web.Controllers
{
    public class HomeController : Controller
    {
        IUserService _userService;
        public HomeController(IUserService userService)
        {
            _userService = userService;
        }
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(LoginViewModel login)
        {
            if(_userService.Login(login.UserId, login.Password))
            {
                return RedirectToAction("Index", "Dashboards", new { Areas = "Admin" });
            }
            else
            {
                ViewBag.Error = "Đăng nhập không thành công!";
            }
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}