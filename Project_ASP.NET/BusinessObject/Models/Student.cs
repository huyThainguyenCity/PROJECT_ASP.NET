using System;
using System.Collections.Generic;

namespace BusinessObject.Models
{
    public partial class Student
    {
        public Student()
        {
            SubjectStudents = new HashSet<SubjectStudent>();
        }

        public int StudentId { get; set; }
        public string? FullName { get; set; }
        public string? StudentCode { get; set; }
        public string? Email { get; set; }
        public int? PhoneNumber { get; set; }
        public string? Address { get; set; }
        public string? Avatar { get; set; }
        public int? AccountId { get; set; }

        public virtual Account? Account { get; set; }
        public virtual ICollection<SubjectStudent> SubjectStudents { get; set; }
    }
}
