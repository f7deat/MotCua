using MotCua.Helper;
using MotCua.Helper.Common;
using MotCua.Helper.Session;
using MotCua.Model;
using MotCua.Service;
using MotCua.Web.Areas.Student.Models;
using System;
using System.IO;
using System.Transactions;
using System.Web;
using System.Web.Mvc;

namespace MotCua.Web.Areas.Student.Controllers
{
    [CustomAuthorize(Roles = "student")]
    public class RequestsController : Controller
    {
        private const string V = "Gửi yêu cầu thất bại!";
        private const string V1 = "Gửi yêu cầu thành công!";
        private const string V2 = "RequestStatus";
        private IRequestService _requestService;
        private IAttachService _attachService;

        public RequestsController(IRequestService requestService, IAttachService attachService)
        {
            _requestService = requestService;
            _attachService = attachService;
        }

        // GET: Student/Requests
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Index(RequestViewModel request)
        {
            UserSessionModel session = (UserSessionModel)Session[Constants.USER_SESSION];
            try
            {
                if (ModelState.IsValid)
                {
                    using (TransactionScope tran = new TransactionScope())
                    {
                        Request res = _requestService.Add(new Request
                        {
                            Content = request.Content,
                            UserId = session.UserId,
                            RequestDate = DateTime.Now,
                            Status = RequestStatus.Sending
                        });
                        if (request.AttachName != null)
                        {
                            foreach (string item in request.AttachName)
                            {
                                _attachService.Add(new Attach
                                {
                                    Path = item,
                                    DateUpload = DateTime.Now,
                                    RequestId = res.RequestId
                                });
                            }
                        }
                        TempData[V2] = V1;
                        tran.Complete();
                    }

                }
            }
            catch (Exception)
            {
                TempData[V2] = V;
            }
            return Redirect("/Student/Dashboards");
        }

        [HttpPost]
        public JsonResult Upload(HttpPostedFileBase Attach)
        {
            if (Attach != null && Attach.ContentLength > 0)
            {
                // extract only the filename
                string fileName = Path.GetFileName(Attach.FileName);
                // store the file inside ~/App_Data/uploads folder
                string path = Path.Combine(Server.MapPath("~/Content/files/"), fileName);
                Attach.SaveAs(path);
            }
            return Json(Attach.FileName, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult RemoveFile(string fileName)
        {
            string fullPath = Request.MapPath("~/Content/files/" + fileName);
            if (System.IO.File.Exists(fullPath))
            {
                System.IO.File.Delete(fullPath);
            }
            return Json(true, JsonRequestBehavior.AllowGet);
        }

    }
}