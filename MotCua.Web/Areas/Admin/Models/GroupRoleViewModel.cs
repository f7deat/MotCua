using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MotCua.Web.Areas.Admin.Models
{
    public class GroupRoleViewModel
    {
        public int GroupId { get; set; }
        public int[] DepartmentId { get; set; }
    }
}