using MotCua.Model;
using MotCua.Service;
using PagedList;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace MotCua.Web.Areas.Admin.Controllers
{
    public class FacultiesController : BaseController
    {
        private readonly IFacultyService _facultyService;
        public FacultiesController(IFacultyService facultyService)
        {
            _facultyService = facultyService;
        }
        [ChildActionOnly]
        public ActionResult ListFaculties(int? page)
        {
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            return PartialView(_facultyService.GetAll().OrderBy(x => x.FacultyName).ToPagedList(pageNumber, pageSize));
        }
        [HttpPost]
        public ActionResult CreateOrUpdate(Faculty faculty)
        {
            if (faculty.FacultyId != 0)
            {
                _facultyService.Update(faculty);
            }
            else
            {
                _facultyService.Add(faculty);
            }
            return Redirect("/Admin/Departments");
        }
        [HttpPost]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            _facultyService.Delete(_facultyService.GetById(id.Value));
            TempData["Status"] = "Xóa thành công!";
            return Redirect("/Admin/Departments");
        }
    }
}