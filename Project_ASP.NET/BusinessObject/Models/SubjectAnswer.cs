using System;
using System.Collections.Generic;

namespace BusinessObject.Models
{
    public partial class SubjectAnswer
    {
        public int SubjectAnswerId { get; set; }
        public int? SubjectId { get; set; }
        public int? AnswerId { get; set; }

        public virtual Subject? Answer { get; set; }
        public virtual Answer? Subject { get; set; }
    }
}
