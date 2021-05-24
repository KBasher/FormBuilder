using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FormBuilder.Models
{
    public class FileSettingsViewModel
    {
        public int Id { get; set; }
        public string imageName { get; set; }
        public string fileType { get; set; }
        public string key { get; set; }

        public bool? download { get; set; }
        public bool? addLink { get; set; }
        public string linkUrl { get; set; }
        public string imageUrl { get; set; }

    }
}