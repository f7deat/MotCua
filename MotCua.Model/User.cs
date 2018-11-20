using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MotCua.Model
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        [Required, MaxLength(100)]
        public string Password { get; set; }
        public int? FacultyId { get; set; }
        public int GroupId { get; set; }
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
        public int? Token { get; set; }

        public virtual Group Group { get; set; }
        public virtual Faculty Faculty { get; set; }
        public virtual ICollection<Request> Requests { get; set; }
    }
}
