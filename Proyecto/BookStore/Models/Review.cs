using System;
using System.Collections.Generic;

namespace BookStore.Models
{
    public partial class Review
    {
        public int ReviewId { get; set; }
        public string Person { get; set; }
        public string ReviewText { get; set; }
        public DateTime? Date { get; set; }
        public int? BookId { get; set; }

        public virtual Book Book { get; set; }
    }
}
