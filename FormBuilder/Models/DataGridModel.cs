using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FormBuilder.Models
{
    public class DataGridModel
    {
        public int Id { get; set; }
        public int FormId { get; set; }
        public string DataJSON { get; set; }
        public int? PatientID { get; set; }
        public string PatientName { get; set; }
        public int? DoctorID { get; set; }
        public string DoctorName { get; set; }
        public int? AppointmentID { get; set; }
        public string Date { get; set; }
        public bool? IsDeleted { get; set; }
        public int? Deletedby { get; set; }
        public string Deleteddate { get; set; }
        public int? UpdatedBy { get; set; }
        public string UpdatedDate { get; set; }
        public int? CreatedBy { get; set; }
        public string CreateDate { get; set; }

        public string FormName { get; set; }
        public string FormTitle { get; set; }
        public string FormType { get; set; }
        public string FormJSON { get; set; }

        public bool? IsUse { get; set; }


    }
}