using System.Collections.Generic;

namespace MotCua.Model
{
    public class Department
    {
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Request> Requests { get; set; }
    }
}
