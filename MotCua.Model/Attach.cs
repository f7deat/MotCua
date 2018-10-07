using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotCua.Model
{
    public class Attach
    {
        [Key]
        public int AttachId { get; set; }
        public int RequestId { get; set; }
        public string Path { get; set; }
        public string FileSize { get; set; }
        public DateTime DateUpload { get; set; }

        public virtual Request Request { get; set; }
    }
}
