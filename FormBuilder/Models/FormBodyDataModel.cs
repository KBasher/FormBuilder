using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FormBuilder.Models
{
    public class FormBodyDataModel
    {
        public int id { get; set; }
        public int dataItemId { get; set; }
        public bool isDisplay { get; set; }

        //public bool? download { get; set; }
        //public bool? addLink { get; set; }
        //public string linkUrl { get; set; }
        //public string imageUrl { get; set; }

        public string patientName { get; set; }
        public string doctorName { get; set; }
        public int? AppointmentID { get; set; }
        public string Date { get; set; }
        public bool? IsDeleted { get; set; }
        public int? Deletedby { get; set; }
        public string Deleteddate { get; set; }
        public int? UpdatedBy { get; set; }
        public string UpdatedDate { get; set; }
        public int? CreatedBy { get; set; }
        public string CreateDate { get; set; }


        public List<FormBodyDataDetailsModel> DataDetailsList { get; set; }
    }
}