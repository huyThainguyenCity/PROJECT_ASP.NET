using System;
using System.Collections.Generic;

namespace BusinessObject.Models
{
    public partial class Subject
    {
        public Subject()
        {
            SubjectAnswers = new HashSet<SubjectAnswer>();
            SubjectQuestions = new HashSet<SubjectQuestion>();
            SubjectStudents = new HashSet<SubjectStudent>();
            SubjectTeachers = new HashSet<SubjectTeacher>();
        }

        public int SubjectId { get; set; }
        public string? SubjectName { get; set; }

        public virtual ICollection<SubjectAnswer> SubjectAnswers { get; set; }
        public virtual ICollection<SubjectQuestion> SubjectQuestions { get; set; }
        public virtual ICollection<SubjectStudent> SubjectStudents { get; set; }
        public virtual ICollection<SubjectTeacher> SubjectTeachers { get; set; }
    }
}
