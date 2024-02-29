using System;
using System.Collections.Generic;

namespace BusinessObject.Models
{
    public partial class Question
    {
        public Question()
        {
            Answers = new HashSet<Answer>();
            SubjectQuestions = new HashSet<SubjectQuestion>();
        }

        public int QuenstionId { get; set; }
        public int? StudentId { get; set; }
        public int? SubjectId { get; set; }
        public string? Description { get; set; }
        public DateTime? CreateDate { get; set; }

        public virtual ICollection<Answer> Answers { get; set; }
        public virtual ICollection<SubjectQuestion> SubjectQuestions { get; set; }
    }
}
