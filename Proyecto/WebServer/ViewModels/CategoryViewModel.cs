using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebServer.ViewModels
{
    public class CategoryViewModel
    {
        public int CategoryId { get; set; }
        public string name { get; set; }
    }
}
