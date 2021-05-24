using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FormBuilder.Models
{
    public class ComponentInfo
    {
        public int id { get; set; }
        public string key { get; set; }
        public string label { get; set; }
        public string type { get; set; }
        public string dataformat { get; set; }
    }
}