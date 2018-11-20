using System.ComponentModel.DataAnnotations;

namespace MotCua.Model
{
    public class Setting
    {
        [Key]
        public int Id { get; set; }
        [StringLength(200), Required]
        public string Email { get; set; }
        [StringLength(200), Required]
        public string Password { get; set; }
        public bool IsClosed { get; set; }
    }
}
