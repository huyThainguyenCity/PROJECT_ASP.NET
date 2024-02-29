using System;
using System.Collections.Generic;

namespace BusinessObject.Models
{
    public partial class SubjectQuestion
    {
        public int SubjectQuestionId { get; set; }
        public int? SubjectId { get; set; }
        public int? QuestionId { get; set; }

        public virtual Question? Question { get; set; }
        public virtual Subject? Subject { get; set; }
    }
}
