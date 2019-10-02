using System;
using System.Collections.Generic;

namespace BookStore.Models
{
    public partial class Borrow
    {
        public int BorrowId { get; set; }
        public int? StudentId { get; set; }
        public int? BookId { get; set; }
        public DateTime? TakenDate { get; set; }
        public DateTime? BroughtDate { get; set; }

        public virtual Book Book { get; set; }
        public virtual Student Student { get; set; }
    }
}
