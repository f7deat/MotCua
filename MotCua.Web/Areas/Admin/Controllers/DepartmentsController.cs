using MotCua.Helper.Common;
using MotCua.Helper.Session;
using MotCua.Model;
using MotCua.Model.Data;
using MotCua.Service;
using PagedList;
using System.Data.Entity;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Linq;

namespace MotCua.Web.Areas.Admin.Controllers
{
    public class DepartmentsController : BaseController
    {
        private IGroupService _groupService;
        private readonly IFacultyService _facultyService;
        private MotCuaDbContext db = new MotCuaDbContext();
        private IDepartmentService _departmentService;
        public DepartmentsController(IDepartmentService departmentService, IGroupService groupService, IFacultyService facultyService)
        {
            _groupService = groupService;
            _departmentService = departmentService;
            _facultyService = facultyService;
        }

        public ActionResult Index(int? page)
        {
            UserSessionModel session = (UserSessionModel)Session[Constants.USER_SESSION];
            Group group = _groupService.GetById(session.Group);
            if (group.GroupName.Trim().ToLower() == "admin")
            {
                int pageSize = 10;
                int pageNumber = (page ?? 1);
                return View(_departmentService.GetAll().OrderBy(x=>x.DepartmentName).ToPagedList(pageNumber, pageSize));
            }
            else
            {
                return Redirect("/Admin/Errors/Authorized");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateOrUpdate(Department department)
        {
            if (department == null)
            {
                return HttpNotFound();
            }
            if (ModelState.IsValid)
            {
                if (department.DepartmentId == 0)
                {
                    _departmentService.Add(department);
                }
                else
                {
                    _departmentService.Update(department);
                }
                return RedirectToAction("Index");
            }

            return View(department);
        }

        // GET: Admin/Departments/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Department department = await db.Departments.FindAsync(id);
            if (department == null)
            {
                return HttpNotFound();
            }
            return View(department);
        }

        // POST: Admin/Departments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Department department = await db.Departments.FindAsync(id);
            db.Departments.Remove(department);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
