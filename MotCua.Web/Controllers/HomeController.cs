using MotCua.Helper.Common;
using MotCua.Helper.Session;
using MotCua.Model;
using MotCua.Service;
using System.Linq;
using System.Web.Mvc;

namespace MotCua.Web.Controllers
{
    public class HomeController : Controller
    {
        private IUserService _userService;
        public HomeController(IUserService userService)
        {
            _userService = userService;
        }
        public ActionResult Index()
        {
            ViewBag.ID = _userService.GetAll().OrderByDescending(x=>x.UserId).Select(x=>x.UserId).FirstOrDefault();
            return View();
        }

        [HttpPost]
        public ActionResult Index(User login)
        {
            int state = _userService.Login(login.UserId, login.Password);
            if (state == 1)
            {
                var user = _userService.GetById(login.UserId);
                var userSession = new UserSessionModel();
                userSession.UserId = user.UserId;
                // chưa làm phần lấy group. mặc định sẽ là admin
                userSession.Groups = "admin";
                userSession.FullName = user.FullName;
                userSession.Image = user.Image;

                Session.Add(Constants.USER_SESSION, userSession);

                return RedirectToAction("Index", "Dashboard", new { area = "Admin" });
            }
            else
                if (state == 2)
            {
                return RedirectToAction("Index", "Dashboards", new { area = "Student" });
            }
            else
            if(state == -2)
            {
                ViewBag.Error = "Tài khoản của bạn đang chờ để kích hoạt!";
            }
            else
            {
                ViewBag.Error = "Đăng nhập không thành công!";
            }
            return View();
        }

        [HttpPost]
        public ActionResult Register(User user)
        {
            _userService.Add(user);
            TempData["RegisterSuccess"] = "Đăng ký thành công!";
            return Redirect("/");
        }
    }
}