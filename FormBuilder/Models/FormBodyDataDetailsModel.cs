using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FormBuilder.Models
{
    public class FormBodyDataDetailsModel
    {
        public int id { get; set; }
        public string value { get; set; }
        public string comtype { get; set; }
        public int ItemId { get; set; }
        public bool isImage { get; set; }
        public int ImageNo { get; set; }
        public string ImageName { get; set; }
        public string key { get; set; }
        public string dataformat { get; set; }

        public string fileName { get; set; }
        public string fileBase64 { get; set; }

        public FileSettingsViewModel FileSettingsViewModel { get; set; }
    }
}