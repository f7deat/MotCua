using MotCua.Model;
using MotCua.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MotCua.Web.Areas.Student.Controllers
{
    public class RequestsController : Controller
    {
        private const string V = "Gửi yêu cầu thất bại!";
        private const string V1 = "Gửi yêu cầu thành công!";
        private const string V2 = "RequestStatus";
        IRequestService _requestService;

        public RequestsController(IRequestService requestService)
        {
            _requestService = requestService;
        }

        // GET: Student/Requests
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Request request)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _requestService.Add(request);
                    TempData[V2] = V1;
                }
            }
            catch (Exception)
            {
                TempData[V2] = V;
            }
            return Redirect("/Student/Dashboards");
        }
    }
}