using MotCua.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using MotCua.Model;
using MotCua.Web.Areas.Admin.Models;
using MotCua.Helper;

namespace MotCua.Web.Areas.Admin.Controllers
{
    [CustomAuthorize(Roles = "admin")]
    public class RequestDetailsController : Controller
    {
        IRequestService _requestService;
        private readonly IAttachService _attachService;
        private IDepartmentService _departmentService;
        public RequestDetailsController(IRequestService requestService, IAttachService attachService, IDepartmentService departmentService)
        {
            _requestService = requestService;
            _attachService = attachService;
            _departmentService = departmentService;
        }
        // GET: Admin/RequestDetails
        public ActionResult Index(int? page)
        {
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            ViewBag.ListDepartments = _departmentService.GetAll();
            var model = _requestService.GetAll().OrderByDescending(x=>x.RequestDate).ToPagedList(pageNumber, pageSize);
            return View(model);
        }
        public ActionResult ChangeStatus(int id, int status)
        {
            if(_requestService.ChangeStatus(id, status))
            {
                TempData["ChangeStatus"] = "Đổi trạng thái thành công!";
            }
            else
            {
                TempData["ChangeStatus"] = "Đổi trạng thái thất bại!";
            }
            return Redirect("/Admin/RequestDetails");
        }

        public ActionResult Details(int id)
        {
            ViewBag.ListDepartments = _departmentService.GetAll();
            return View(_requestService.GetById(id));
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            _requestService.Delete(_requestService.GetById(id));
            TempData["ChangeStatus"] = "Xóa thành công!";
            return Redirect("/Admin/RequestDetails");
        }

        [HttpPost]
        public ActionResult UpdateRequest(Request request)
        {
            _requestService.UpdateRequest(request.RequestId, request.Status, request.DateRequired, request.DepartmentId);
            TempData["ChangeStatus"] = "Thay đổi thành công!";
            return Redirect("/Admin/RequestDetails");
        }
    }
}