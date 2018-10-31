using MotCua.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MotCua.Web.Areas.Admin.Controllers
{
    public class RequestDetailsController : Controller
    {
        IRequestService _requestService;
        public RequestDetailsController(IRequestService requestService)
        {
            _requestService = requestService;
        }
        // GET: Admin/RequestDetails
        public ActionResult Index()
        {
            return View(_requestService.GetAll());
        }
    }
}