using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FormBuilder.Models
{
    [Serializable]
    public class FormSettingsModel
    {
        public bool? isDisplay { get; set; }
        public bool? isDataDisplay { get; set; }
        public bool? isFormDisplay { get; set; }
        public bool? isHeaderFilterDisplay { get; set; }
        public bool? isTopFilterDisplay { get; set; }
        public int? PageSize { get; set; }

        public bool? isEmailEnable { get; set; }
        public bool? isAddFormInfo { get; set; }
        public bool? isAttachPdf { get; set; }
        public bool? isDefaultEmail { get; set; }
        public bool? isCustomEmail { get; set; }
        public string mailTo { get; set; }
        public string mailSubject { get; set; }
        public string mailServer { get; set; }
        public string userAccount { get; set; }
        public string accountPassword { get; set; }
        public string headerContent { get; set; }
        public string emailBodyContent { get; set; }

        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public Guid RegKey { get; set; }

        public string formType { get; set; }
        public string redirectUrl { get; set; }
    }
}