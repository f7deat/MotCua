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
using PagedList;
using MotCua.Helper.Session;
using MotCua.Helper.Common;

namespace MotCua.Web.Areas.Admin.Controllers
{
    public class UsersController : BaseController
    {
        private IGroupService _groupService;
        IUserService _userService;
        private MotCuaDbContext db = new MotCuaDbContext();

        public UsersController(IGroupService groupService, IUserService userService)
        {
            _groupService = groupService;
            _userService = userService;
        }
        // GET: Admin/Users
        public ActionResult Index(int? page)
        {
            var session = (UserSessionModel)Session[Constants.USER_SESSION];
            var group = _groupService.GetById(session.Group);

            if (group.GroupName.Trim().ToLower() == "admin")
            {
                int pageSize = 10;
                int pageNumber = (page ?? 1);
                ViewBag.ListGroups = _groupService.GetAll();
                return View(_userService.GetAll().OrderBy(x => x.CreatedDate).ToPagedList(pageNumber, pageSize));
            }
            else
            {
                return Redirect("/Admin/Errors/Authorized");
            }
        }

        // GET: Admin/Users/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = _userService.GetById(id.Value);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // GET: Admin/Users/Create
        public ActionResult Create()
        {
            ViewBag.FacultyId = new SelectList(db.Faculties, "FacultyId", "FacultyName");
            ViewBag.GroupId = new SelectList(db.Groups, "GroupId", "GroupName");
            return View();
        }

        // POST: Admin/Users/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "UserId,Password,FacultyId,GroupId,FullName,DateOfBirth,Gender,Address,Email,PhoneNumber,CreatedDate,Image,Status")] User user)
        {
            if (ModelState.IsValid)
            {
                db.Users.Add(user);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.FacultyId = new SelectList(db.Faculties, "FacultyId", "FacultyName", user.FacultyId);
            ViewBag.GroupId = new SelectList(db.Groups, "GroupId", "GroupName", user.GroupId);
            return View(user);
        }

        // GET: Admin/Users/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = await db.Users.FindAsync(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            ViewBag.FacultyId = new SelectList(db.Faculties, "FacultyId", "FacultyName", user.FacultyId);
            ViewBag.GroupId = new SelectList(db.Groups, "GroupId", "GroupName", user.GroupId);
            return View(user);
        }

        // POST: Admin/Users/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "UserId,Password,FacultyId,GroupId,FullName,DateOfBirth,Gender,Address,Email,PhoneNumber,CreatedDate,Image,Status")] User user)
        {
            if (ModelState.IsValid)
            {
                db.Entry(user).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.FacultyId = new SelectList(db.Faculties, "FacultyId", "FacultyName", user.FacultyId);
            ViewBag.GroupId = new SelectList(db.Groups, "GroupId", "GroupName", user.GroupId);
            return View(user);
        }

        [HttpPost]
        public ActionResult ChangeStatus(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var user = _userService.GetById(id.Value);
            user.Status = !user.Status;
            _userService.Update(user);
            return RedirectToAction("Index");
        }

        // GET: Admin/Users/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = _userService.GetById(id.Value);
            if (user == null)
            {
                return HttpNotFound();
            }
            _userService.Delete(user);
            return View(user);
        }
    }
}
