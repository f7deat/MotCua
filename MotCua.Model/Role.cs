using System.ComponentModel.DataAnnotations;

namespace MotCua.Model
{
    public class Role
    {
        [Key]
        public int RoleId { get; set; }
        public int GroupId { get; set; }
        [StringLength(50)]
        public string Name { get; set; }

        public virtual Group Group { get; set; }
    }
}
