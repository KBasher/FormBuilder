using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FormBuilder.Models
{
    public class FormGridModelSort
    {
        public int PageSize { get; set; }
        public List<FormInfo> DataBody { get; set; }
        public List<PageModel> Pages { get; set; }
    }
}