using System;
using System.Collections.Generic;

namespace BusinessObject.Models
{
    public partial class SubjectStudent
    {
        public int SubjectStudent1 { get; set; }
        public int? StudentId { get; set; }
        public int? SubjectId { get; set; }

        public virtual Student? Student { get; set; }
        public virtual Subject? Subject { get; set; }
    }
}
