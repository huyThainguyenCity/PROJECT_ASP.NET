using System;
using System.Collections.Generic;

namespace BusinessObject.Models
{
    public partial class SubjectTeacher
    {
        public int SubjectTeacherId { get; set; }
        public int? TeacherId { get; set; }
        public int? SubjectId { get; set; }

        public virtual Subject? Subject { get; set; }
        public virtual Teacher? Teacher { get; set; }
    }
}
