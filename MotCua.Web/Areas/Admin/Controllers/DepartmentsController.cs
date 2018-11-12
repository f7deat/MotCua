using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MotCua.Model;
using MotCua.Model.Data;
using MotCua.Service;
using MotCua.Helper;
using MotCua.Helper.Session;
using MotCua.Helper.Common;

namespace MotCua.Web.Areas.Admin.Controllers
{
    public class DepartmentsController : BaseController
    {
        private IGroupService _groupService;
        private MotCuaDbContext db = new MotCuaDbContext();
        IDepartmentService _departmentService;
        public DepartmentsController(IDepartmentService departmentService, IGroupService groupService)
        {
            _groupService = groupService;
            _departmentService = departmentService;
        }
        // GET: Admin/Departments
        public async Task<ActionResult> Index()
        {
            var session = (UserSessionModel)Session[Constants.USER_SESSION];
            var group = _groupService.GetById(session.Group);
            if (group.GroupName.Trim().ToLower() == "admin")
            {
                return View(await _departmentService.GetAll().ToListAsync());
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
