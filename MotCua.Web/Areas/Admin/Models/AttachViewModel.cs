using MotCua.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MotCua.Web.Areas.Admin.Models
{
    public class AttachViewModel
    {
        public IEnumerable<Request> Requests { get; set; }
        public IEnumerable<Attach> Attaches { get; set; }
    }
}