using FormBuilder.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Web;
using System.Web.Mvc;

namespace FormBuilder.Controllers
{
    public class FormBuilderController : Controller
    {
        int PageSize = 5;
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult DataGrid(int Id, int? PatientId = 0)
        {
            FormInfo formInfo = new FormInfo();
            using (var db = new DotNetFormBuilderEntities())
            {
                formInfo = db.FormInfoes.Where(f => f.Id == Id).FirstOrDefault();
            }

            ViewBag.PatientName = "Patient " + PatientId;
            ViewBag.FormId = Id;
            ViewBag.FormName = formInfo.FormName;
            ViewBag.FormTitle = formInfo.FormTitle;
            ViewBag.PatientId = PatientId;

            return View();
        }
        public ActionResult ViewImage(int Id, string key)
        {
            FormData formData = new FormData();

            using (var db = new DotNetFormBuilderEntities())
            {
                formData = db.FormDatas.Where(d => d.Id == Id).FirstOrDefault();
            }
            ViewBag.DataJSON = formData.DataJSON;
            ViewBag.Key = key;

            return View();
        }
        public ActionResult List()
        {
            List<FormInfo> formList = new List<FormInfo>();
            using (var db = new DotNetFormBuilderEntities())
            {
                formList = db.FormInfoes.ToList();
            }
            return View(formList);
        }
        //public JsonResult GetDataGrid(int formId)
        //{
        //    List<DataGridModel> dataList = new List<DataGridModel>();
        //    using (var db = new DotNetFormBuilderEntities())
        //    {
        //        dataList = db.FormDatas.Include("FormInfo").Include("Patient").Include("Doctor")
        //            .Where(d=>d.FormId == formId)
        //            .Select(d => new DataGridModel()
        //        {
        //            Id = d.Id,
        //            FormId = d.FormInfo.Id,
        //            DataJSON = d.DataJSON,
        //            PatientID = d.PatientID,
        //            PatientName = d.PatientID != null ? d.Patient.Name : null,

        //            DoctorID = d.DoctorId,
        //            DoctorName = d.DoctorId != null ? d.Doctor.Name : null,

        //            AppointmentID =d.AppointmentID,
        //            Date = d.Date != null ? d.Date.Value.Month + "/" + d.Date.Value.Day + "/" +
        //            d.Date.Value.Year : "",
        //            IsDeleted = d.IsDeleted,
        //            Deletedby =d.Deletedby,
        //            Deleteddate = d.Deleteddate != null ? d.Deleteddate.Value.Month + "/" + d.Deleteddate.Value.Day + "/" +
        //            d.Deleteddate.Value.Year : "",
        //            UpdatedBy =d.UpdatedBy,
        //            UpdatedDate = d.UpdatedDate != null ? d.UpdatedDate.Value.Month + "/" + d.UpdatedDate.Value.Day + "/" +
        //            d.UpdatedDate.Value.Year : "",
        //            CreatedBy = d.CreatedBy,
        //            CreateDate = d.CreateDate != null ? d.CreateDate.Value.Month + "/" + d.CreateDate.Value.Day + "/" + 
        //            d.CreateDate.Value.Year : "",
        //            FormName = d.FormInfo.FormName,
        //            FormTitle = d.FormInfo.FormTitle,
        //            FormType = d.FormInfo.FormType,
        //            FormJSON = d.FormInfo.FormJSON,
        //            IsUse =d.FormInfo.IsUse
        //        }).OrderByDescending(d=>d.Date).ThenByDescending(d=>d.Id).ToList();
        //    }
        //    return Json(dataList, JsonRequestBehavior.AllowGet);
        //}
        public ActionResult Edit(int Id)
        {
            FormInfo formInfo = new FormInfo();
            using (var db = new DotNetFormBuilderEntities())
            {
                formInfo = db.FormInfoes.Where(f => f.Id == Id).FirstOrDefault();
            }
            return View(formInfo);
        }

        public JsonResult DeleteForm(int Id)
        {
            FormInfo formInfo = new FormInfo();
            try
            {
                using (var db = new DotNetFormBuilderEntities())
                {
                    formInfo = db.FormInfoes.Where(f => f.Id == Id).FirstOrDefault();

                    formInfo.IsDeleted = true;

                    //db.FormInfoes.Remove(formInfo);
                    db.SaveChanges();
                }
                return Json("Ok", JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json("Error", JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult DeleteData(int Id)
        {
            FormData formData = new FormData();
            try
            {
                using (var db = new DotNetFormBuilderEntities())
                {
                    formData = db.FormDatas.Where(f => f.Id == Id).FirstOrDefault();

                    formData.IsDeleted = true;

                    //db.FormInfoes.Remove(formInfo);
                    db.SaveChanges();
                }
                return Json("Ok", JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json("Error", JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult DisableEnableForm(int Id, bool value)
        {
            FormInfo formInfo = new FormInfo();
            try
            {
                using (var db = new DotNetFormBuilderEntities())
                {
                    formInfo = db.FormInfoes.Where(f => f.Id == Id).FirstOrDefault();

                    formInfo.IsDisable = value;

                    db.SaveChanges();
                }
                return Json("Ok", JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json("Error", JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult LockUnlockForm(int Id, bool value)
        {
            FormInfo formInfo = new FormInfo();
            try
            {
                using (var db = new DotNetFormBuilderEntities())
                {
                    formInfo = db.FormInfoes.Where(f => f.Id == Id).FirstOrDefault();

                    formInfo.IsLocked = value;

                    db.SaveChanges();
                }
                return Json("Ok", JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json("Error", JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult View(int Id)
        {
            List<Patient> patients = new List<Patient>();
            List<Doctor> doctors = new List<Doctor>();

            using (var db = new DotNetFormBuilderEntities())
            {
                patients = db.Patients.ToList();
                doctors = db.Doctors.ToList();
            }

            ViewBag.Patients = patients;
            ViewBag.Doctors = doctors;

            FormInfo formInfo = new FormInfo();
            using (var db = new DotNetFormBuilderEntities())
            {
                formInfo = db.FormInfoes.Where(f => f.Id == Id).FirstOrDefault();
            }
            return View(formInfo);
        }

        public ActionResult DataFilter(int? patientId = 0)
        {
            List<Patient> patients = new List<Patient>();
            using (var db = new DotNetFormBuilderEntities())
            {
                patients = db.Patients.ToList();
            }

            ViewBag.Patients = patients;
            ViewBag.SelectedId = patientId;

            return View(new List<FormInfo>());
        }

        public JsonResult GetFormDataById(int id)
        {
            FormData formdata = new FormData();
            using (var db = new DotNetFormBuilderEntities())
            {
                db.Configuration.LazyLoadingEnabled = false;

                formdata = db.FormDatas.Where(d => d.Id == id).FirstOrDefault();
            }

            return Json(formdata, JsonRequestBehavior.AllowGet);
        }

        //public JsonResult GetFormByPatient(int patientId)
        //{
        //    List<FormInfo> formInfos = new List<FormInfo>();
        //    using (var db = new DotNetFormBuilderEntities())
        //    {
        //        db.Configuration.LazyLoadingEnabled = false;

        //        formInfos = db.FormDatas.Include("FormInfo").Where(d => d.PatientID == patientId)
        //            .Select(d=>d.FormInfo).Distinct().ToList();
        //    }

        //    //ViewBag.Patients = patients;

        //    return Json(formInfos, JsonRequestBehavior.AllowGet);
        //}

        //public JsonResult GetDataByFormAndPatient(int formId, int patientId)
        //{
        //    List<DataGridModel> dataList = new List<DataGridModel>();
        //    using (var db = new DotNetFormBuilderEntities())
        //    {
        //        dataList = db.FormDatas.Include("FormInfo").Where(d => d.FormId == formId & d.PatientID == patientId).Select(d => new DataGridModel()
        //        {
        //            Id = d.Id,
        //            FormId = d.FormInfo.Id,
        //            DataJSON = d.DataJSON,

        //            PatientID = d.PatientID,
        //            PatientName = d.PatientID != null ? d.Patient.Name : null,

        //            DoctorID = d.DoctorId,
        //            DoctorName = d.DoctorId != null ? d.Doctor.Name : null,

        //            AppointmentID = d.AppointmentID,
        //            Date = d.Date != null ? d.Date.Value.Month + "/" + d.Date.Value.Day + "/" +
        //              d.Date.Value.Year : "",
        //            IsDeleted = d.IsDeleted,
        //            Deletedby = d.Deletedby,
        //            Deleteddate = d.Deleteddate != null ? d.Deleteddate.Value.Month + "/" + d.Deleteddate.Value.Day + "/" +
        //              d.Deleteddate.Value.Year : "",
        //            UpdatedBy = d.UpdatedBy,
        //            UpdatedDate = d.UpdatedDate != null ? d.UpdatedDate.Value.Month + "/" + d.UpdatedDate.Value.Day + "/" +
        //              d.UpdatedDate.Value.Year : "",
        //            CreatedBy = d.CreatedBy,
        //            CreateDate = d.CreateDate != null ? d.CreateDate.Value.Month + "/" + d.CreateDate.Value.Day + "/" +
        //              d.CreateDate.Value.Year : "",
        //            FormName = d.FormInfo.FormName,
        //            FormTitle = d.FormInfo.FormTitle,
        //            FormType = d.FormInfo.FormType,
        //            FormJSON = d.FormInfo.FormJSON,
        //            IsUse = d.FormInfo.IsUse
        //        }).ToList();
        //    }
        //    return Json(dataList, JsonRequestBehavior.AllowGet);

        //}
        public ActionResult ViewEdit(int Id)
        {
            List<Patient> patients = new List<Patient>();
            List<Doctor> doctors = new List<Doctor>();
            using (var db = new DotNetFormBuilderEntities())
            {
                patients = db.Patients.ToList();
                doctors = db.Doctors.ToList();
            }

            ViewBag.Patients = patients;
            ViewBag.Doctors = doctors;

            FormInfo formInfo = new FormInfo();
            FormData formData = new FormData();

            using (var db = new DotNetFormBuilderEntities())
            {
                formData = db.FormDatas.Where(d => d.Id == Id).FirstOrDefault();

                ViewBag.DataJSON = formData.DataJSON.Replace("\\n", "\\\\n");
                ViewBag.Id = formData.Id;

                if (formData.PatientID != null)
                    ViewBag.PatientId = formData.PatientID;
                else
                    ViewBag.PatientId = "";

                if (formData.DoctorId != null)
                    ViewBag.DoctorId = formData.DoctorId;
                else
                    ViewBag.DoctorId = "";

                if (formData.AppointmentID != null)
                    ViewBag.AppointmentId = formData.AppointmentID;
                else
                    ViewBag.AppointmentId = "";

                if (formData.Date != null)
                    ViewBag.Date = formData.Date.Value.Month + "/" + formData.Date.Value.Day + "/" + formData.Date.Value.Year;
                else
                    ViewBag.Date = "";

                formInfo = db.FormInfoes.Where(f => f.Id == formData.FormId).FirstOrDefault();
            }
            return View(formInfo);
        }

        

        [HttpPost()]
        public JsonResult SaveData(FormDataModel formData)
        {
            DateTime? date = null;
            if (!string.IsNullOrEmpty(formData.Date))
            {
                string[] dateArray = formData.Date.Split(new char[] { '/' });


                if (dateArray.Length == 3)
                {
                    date = new DateTime(Convert.ToInt32(dateArray[2]), Convert.ToInt32(dateArray[0]), Convert.ToInt32(dateArray[1]));
                }
            }


            FormData data;
            using (var db = new DotNetFormBuilderEntities())
            {
                data = new FormData()
                {
                    FormId = formData.FormId,
                    DataJSON = formData.DataJSON,
                    //PatientID = formData.PatientID,
                    AppointmentID = formData.AppointmentID,
                    Date = string.IsNullOrEmpty(formData.Date) ? (DateTime?)null : date,
                    CreateDate = DateTime.Now
                };

                if (formData.PatientID != 0)
                    data.PatientID = formData.PatientID;

                if (formData.DoctorId != 0)
                    data.DoctorId = formData.DoctorId;

                db.FormDatas.Add(data);

                db.SaveChanges();
            }
            return Json(new { Id = data.Id });

            //return RedirectToAction("ViewEdit" , new { Id = data.Id });
        }

        [HttpPost()]
        public JsonResult UpdateData(FormDataModel formData)
        {
            string[] dateArray = formData.Date.Split(new char[] { '/' });
            DateTime? date = null;

            if (dateArray.Length == 3)
            {
                date = new DateTime(Convert.ToInt32(dateArray[2]), Convert.ToInt32(dateArray[0]), Convert.ToInt32(dateArray[1]));
            }

            FormData data;
            using (var db = new DotNetFormBuilderEntities())
            {
                data = db.FormDatas.Where(d => d.Id == formData.Id).FirstOrDefault();

                data.DataJSON = formData.DataJSON;
                data.PatientID = formData.PatientID;
                data.DoctorId = formData.DoctorId;
                data.AppointmentID = formData.AppointmentID;
                data.Date = string.IsNullOrEmpty(formData.Date) ? (DateTime?)null : date;
                data.UpdatedDate = DateTime.Now;


                db.SaveChanges();
            }
            return Json(new { Id = data.Id });
        }

        [HttpPost()]
        public JsonResult SaveForm(FormInfo formInfoModel)
        {
            FormInfo forminfo;
            using (var db = new DotNetFormBuilderEntities())
            {
                forminfo = new FormInfo()
                {
                    FormName = formInfoModel.FormName,
                    FormTitle = formInfoModel.FormTitle,
                    FormType = formInfoModel.FormType,
                    FormJSON = formInfoModel.FormJSON,
                    IsUse = formInfoModel.IsUse
                };

                db.FormInfoes.Add(forminfo);

                try
                {
                    db.SaveChanges();

                    return Json(new { Id = forminfo.Id });
                }
                catch(Exception ex)
                {
                    return Json(null);
                }
            }
        }

        [HttpPost()]
        public JsonResult UpdateForm(FormInfo formInfoModel)
        {
            using (var db = new DotNetFormBuilderEntities())
            {
                var forminfo = db.FormInfoes.Where(f => f.Id == formInfoModel.Id).FirstOrDefault();

                forminfo.FormName = formInfoModel.FormName;
                forminfo.FormTitle = formInfoModel.FormTitle;
                forminfo.FormType = formInfoModel.FormType;
                forminfo.FormJSON = formInfoModel.FormJSON;
                forminfo.IsUse = formInfoModel.IsUse;

                db.SaveChanges();
            }
            return Json("Ok");
        }

        [HttpGet()]
        public JsonResult GetColumnList(int? FormId)
        {
            FormInfo forminfo;
            using (var db = new DotNetFormBuilderEntities())
            {
                forminfo = db.FormInfoes.Where(f => f.Id == FormId).FirstOrDefault();

            }

            var jsonData = JObject.Parse(forminfo.FormJSON);
            var items = jsonData["components"] as JArray;
            List<ComponentInfo> itemInfoList = GenerateComponentList(items);

            FormDataModelSort formDataModel = new FormDataModelSort();
            formDataModel.DataHeader = itemInfoList;
            formDataModel.PageSize = PageSize;
            formDataModel.FormType = forminfo.FormType;


            return Json(formDataModel, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Ajax call for Data Grid
        /// </summary>
        /// <param name="FormId"></param>
        /// <param name="Key"></param>
        /// <param name="Order"></param>
        /// <param name="FilterKey"></param>
        /// <param name="FilterData"></param>
        /// <param name="PageNumber"></param>
        /// <param name="PageStartIndex"></param>
        /// <param name="PageEndIndex"></param>
        /// <param name="PatientId"></param>
        /// <returns></returns>
        [HttpPost()]
        public ActionResult GetDataGridData(int? FormId, string Key, string Order, string FilterKey = "", string FilterData = "", int? PageNumber=0, int? PatientId = null)
        {
            int totalRecordCount = 0;

            FormInfo forminfo;
            List<FormData> dataItemList = new List<FormData>();
            using (var db = new DotNetFormBuilderEntities())
            {
                forminfo = db.FormInfoes.Where(f => f.Id == FormId).FirstOrDefault();

                if(PatientId == null || PatientId == 0)
                {
                    dataItemList = db.FormDatas.Include("Patient").Include("Doctor").Where(f => f.FormId == FormId && f.IsDeleted == null).ToList();
                }
                else
                {
                    dataItemList = db.FormDatas.Include("Patient").Include("Doctor").Where(f => f.FormId == FormId && f.PatientID == PatientId && f.IsDeleted == null).ToList();
                }


            }

            ViewBag.TotalRecord = dataItemList.Count;

            //totalRecordCount = dataItemList.Count;

            //if (PageNumber != 0)
            //{
            //    if (PageNumber == 1)
            //    {
            //        dataItemList = dataItemList.Skip(0)    // Start at appropriate index
            //                    .Take(PageSize).ToList();
            //    }
            //    else
            //    {
            //        dataItemList = dataItemList.Skip(((int)PageNumber - 1) * PageSize)    // Start at appropriate index
            //                    .Take(PageSize).ToList();
            //    }
            //}

            var jsonData = JObject.Parse(forminfo.FormJSON);
            var items = jsonData["components"] as JArray;
            List<ComponentInfo> itemInfoList = GenerateComponentList(items);

            List<FormBodyDataModel> dataRowList = FormSortData(itemInfoList, dataItemList, Key, Order, FilterKey , FilterData);

            totalRecordCount = dataRowList.Count;

            if (PageNumber != 0)
            {
                if (PageNumber == 1)
                {
                    dataRowList = dataRowList.Skip(0)    // Start at appropriate index
                                .Take(PageSize).ToList();
                }
                else
                {
                    dataRowList = dataRowList.Skip(((int)PageNumber - 1) * PageSize)    // Start at appropriate index
                                .Take(PageSize).ToList();
                }
            }


            List<PageModel> PageList = new List<PageModel>();
            int count = 0;
            int PageStart = 0;
            int PageEnd = 0;

            

            if (PageSize > 0)
            {
                for (int i = PageSize; i <= totalRecordCount; i += PageSize)
                {
                    PageEnd = i - 1;
                    if (count == 0)
                    {
                        PageList.Add(new PageModel() { PageNumber = ++count, PageStart = 0, PageEnd = (int) PageEnd, isDisplay = true });
                    }
                    else
                    {
                        PageList.Add(new PageModel() { PageNumber = ++count, PageStart = (int) PageStart, PageEnd = (int) PageEnd, isDisplay = true });
                    }
                    PageStart = PageEnd + 1;
                }
                if ((totalRecordCount % PageSize) > 0)
                {
                    PageList.Add(new PageModel() { PageNumber = ++count, PageStart = (int) PageStart, PageEnd = totalRecordCount - 1, isDisplay = true });
                }
            }

            

            FormDataModelSort formDataModel = new FormDataModelSort();
            formDataModel.DataHeader = itemInfoList;
            formDataModel.DataBody = dataRowList;
            formDataModel.Pages = PageList;
            formDataModel.PageSize = PageSize;
            formDataModel.FormType = forminfo.FormType;

            ViewBag.FormId = FormId;
            ViewBag.SelectedPageNumber = PageNumber;

            //return Json(formDataModel);

            return View("~/Views/FormBuilder/GetDataGridData.cshtml", formDataModel);
        }

        private List<FormBodyDataModel> FormSortData(List<ComponentInfo> itemInfoList, IEnumerable<FormData> dataItemList, string SortKey, string Order, string FilterKey,
            string FilterData)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileSettingsModel fileSettingsModel = new FileSettingsModel();
            int index = 1;
            List<FormBodyDataModel> formBodyDataModelList = new List<FormBodyDataModel>();
            List<FormBodyDataDetailsModel> formBodyDataDetailsModelList = null; ;
            FormBodyDataModel formBodyDataModel = null;
            FormBodyDataDetailsModel formBodyDataDetailsModel = null;

            foreach (FormData item in dataItemList)
            {
                formBodyDataModel = new FormBodyDataModel();
                formBodyDataDetailsModelList = new List<FormBodyDataDetailsModel>();

                formBodyDataModel.id = item.Id; // index++;
                formBodyDataModel.isDisplay = true;
                formBodyDataModel.dataItemId = (int)item.FormId;

                if (item.PatientID != null)
                    formBodyDataModel.patientName = item.Patient.Name;
                else
                    formBodyDataModel.patientName = "";

                if (item.DoctorId != null)
                    formBodyDataModel.doctorName = item.Doctor.Name;
                else
                    formBodyDataModel.doctorName = "";


                formBodyDataModel.AppointmentID = item.AppointmentID;
                formBodyDataModel.Date = item.Date != null ? item.Date.Value.Month + "/" + item.Date.Value.Day + "/" + item.Date.Value.Year : "";
                formBodyDataModel.IsDeleted = item.IsDeleted;
                formBodyDataModel.Deletedby = item.Deletedby;
                formBodyDataModel.Deleteddate = item.Deleteddate != null ? item.Deleteddate.Value.Month + "/" + item.Deleteddate.Value.Day + "/" + item.Deleteddate.Value.Year : "";
                formBodyDataModel.UpdatedBy = item.UpdatedBy;
                formBodyDataModel.UpdatedDate = item.UpdatedDate != null ? item.UpdatedDate.Value.Month + "/" + item.UpdatedDate.Value.Day + "/" + item.UpdatedDate.Value.Year : "";
                formBodyDataModel.CreatedBy = item.CreatedBy;
                formBodyDataModel.CreateDate = item.CreateDate != null ? item.CreateDate.Value.Month + "/" + item.CreateDate.Value.Day + "/" + item.CreateDate.Value.Year : "";

                formBodyDataDetailsModelList.Clear();
                var dataJson = JObject.Parse(item.DataJSON);

                var data = dataJson["data"] as JObject;

                foreach (ComponentInfo com in itemInfoList)
                {
                    string value = "" + data[com.key];

                    formBodyDataDetailsModel = new FormBodyDataDetailsModel();
                    formBodyDataDetailsModel.id = index++;
                    formBodyDataDetailsModel.value = value;
                    formBodyDataDetailsModel.comtype = com.type;
                    formBodyDataDetailsModel.ItemId = (int)item.FormId;
                    formBodyDataDetailsModel.key = com.key;

                    if (com.type == "datetime")
                    {
                        formBodyDataDetailsModel.dataformat = com.dataformat;
                    }
                    if (com.type == "file")
                    {
                        //fileSettingsViewModel = new FileSettingsViewModel();
                        //if (filecount == 1)
                        //{
                        //    stream = new MemoryStream(item.File1Info, true);
                        //    fileSettingsModel = (FileSettingsModel)formatter.Deserialize(stream);

                        //    fileSettingsViewModel.Id = filecount;
                        //    fileSettingsViewModel.download = (fileSettingsModel.Download == null || fileSettingsModel.Download == false) ? false : true;
                        //    fileSettingsViewModel.addLink = (fileSettingsModel.AddLink == null || fileSettingsModel.AddLink == false) ? false : true;
                        //    fileSettingsViewModel.linkUrl = fileSettingsModel.LinkUrl == null ? "" : fileSettingsModel.LinkUrl;
                        //    fileSettingsViewModel.imageUrl = fileSettingsModel.ImageUrl == null ? "" : fileSettingsModel.ImageUrl;
                        //    fileSettingsViewModel.imageName = (fileSettingsModel.ImageName != null) ? fileSettingsModel.ImageName : ""; // fileSettingsModel.ImageName;
                        //    fileSettingsViewModel.fileType = (fileSettingsModel.FileType != null) ? fileSettingsModel.FileType : ""; // fileSettingsModel.FileType;
                        //    fileSettingsViewModel.key = com.key;

                        //    formBodyDataDetailsModel.ImageNo = filecount;
                        //    formBodyDataDetailsModel.isImage = true;
                        //    formBodyDataDetailsModel.ImageName = fileSettingsModel.ImageName;
                        //    formBodyDataDetailsModel.FileSettingsViewModel = fileSettingsViewModel;

                        //    filecount++;
                        //}

                        var files = data[com.key] as JArray;

                        if (files != null)
                        {
                            foreach (var file in files)
                            {
                                formBodyDataDetailsModel.fileName = file["name"].ToString();
                                formBodyDataDetailsModel.fileBase64 = file["url"].ToString();

                            }
                        }
                    }
                    else
                    {
                        formBodyDataDetailsModel.isImage = false;
                        formBodyDataDetailsModel.fileName = "";
                        formBodyDataDetailsModel.fileBase64 = "";
                    }

                    formBodyDataDetailsModelList.Add(formBodyDataDetailsModel);
                }
                formBodyDataModel.DataDetailsList = formBodyDataDetailsModelList;

                formBodyDataModelList.Add(formBodyDataModel);
            }

            List<FormBodyDataModel> sortList = new List<FormBodyDataModel>();
            if (Order == "first")
            {
                sortList = formBodyDataModelList.OrderByDescending(d => d.Date).ThenByDescending(d => d.id).ToList();
            }
            else if (Order == "asc")
            {

                if (SortKey == "PatientName")
                {
                    sortList = formBodyDataModelList.OrderBy(o => o.patientName).ToList();
                }
                else if (SortKey == "DoctorName")
                {
                    sortList = formBodyDataModelList.OrderBy(o => o.doctorName).ToList();
                }
                else if (SortKey == "Id")
                {
                    sortList = formBodyDataModelList.OrderBy(o => o.id).ToList();
                }
                else if (SortKey == "SystemDate")
                {
                    sortList = formBodyDataModelList.OrderBy(o => o.Date).ToList();
                }
                else
                {
                    sortList = formBodyDataModelList.OrderBy(o => o.DataDetailsList.First(d => d.key == SortKey).value).ToList();
                }
            }
            else if (Order == "desc")
            {
                if (SortKey == "PatientName")
                {
                    sortList = formBodyDataModelList.OrderByDescending(o => o.patientName).ToList();
                }
                else if (SortKey == "DoctorName")
                {
                    sortList = formBodyDataModelList.OrderByDescending(o => o.doctorName).ToList();
                }
                else if (SortKey == "Id")
                {
                    sortList = formBodyDataModelList.OrderByDescending(o => o.id).ToList();
                }
                else if (SortKey == "SystemDate")
                {
                    sortList = formBodyDataModelList.OrderByDescending(o => o.Date).ToList();
                }
                else
                {
                    sortList = formBodyDataModelList.OrderByDescending(o => o.DataDetailsList.First(d => d.key == SortKey).value).ToList();
                }
            }

            if (FilterKey != "")
            {
                if (FilterKey == "PatientName")
                {
                    //sortList = formBodyDataModelList.OrderByDescending(o => o.patientName).ToList();
                    sortList = sortList.Where(f => f.patientName.ToLower().Contains(FilterData.ToLower())).ToList();
                }
                else if (FilterKey == "DoctorName")
                {
                    //sortList = formBodyDataModelList.OrderByDescending(o => o.doctorName).ToList();
                    sortList = sortList.Where(f => f.doctorName.ToLower().Contains(FilterData.ToLower())).ToList();
                }
                else if (FilterKey == "Id")
                {
                    //sortList = formBodyDataModelList.OrderByDescending(o => o.id).ToList();
                    sortList = sortList.Where(f => f.id.ToString().ToLower().Contains(FilterData.ToLower())).ToList();
                }
                else if (FilterKey == "SystemDate")
                {
                    //sortList = formBodyDataModelList.OrderByDescending(o => o.Date).ToList();
                    sortList = sortList.Where(f => f.Date.ToLower().Contains(FilterData.ToLower())).ToList();
                }
                else
                {
                    //sortList = formBodyDataModelList.OrderByDescending(o => o.DataDetailsList.First(d => d.key == SortKey).value).ToList();
                    sortList = sortList.Where(f => f.DataDetailsList.Where(g => g.key == FilterKey && g.value.ToLower().Contains(FilterData.ToLower())).Count() > 0).ToList();
                }
            }

            return sortList;

        }
        /// <summary>
        /// Ajax call for Form Grid
        /// </summary>
        /// <param name="Key"></param>
        /// <param name="Order"></param>
        /// <param name="FilterKey"></param>
        /// <param name="FilterData"></param>
        /// <param name="PageNumber"></param>
        /// <returns></returns>
        [HttpPost()]
        public ActionResult GetFormGridData(string Key, string Order, string FilterKey = "", string FilterData = "", int? PageNumber = 0, int? PatientId = 0, string TableName = "")
        {
            int totalRecordCount = 0;

            List<FormInfo> formInfoList = new List<FormInfo>();
            using (var db = new DotNetFormBuilderEntities())
            {
                db.Configuration.LazyLoadingEnabled = false;

                if(PatientId != 0)
                {
                    formInfoList = db.FormDatas.Include("FormInfo").Where(d => d.PatientID == PatientId && d.FormInfo.IsDeleted != true)
                    .Select(d => d.FormInfo).Distinct().ToList();
                }
                else
                {
                    formInfoList = db.FormInfoes.Where(d => d.IsDeleted != true).ToList();
                }
            }

            ViewBag.TotalRecord = formInfoList.Count;

            //totalRecordCount = formInfoList.Count;

            //if (PageNumber != 0)
            //{
            //    if (PageNumber == 1)
            //    {
            //        formInfoList = formInfoList.Skip(0)    // Start at appropriate index
            //                    .Take(PageSize).ToList();
            //    }
            //    else
            //    {
            //        formInfoList = formInfoList.Skip(((int)PageNumber - 1) * PageSize)    // Start at appropriate index
            //                    .Take(PageSize).ToList();
            //    }
            //}


            formInfoList = FormGridSortData(formInfoList, Key, Order, FilterKey, FilterData);

            totalRecordCount = formInfoList.Count;

            if (PageNumber != 0)
            {
                if (PageNumber == 1)
                {
                    formInfoList = formInfoList.Skip(0)    // Start at appropriate index
                                .Take(PageSize).ToList();
                }
                else
                {
                    formInfoList = formInfoList.Skip(((int)PageNumber - 1) * PageSize)    // Start at appropriate index
                                .Take(PageSize).ToList();
                }
            }


            List<PageModel> PageList = new List<PageModel>();
            int count = 0;
            int PageStart = 0;
            int PageEnd = 0;


            if (PageSize > 0)
            {
                for (int i = PageSize; i <= totalRecordCount; i += PageSize)
                {
                    PageEnd = i - 1;
                    if (count == 0)
                    {
                        PageList.Add(new PageModel() { PageNumber = ++count, PageStart = 0, PageEnd = (int)PageEnd, isDisplay = true });
                    }
                    else
                    {
                        PageList.Add(new PageModel() { PageNumber = ++count, PageStart = (int)PageStart, PageEnd = (int)PageEnd, isDisplay = true });
                    }
                    PageStart = PageEnd + 1;
                }
                if ((totalRecordCount % PageSize) > 0)
                {
                    PageList.Add(new PageModel() { PageNumber = ++count, PageStart = (int)PageStart, PageEnd = totalRecordCount - 1, isDisplay = true });
                }
            }

            //if (PageNumber != 0)
            //{
            //    if (PageNumber == 1)
            //    {
            //        formInfoList = formInfoList.Skip(0)    // Start at appropriate index
            //                    .Take(PageSize).ToList();
            //    }
            //    else
            //    {
            //        formInfoList = formInfoList.Skip(((int)PageNumber - 1) * PageSize)    // Start at appropriate index
            //                    .Take(PageSize).ToList();
            //    }
            //}

            FormGridModelSort formDataModel = new FormGridModelSort();
            formDataModel.DataBody = formInfoList;
            formDataModel.Pages = PageList;
            formDataModel.PageSize = PageSize;

            ViewBag.TableName = TableName;
            ViewBag.SelectedPageNumber = PageNumber;
            ViewBag.PatientId = PatientId;

            //return Json(formDataModel);

            return View("~/Views/FormBuilder/GetFormGridData.cshtml", formDataModel);
        }

        private List<FormInfo> FormGridSortData(List<FormInfo> formInfoList, string SortKey, string Order, string FilterKey, string FilterData)
        {
            //if(Order == "")
            //{
            //    Order = "asc";
            //}

            if (Order == "first")
            {
                formInfoList = formInfoList.OrderBy(o => o.FormName).ToList();
            }
            else if (Order == "asc")
            {

                if (SortKey == "Id")
                {
                    formInfoList = formInfoList.OrderBy(o => o.Id).ToList();
                }
                else if (SortKey == "FormName")
                {
                    formInfoList = formInfoList.OrderBy(o => o.FormName).ToList();
                }
                else if (SortKey == "FormTitle")
                {
                    formInfoList = formInfoList.OrderBy(o => o.FormTitle).ToList();
                }
                else if (SortKey == "FormType")
                {
                    formInfoList = formInfoList.OrderBy(o => o.FormType).ToList();
                }
            }
            else if (Order == "desc")
            {
                if (SortKey == "Id")
                {
                    formInfoList = formInfoList.OrderByDescending(o => o.Id).ToList();
                }
                else if (SortKey == "FormName")
                {
                    formInfoList = formInfoList.OrderByDescending(o => o.FormName).ToList();
                }
                else if (SortKey == "FormTitle")
                {
                    formInfoList = formInfoList.OrderByDescending(o => o.FormTitle).ToList();
                }
                else if (SortKey == "FormType")
                {
                    formInfoList = formInfoList.OrderByDescending(o => o.FormType).ToList();
                }
            }

            if (FilterKey != "")
            {
                if (FilterKey == "Id")
                {
                    formInfoList = formInfoList.Where(f => f.Id.ToString().ToLower().Contains(FilterData.ToLower())).ToList();
                }
                else if (FilterKey == "FormName")
                {
                    formInfoList = formInfoList.Where(f => f.FormName.ToLower().Contains(FilterData.ToLower())).ToList();
                }
                else if (FilterKey == "FormTitle")
                {
                    formInfoList = formInfoList.Where(f => f.FormTitle.ToLower().Contains(FilterData.ToLower())).ToList();
                }
                else if (FilterKey == "FormType")
                {
                    formInfoList = formInfoList.Where(f => f.FormType.ToLower().Contains(FilterData.ToLower())).ToList();
                }
            }




            //if (SortKey != "")
            //{
            //    if (SortKey == "Id")
            //    {
            //        if (FilterKey == "")
            //        {
            //            if (Order == "asc")
            //                formInfoList = formInfoList.OrderBy(o => o.Id).ToList();
            //            else
            //                formInfoList = formInfoList.OrderByDescending(o => o.Id).ToList();
            //        }
            //        else
            //        {
            //            if (Order == "asc")
            //            {
            //                formInfoList = formInfoList.OrderBy(o => o.Id).ToList();
            //                formInfoList = formInfoList.Where(f => f.Id.ToString().ToLower().Contains(FilterData.ToLower())).ToList();
            //            }
            //            else
            //            {
            //                formInfoList = formInfoList.OrderByDescending(o => o.Id).ToList();
            //                formInfoList = formInfoList.Where(f => f.Id.ToString().ToLower().Contains(FilterData.ToLower())).ToList();
            //            }
            //        }
            //    }
            //    else if (SortKey == "FormName")
            //    {
            //        if (FilterKey == "")
            //        {
            //            if (Order == "asc")
            //                formInfoList = formInfoList.OrderBy(o => o.FormName).ToList();
            //            else
            //                formInfoList = formInfoList.OrderByDescending(o => o.FormName).ToList();
            //        }
            //        else
            //        {
            //            if (Order == "asc")
            //            {
            //                formInfoList = formInfoList.OrderBy(o => o.FormName).ToList();
            //                formInfoList = formInfoList.Where(f => f.FormName.ToLower().Contains(FilterData.ToLower())).ToList();
            //            }
            //            else
            //            {
            //                formInfoList = formInfoList.OrderByDescending(o => o.FormName).ToList();
            //                formInfoList = formInfoList.Where(f => f.FormName.ToLower().Contains(FilterData.ToLower())).ToList();
            //            }
            //        }
            //    }
            //    else if (SortKey == "FormTitle")
            //    {
            //        if (FilterKey == "")
            //        {
            //            if (Order == "asc")
            //                formInfoList = formInfoList.OrderBy(o => o.FormTitle).ToList();
            //            else
            //                formInfoList = formInfoList.OrderByDescending(o => o.FormTitle).ToList();
            //        }
            //        else
            //        {
            //            if (Order == "asc")
            //            {
            //                formInfoList = formInfoList.OrderBy(o => o.FormTitle).ToList();
            //                formInfoList = formInfoList.Where(f => f.FormTitle.ToLower().Contains(FilterData.ToLower())).ToList();
            //            }
            //            else
            //            {
            //                formInfoList = formInfoList.OrderByDescending(o => o.FormTitle).ToList();
            //                formInfoList = formInfoList.Where(f => f.FormTitle.ToLower().Contains(FilterData.ToLower())).ToList();
            //            }
            //        }

            //    }
            //    else if (SortKey == "FormType")
            //    {
            //        if (FilterKey == "")
            //        {
            //            if (Order == "asc")
            //                formInfoList = formInfoList.OrderBy(o => o.FormType).ToList();
            //            else
            //                formInfoList = formInfoList.OrderByDescending(o => o.FormType).ToList();
            //        }
            //        else
            //        {
            //            if (Order == "asc")
            //            {
            //                formInfoList = formInfoList.OrderBy(o => o.FormType).ToList();
            //                formInfoList = formInfoList.Where(f => f.FormType.ToLower().Contains(FilterData.ToLower())).ToList();
            //            }
            //            else
            //            {
            //                formInfoList = formInfoList.OrderByDescending(o => o.FormType).ToList();
            //                formInfoList = formInfoList.Where(f => f.FormType.ToLower().Contains(FilterData.ToLower())).ToList();
            //            }
            //        }

            //    }
            //}
            //else if(FilterKey != "")
            //{
            //    if (FilterKey == "FormName")
            //    {
            //        formInfoList = formInfoList.Where(f => f.FormName.ToLower().Contains(FilterData.ToLower())).ToList();
            //    }
            //    else if (FilterKey == "FormTitle")
            //    {
            //        formInfoList = formInfoList.Where(f => f.FormTitle.ToLower().Contains(FilterData.ToLower())).ToList();

            //    }
            //    else if (FilterKey == "FormType")
            //    {
            //        formInfoList = formInfoList.Where(f => f.FormType.ToLower().Contains(FilterData.ToLower())).ToList();
            //    }
            //}
            //else
            //{
            //    if (FilterKey == "")
            //    {
            //        formInfoList = formInfoList.OrderBy(o => o.FormName).ToList();
            //    }
            //    else
            //    {
            //        formInfoList = formInfoList.OrderBy(o => o.FormName).ToList();
            //        formInfoList = formInfoList.Where(f => f.FormName.ToLower().Contains(FilterData.ToLower())).ToList();
            //    }
            //}

            return formInfoList;
        }

        private List<ComponentInfo> GenerateComponentList(JArray items)
        {
            int count = 1;
            List<ComponentInfo> itemInfoList = new List<ComponentInfo>();
            ComponentInfo componentInfo = null;
            string type = "";
            string panelType = "";

            foreach (var itemcom in items)
            {
                type = itemcom["type"].ToString();

                if (type == "panel")
                {
                    var panelComponents = itemcom["components"] as JArray;
                    foreach (var panelComponent in panelComponents)
                    {
                        panelType = panelComponent["type"].ToString();

                        SearchComponentList(itemInfoList, panelComponent as JToken, panelType, componentInfo, ref count);
                    }
                }
                else
                {
                    SearchComponentList(itemInfoList, itemcom as JToken, type, componentInfo, ref count);
                }

            }
            return itemInfoList;
        }

        private void SearchComponentList(List<ComponentInfo> itemInfoList, JToken itemcom, string type,
            ComponentInfo componentInfo, ref int count)
        {
            if (type == "columns")
            {
                var columnsComponents = itemcom["columns"] as JArray;
                foreach (var columnComponent in columnsComponents)
                {
                    var innerComponents = columnComponent["components"] as JArray;

                    foreach (var com in innerComponents)
                    {
                        componentInfo = new ComponentInfo();

                        componentInfo.id = count++;
                        componentInfo.label = com["label"].ToString();
                        componentInfo.key = com["key"].ToString();
                        componentInfo.type = com["type"].ToString();

                        if (componentInfo.type == "datetime")
                            componentInfo.dataformat = com["format"].ToString();

                        if (componentInfo.type != "button" && componentInfo.type != "ClearSubmit")
                            itemInfoList.Add(componentInfo);
                    }
                }
            }
            else if (type == "fieldset")
            {
                var innerComponents = itemcom["components"] as JArray;

                foreach (var com in innerComponents)
                {
                    componentInfo = new ComponentInfo();

                    componentInfo.id = count++;
                    componentInfo.label = com["label"].ToString();
                    componentInfo.key = com["key"].ToString();
                    componentInfo.type = com["type"].ToString();

                    if (componentInfo.type == "datetime")
                        componentInfo.dataformat = com["format"].ToString();

                    if (componentInfo.type != "button" && componentInfo.type != "ClearSubmit")
                        itemInfoList.Add(componentInfo);
                }
            }
            else
            {
                componentInfo = new ComponentInfo();

                componentInfo.id = count++;
                componentInfo.label = itemcom["label"].ToString();
                componentInfo.key = itemcom["key"].ToString();
                componentInfo.type = itemcom["type"].ToString();

                //if (componentInfo.type == "datetime")
                //    componentInfo.dataformat = itemcom["format"].ToString();

                if (componentInfo.type != "button" && componentInfo.type != "ClearSubmit")
                    itemInfoList.Add(componentInfo);
            }
        }

        

        //[HttpPost()]
        //public JsonResult SaveForm(int Id, string FormName, string FormTitle, string FormType, string FormJSON, bool IsUse)
        //{
        //    return Json("Ok");
        //}

        //[HttpPost()]
        //public JsonResult SaveForm(FormCollection collection)
        //{
        //    return Json("Ok");
        //}

        //[HttpPost()]
        //public JsonResult SaveForm(int? Id)
        //{
        //    return Json("Ok");
        //}

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}