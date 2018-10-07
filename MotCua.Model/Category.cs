using System.Collections.Generic;

namespace MotCua.Model
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string Decription { get; set; }

        public virtual ICollection<Request> Requests { get; set; }
    }
}
