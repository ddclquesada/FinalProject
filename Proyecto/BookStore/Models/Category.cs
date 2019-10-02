using System;
using System.Collections.Generic;

namespace BookStore.Models
{
    public partial class Category
    {
        public Category()
        {
            Book = new HashSet<Book>();
        }

        public int? CategoryId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Book> Book { get; set; }
    }
}
