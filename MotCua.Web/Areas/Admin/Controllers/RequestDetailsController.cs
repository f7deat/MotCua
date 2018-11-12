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
using MotCua.Helper.Session;
using MotCua.Helper.Common;

namespace MotCua.Web.Areas.Admin.Controllers
{
    public class RequestDetailsController : BaseController
    {
        IRequestService _requestService;
        private readonly IAttachService _attachService;
        private IDepartmentService _departmentService;
        private IGroupService _groupService;
        private IRoleService _roleService;
        public RequestDetailsController(IRequestService requestService, IAttachService attachService, IDepartmentService departmentService, IGroupService groupService, IRoleService roleService)
        {
            _requestService = requestService;
            _attachService = attachService;
            _departmentService = departmentService;
            _groupService = groupService;
            _roleService = roleService;
        }
        // GET: Admin/RequestDetails
        public ActionResult Index(int? page, int? id)
        {
            var session = (UserSessionModel)Session[Constants.USER_SESSION];
            var listRoles = _roleService.GetAll().Where(x => x.GroupId == session.Group).Select(x => x.Name);
            var group = _groupService.GetById(session.Group);

            if (listRoles.Contains(id.ToString()) || group.GroupName.Trim().ToLower() == "admin")
            {
                int pageSize = 10;
                int pageNumber = (page ?? 1);
                ViewBag.ListDepartments = _departmentService.GetAll();
                var model = _requestService.GetAll().OrderByDescending(x => x.RequestDate).ToPagedList(pageNumber, pageSize);
                if (id != null)
                {
                    model = _requestService.GetAll().Where(x => x.DepartmentId == id).OrderByDescending(x => x.RequestDate).ToPagedList(pageNumber, pageSize);
                }
                return View(model);
            }
            else
            {
                return Redirect("/Admin/Errors/Authorized");
            }
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