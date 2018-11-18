using MotCua.Helper.Common;
using MotCua.Helper.Session;
using MotCua.Model;
using MotCua.Service;
using MotCua.Web.Areas.Admin.Controllers;
using MotCua.Web.Areas.Student.Models;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace MotCua.Web.Areas.Student.Controllers
{
    public class ProfileController : BaseController
    {
        private IUserService _userService;
        IRequestService _requestService;
        IFacultyService _facultyService;
        public ProfileController(IUserService userService, IRequestService requestService, IFacultyService facultyService)
        {
            _userService = userService;
            _requestService = requestService;
            _facultyService = facultyService;
        }
        // GET: Student/Profile
        public ActionResult Index()
        {
            UserSessionModel user = (UserSessionModel)Session[Constants.USER_SESSION];
            ViewBag.TotalRequest = _requestService.GetAll().Where(x => x.UserId == user.UserId).Count();
            return View(_userService.GetById(user.UserId));
        }

        public ActionResult ChangePassword()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ChangePassword(ChangePasswordViewModel pwd)
        {
            var session = (UserSessionModel)Session[Constants.USER_SESSION];
            var user = _userService.GetById(session.UserId);
            if(pwd.OldPassword == user.Password)
            {
                if(pwd.NewPassword == pwd.ConfirmdPassword)
                {
                    user.Password = pwd.NewPassword;
                    _userService.Save();
                    TempData["Status"] = "Đổi mật khẩu thành công!";
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["Status"] = "Mật khẩu mới không khớp!";
                }
            }
            else
            {
                TempData["Status"] = "Mật khẩu cũ không chính xác!";
            }
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = _userService.GetById(id.Value);
            if (user == null)
            {
                return HttpNotFound();
            }
            ViewBag.FacultyId = new SelectList(_facultyService.GetAll(), "FacultyId", "FacultyName", user.FacultyId);
            return View(user);
        }

        [HttpPost]
        public ActionResult Edit(User user)
        {
            if (ModelState.IsValid)
            {
                _userService.Update(user);
                TempData["Status"] = "Cập nhật thành công!";
                return RedirectToAction("Index");
            }
            ViewBag.FacultyId = new SelectList(_facultyService.GetAll(), "FacultyId", "FacultyName", user.FacultyId);
            return View(user);
        }
    }
}