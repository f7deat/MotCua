using MotCua.Helper.Common;
using MotCua.Helper.Session;
using MotCua.Model;
using MotCua.Service;
using System.Linq;
using System.Web.Mvc;
using MotCua.Helper;
using System;
using System.Net;

namespace MotCua.Web.Controllers
{
    public class HomeController : Controller
    {
        private IUserService _userService;
        private readonly IFacultyService _facultyService;
        public HomeController(IUserService userService, IFacultyService facultyService)
        {
            _userService = userService;
            _facultyService = facultyService;
        }
        public ActionResult Index()
        {
            ViewBag.ListFaculties = _facultyService.GetAll().ToList();
            ViewBag.ID = _userService.GetAll().OrderByDescending(x => x.UserId).Select(x => x.UserId).FirstOrDefault();
            return View();
        }

        [HttpPost]
        public ActionResult Index(User login)
        {
            ViewBag.ID = _userService.GetAll().OrderByDescending(x => x.UserId).Select(x => x.UserId).FirstOrDefault();
            int state = _userService.Login(login.UserId, login.Password);
            if (state == 1)
            {
                var user = _userService.GetById(login.UserId);
                var userSession = new UserSessionModel
                {
                    UserId = user.UserId,
                    Group = user.GroupId,
                    FullName = user.FullName,
                    Image = user.Image
                };

                Session.Add(Constants.USER_SESSION, userSession);

                return RedirectToAction("Index", "Dashboard", new { area = "Admin" });
            }
            else if (state == 2)
            {
                var user = _userService.GetById(login.UserId);
                var userSession = new UserSessionModel
                {
                    UserId = user.UserId,
                    Group = user.GroupId,
                    FullName = user.FullName,
                    Image = user.Image
                };

                Session.Add(Constants.USER_SESSION, userSession);
                return RedirectToAction("Index", "Dashboards", new { area = "Student" });
            }
            else
            if (state == -2)
            {
                TempData["Status"] = "Tài khoản của bạn đang chờ để kích hoạt!";
            }
            else
            {
                TempData["Status"] = "Đăng nhập không thành công!";
            }
            ViewBag.ListFaculties = _facultyService.GetAll().ToList();
            return View();
        }

        [HttpPost]
        public ActionResult Register(User user)
        {
            //Mã kích hoạt
            var rand = new Random();
            var code = rand.Next(10000, 99999);

            Session["Active"] = code;

            var subject = "Thông tin tài khoản Hệ thống Một Cửa";
            user.Token = code;
            _userService.Add(user);
            string domainName = System.Web.HttpContext.Current.Request.Url.GetLeftPart(UriPartial.Authority);
            var message = $"ID: {user.UserId}. Mật khẩu: {user.Password}. Mã kích hoạt: {code} <br/> Hoặc nhấn vào <a href=\"{domainName}/Home/Active/{user.UserId}?token={code}\">ĐÂY</a> để kích hoạt tài khoản!";
            var send = SendEmail.Send(user.Email, subject, message);
            if (send > 0)
            {
                TempData["Status"] = "Đăng ký thành công, Vui lòng kiểm tra hòm thư và xác thực tài khoản!";
            }
            else
            {
                TempData["Status"] = "Đăng ký thất bại!";
            }
            return Redirect("/");
        }

        public ActionResult Active(int? id, int? token)
        {
            if (id == null || token == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var user = _userService.GetById(id.Value);

            if(token.Value == user.Token)
            {
                if(user.Status)
                {
                    TempData["Status"] = "Tài khoản đã được kích hoạt!";
                }
                else
                {
                    user.Status = true;
                    _userService.Save();
                    TempData["Status"] = "Kích hoạt thành công!";
                }
            }
            else
            {
                TempData["Status"] = "Kích hoạt thất bại!";
            }
            return Redirect("/");
        }
    }
}