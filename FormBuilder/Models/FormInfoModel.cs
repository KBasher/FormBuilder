using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FormBuilder.Models
{
    public class FormInfoModel
    {
        public int Id { get; set; }
        public string FormName { get; set; }
        public string FormTitle { get; set; }
        public string FormType { get; set; }
        public string FormJSON { get; set; }

        public bool IsUse { get; set; }
    }
}