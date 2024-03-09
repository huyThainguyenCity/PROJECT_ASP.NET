using System;
using System.Collections.Generic;

namespace BusinessObject.Models
{
    public partial class Feedback
    {
        public int FeedbackId { get; set; }
        public int? SubjectId { get; set; }
        public string? Description { get; set; }
        public DateTime? CreateDate { get; set; }
        public int? AccountId { get; set; }
        public int? Status { get; set; }

        public virtual Account? Account { get; set; }
        public virtual Subject? Subject { get; set; }
    }
}
