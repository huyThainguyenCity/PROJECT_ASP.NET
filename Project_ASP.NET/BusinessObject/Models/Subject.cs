using System;
using System.Collections.Generic;

namespace BusinessObject.Models
{
    public partial class Subject
    {
        public Subject()
        {
            Questions = new HashSet<Question>();
            SubjectAccounts = new HashSet<SubjectAccount>();
        }

        public int SubjectId { get; set; }
        public string? SubjectName { get; set; }
        public string? SubjectCode { get; set; }

        public virtual ICollection<Question> Questions { get; set; }
        public virtual ICollection<SubjectAccount> SubjectAccounts { get; set; }
    }
}
