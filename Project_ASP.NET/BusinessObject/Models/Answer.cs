using System;
using System.Collections.Generic;

namespace BusinessObject.Models
{
    public partial class Answer
    {
        public Answer()
        {
            SubjectAnswers = new HashSet<SubjectAnswer>();
        }

        public int AnswerId { get; set; }
        public int? TeacherId { get; set; }
        public int? QuestionId { get; set; }
        public string? Description { get; set; }
        public DateTime? ReplyDate { get; set; }
        public int? SubjectId { get; set; }

        public virtual Question? Question { get; set; }
        public virtual Teacher? Teacher { get; set; }
        public virtual ICollection<SubjectAnswer> SubjectAnswers { get; set; }
    }
}
