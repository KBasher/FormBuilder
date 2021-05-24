using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FormBuilder.Models
{
    public class FormDataModelSort
    {
        public int PageSize { get; set; }
        public string FormType { get; set; }
        public List<ComponentInfo> DataHeader { get; set; }
        public List<FormBodyDataModel> DataBody { get; set; }
        public List<PageModel> Pages { get; set; }
    }
}