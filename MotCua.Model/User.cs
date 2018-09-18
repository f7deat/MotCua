using System;
using System.ComponentModel.DataAnnotations;

namespace MotCua.Model
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        [Required, MaxLength(100)]
        public string Password { get; set; }
        [Required, MaxLength(100)]
        public string FullName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public bool Gender { get; set; }
        [MaxLength(500)]
        public string Address { get; set; }
        [MaxLength(200)]
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime CreatedDate { get; set; }
        [MaxLength(200)]
        public string Image { get; set; }
        public bool Status { get; set; }

        public virtual Role Role { get; set; }
    }
}
