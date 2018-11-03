using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MotCua.Web.Areas.Student.Models
{
    public class RequestViewModel
    {
        public int RequestId { get; set; }
        public int UserId { get; set; }
        public string Content { get; set; }
        public DateTime RequestDate { get; set; }
        public DateTime DateReceived { get; set; }
        public int? DepartmentId { get; set; }
        public DateTime? DateRequired { get; set; }
        public int? Status { get; set; }
        public int? CategoryId { get; set; }
        public string[] AttachName { get; set; }
    }
}