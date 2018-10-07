using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MotCua.Model
{
    public class Group
    {
        public int GroupId { get; set; }
        [StringLength(50)]
        public string GroupName { get; set; }

        public ICollection<User> Users { get; set; }
        public ICollection<Role> Roles { get; set; }
    }
}
