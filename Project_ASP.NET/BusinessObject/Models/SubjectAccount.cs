using System;
using System.Collections.Generic;

namespace BusinessObject.Models
{
    public partial class SubjectAccount
    {
        public int SubjectAccountId { get; set; }
        public int? SubjectId { get; set; }
        public int? AccountId { get; set; }

        public virtual Account? Account { get; set; }
        public virtual Subject? Subject { get; set; }
    }
}
