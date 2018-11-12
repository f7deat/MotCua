using MotCua.Helper;
using MotCua.Helper.Common;
using MotCua.Helper.Session;
using MotCua.Model;
using MotCua.Model.Data;
using MotCua.Service;
using MotCua.Web.Areas.Admin.Models;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace MotCua.Web.Areas.Admin.Controllers
{
    public class GroupsController : BaseController
    {
        private IGroupService _groupService;
        private readonly IDepartmentService _departmentService;
        private IRoleService _roleService;
        public GroupsController(IGroupService groupService, IDepartmentService departmentService, IRoleService roleService)
        {
            _groupService = groupService;
            _departmentService = departmentService;
            _roleService = roleService;
        }
        
        public async Task<ActionResult> Index()
        {
            var session = (UserSessionModel)Session[Constants.USER_SESSION];
            var group = _groupService.GetById(session.Group);
            if(group.GroupName.Trim().ToLower() == "admin")
            {
                ViewBag.ListDepartments = _departmentService.GetAll();
                ViewBag.ListRoles = _roleService.GetAll().Distinct().ToList();
                return View(await _groupService.GetAll().ToListAsync());
            }
            else
            {
                return Redirect("/Admin/Errors/Authorized");
            }
        }

        [HttpPost]
        public ActionResult SetRole(int? id, GroupRoleViewModel groupRoleViewModel)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IQueryable<Role> existRole = _roleService.GetAll().Where(x => x.GroupId == id);
            _roleService.RemoveRange(existRole);
            foreach (int item in groupRoleViewModel.DepartmentId)
            {
                _roleService.Add(new Role
                {
                    GroupId = id.Value,
                    Name = item.ToString()
                });
            }
            TempData["Status"] = "Cài đặt quyền thành công!";
            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateOrUpdate(FormCollection group)
        {
            if (ModelState.IsValid)
            {
                string groupName = group["GroupName"];
                int groupId = int.Parse(group["GroupId"]);
                Group gr = _groupService.GetById(groupId);
                if (groupId == 0)
                {
                    _groupService.Add(new Group
                    {
                        GroupName = groupName
                    });
                    TempData["Status"] = "Thêm thành công!";
                }
                else
                {
                    gr.GroupName = groupName;
                    _groupService.Update(gr);
                    TempData["Status"] = "Sửa thành công!";
                }
                return RedirectToAction("Index");
            }

            return View(group);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Group group = _groupService.GetById(id.Value);
            if (group == null)
            {
                return HttpNotFound();
            }
            _groupService.Delete(group);
            TempData["Status"] = "Xóa thành công!";
            return RedirectToAction("Index");
        }
    }
}
