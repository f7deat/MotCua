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

namespace MotCua.Web.Areas.Admin.Controllers
{
    [CustomAuthorize(Roles = "admin")]
    public class GroupsController : Controller
    {
        IGroupService _groupService;
        public GroupsController(IGroupService groupService)
        {
            _groupService = groupService;
        }
        private MotCuaDbContext db = new MotCuaDbContext();

        // GET: Admin/Groups
        public async Task<ActionResult> Index()
        {
            return View(await _groupService.GetAll().ToListAsync());
        }

        // GET: Admin/Groups/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Group group = await db.Groups.FindAsync(id);
            if (group == null)
            {
                return HttpNotFound();
            }
            return View(group);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(FormCollection group)
        {
            if (ModelState.IsValid)
            {
                var groupName = group["GroupName"];
                _groupService.Add(new Group
                {
                    GroupName = groupName
                });
                return RedirectToAction("Index");
            }

            return View(group);
        }

        // GET: Admin/Groups/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Group group = await db.Groups.FindAsync(id);
            if (group == null)
            {
                return HttpNotFound();
            }
            return View(group);
        }

        // POST: Admin/Groups/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "GroupId,GroupName")] Group group)
        {
            if (ModelState.IsValid)
            {
                db.Entry(group).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(group);
        }

        // GET: Admin/Groups/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Group group = await db.Groups.FindAsync(id);
            if (group == null)
            {
                return HttpNotFound();
            }
            return View(group);
        }

        // POST: Admin/Groups/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Group group = await db.Groups.FindAsync(id);
            db.Groups.Remove(group);
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
