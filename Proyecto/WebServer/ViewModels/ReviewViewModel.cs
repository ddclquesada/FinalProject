using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebServer.ViewModels
{
    public class ReviewViewModel
    {
        public int ReviewId { get; set; }
        public string Person { get; set; }
        public string ReviewText { get; set; }
        public DateTime Date { get; set; }
        public int BookId { get; set; }

    }
}
