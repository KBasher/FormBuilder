using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FormBuilder.Models
{
    public class FormDataModel
    {
        public int Id { get; set; }
        public Nullable<int> FormId { get; set; }
        public string DataJSON { get; set; }
        public Nullable<int> PatientID { get; set; }
        public Nullable<int> DoctorId { get; set; }
        public Nullable<int> AppointmentID { get; set; }
        public string Date { get; set; }
        public Nullable<bool> IsDeleted { get; set; }
        public Nullable<int> Deletedby { get; set; }
        public Nullable<System.DateTime> Deleteddate { get; set; }
        public Nullable<int> UpdatedBy { get; set; }
        public Nullable<System.DateTime> UpdatedDate { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public Nullable<System.DateTime> CreateDate { get; set; }
    }
}