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
        private readonly IFacultyService _facultyService;
        public HomeController(IUserService userService, IFacultyService facultyService)
        {
            _userService = userService;
            _facultyService = facultyService;
        }
        public ActionResult Index()
        {
            ViewBag.ListFaculties = _facultyService.GetAll().ToList();
            ViewBag.ID = _userService.GetAll().OrderByDescending(x=>x.UserId).Select(x=>x.UserId).FirstOrDefault();
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
            if(state == -2)
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
            _userService.Add(user);
            TempData["Status"] = "Đăng ký thành công!";
            return Redirect("/");
        }
    }
}