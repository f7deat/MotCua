using MotCua.Helper;
using MotCua.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MotCua.Helper.Common;

namespace MotCua.Web.Areas.Admin.Controllers
{
    public class DashboardController : BaseController
    {
        IRequestService _requestService;
        IDepartmentService _departmentService;
        public DashboardController(IRequestService requestService, IDepartmentService departmentService)
        {
            _requestService = requestService;
            _departmentService = departmentService;
        }
        // GET: Admin/Dashboard
        public ActionResult Index()
        {
            return View();
        }
        [ChildActionOnly]
        public ActionResult QuickStatic()
        {
            ViewBag.TotalRequest = _requestService.GetAll().Count();
            ViewBag.TotalRequestSuccess = _requestService.GetAll().Where(x=>x.Status == RequestStatus.Success).Count();
            ViewBag.TotalRequestProcessing = _requestService.GetAll().Where(x => x.Status == RequestStatus.Processing).Count();
            return PartialView();
        }
        [ChildActionOnly]
        public ActionResult Sidebar()
        {
            return PartialView(_departmentService.GetAll());
        }
    }
}