using System;
using System.Collections.Generic;

namespace BusinessObject.Models
{
    public partial class Teacher
    {
        public Teacher()
        {
            Answers = new HashSet<Answer>();
            SubjectTeachers = new HashSet<SubjectTeacher>();
        }

        public int TeacherId { get; set; }
        public string? FullName { get; set; }
        public string? Email { get; set; }
        public string? Avatar { get; set; }
        public string? Address { get; set; }
        public int? PhoneNumber { get; set; }
        public int? AccountId { get; set; }

        public virtual Account? Account { get; set; }
        public virtual ICollection<Answer> Answers { get; set; }
        public virtual ICollection<SubjectTeacher> SubjectTeachers { get; set; }
    }
}
