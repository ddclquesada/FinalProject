using System;
using System.Collections.Generic;

namespace BookStore.Models
{
    public partial class Student
    {
        public Student()
        {
            Borrow = new HashSet<Borrow>();
        }

        public int StudentId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime? Birthdate { get; set; }
        public string Gender { get; set; }
        public string Class { get; set; }
        public int? Point { get; set; }

        public virtual ICollection<Borrow> Borrow { get; set; }
    }
}
