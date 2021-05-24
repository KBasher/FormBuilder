using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FormBuilder.Models
{
    [Serializable]
    public class FileSettingsModel
    {
        public int Id { get; set; }
        public byte[] Image { get; set; }
        public string ImageName { get; set; }
        public string FileType { get; set; }

        //Used when update the file setting from admin

        public bool? Download { get; set; }
        public bool? AddLink { get; set; }
        public string LinkUrl { get; set; }
        public string ImageUrl { get; set; }
    }
}