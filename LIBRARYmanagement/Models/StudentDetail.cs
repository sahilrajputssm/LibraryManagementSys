using System;
using System.Collections.Generic;

namespace LIBRARYmanagement.Models
{
    public partial class StudentDetail
    {
        public StudentDetail()
        {
            BookDetail = new HashSet<BookDetail>();
        }

        public int StudentId { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public int? Age { get; set; }

        public virtual ICollection<BookDetail> BookDetail { get; set; }
    }
}
