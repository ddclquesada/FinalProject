using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookStore.Models
{
    public partial class Book
    {
        public Book()
        {
            Borrow = new HashSet<Borrow>();
            Review = new HashSet<Review>();
        }

        public int BookId { get; set; }
        public string Name { get; set; }
        public int? Pagecount { get; set; }
        public int? Point { get; set; }
        public int? AuthorId { get; set; }
        public int? CategoryId { get; set; }

        public virtual Author Author { get; set; }
        public virtual Category Category { get; set; }
        public virtual ICollection<Borrow> Borrow { get; set; }
        public virtual ICollection<Review> Review { get; set; }

        public static Task<List<Book>> Request(string v, int id)
        {
            throw new NotImplementedException();
        }
    }
}
