using System;
using System.Collections.Generic;

namespace BusinessObject.Models
{
    public partial class Account
    {
        public Account()
        {
            Questions = new HashSet<Question>();
            SubjectAccounts = new HashSet<SubjectAccount>();
        }

        public int AccountId { get; set; }
        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;
        public int? RoleId { get; set; }
        public string? FullName { get; set; }
        public string? TeacherCode { get; set; }
        public string? StudentCode { get; set; }
        public string? Address { get; set; }
        public int? PhoneNumber { get; set; }
        public string? Avatar { get; set; }

        public virtual Role? Role { get; set; }
        public virtual ICollection<Question> Questions { get; set; }
        public virtual ICollection<SubjectAccount> SubjectAccounts { get; set; }
    }
}
