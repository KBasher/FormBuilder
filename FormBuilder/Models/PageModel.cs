using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FormBuilder.Models
{
    public class PageModel
    {
        public int PageNumber { get; set; }
        public int PageStart { get; set; }
        public int PageEnd { get; set; }
        public bool isDisplay { get; set; }
    }
}