using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MotCua.Model
{
    public class Request
    {
        [Key]
        public int RequestId { get; set; }
        public int UserId { get; set; }
        public string Content { get; set; }
        public DateTime RequestDate { get; set; }
        public DateTime DateReceived { get; set; }
        public int? DepartmentId { get; set; }
        public DateTime? DateRequired { get; set; }
        public int? Status { get; set; }
        public int? CategoryId { get; set; }

        public virtual Department Department { get; set; }
        public virtual Category Category { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<Attach> Attaches { get; set; }
    }
}
