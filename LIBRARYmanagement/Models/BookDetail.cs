using System;
using System.Collections.Generic;

namespace LIBRARYmanagement.Models
{
    public partial class BookDetail
    {
        public int BookId { get; set; }
        public string BookName { get; set; }
        public int? StudentId { get; set; }

        public virtual StudentDetail? Student { get; set; }
    }
}
