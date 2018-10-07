using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotCua.Model
{
    public class Faculty
    {
        public int FacultyId { get; set; }
        public string FacultyName { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}
