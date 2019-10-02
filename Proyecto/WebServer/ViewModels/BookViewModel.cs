using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebServer.ViewModels
{
    public class BookViewModel
    {
        public int BookId { get; set; }
        public string Name { get; set; }
        public int Pagecount { get; set; }
        public int Point { get; set; }
        public int AuthorId { get; set; }
        public int CategoryId { get; set; }
    }
}
