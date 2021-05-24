$(document).ready(function () {
    //alert("ok");




});

var selectedkey, selectedtype, selectedformId = 0, selectedelement, selectedevent;
var sortkey = "", sorttype = "", sortorder = "", sortelement = null;
var filterkey = "", filtertype = "", filterdata = "";
var selectedPageNumber = 1;
var totalPageCount = 0;

var selectedPatientId = 0;

var tablename = "";

var datagridHideColumn = [];
var displayColumnNumber = 5;
var datagridColumn = [];
var presslock = false;

//var isColumnBind = false;

function BindForm() {
    var jsonElement = document.getElementById('json');
    var formElement = document.getElementById('formio');
    var subJSON = document.getElementById('subjson');

    var formtype = $("#formtype").val();

    builder = new Formio.FormBuilder(document.getElementById("builder"), {
        display: formtype,
        components: [],
        settings: {
            pdf: {
                "id": "1ec0f8ee-6685-5d98-a847-26f67b67d6f0",
                "src": "https://files.form.io/pdf/5692b91fd1028f01000407e3/file/1ec0f8ee-6685-5d98-a847-26f67b67d6f0"
            }
        }
    }, {
        baseUrl: 'https://examples.form.io'
    });



    var onForm = function (form) {
        form.on('change', function () {
            //subJSON.innerHTML = '';
            //subJSON.appendChild(document.createTextNode(JSON.stringify(form.submission, null, 4)));
        });
    };

    //var onBuild = function (build) {
    //    //jsonElement.innerHTML = '';
    //    //formElement.innerHTML = '';
    //    //jsonElement.appendChild(document.createTextNode(JSON.stringify(builder.instance.schema, null, 4)));

    //    console.log(builder.instance.form);

    //    Formio.createForm(formElement, builder.instance.form).then(onForm);
    //};

    var onReady = function () {
        //var jsonElement = document.getElementById('json');
        //var formElement = document.getElementById('formio');
        //builder.instance.on('change', onBuild);
    };

    //var setDisplay = function (display) {
    //    builder.setDisplay(display).then(onReady);
    //};

    //// Handle the form selection.
    //var formSelect = document.getElementById('form-select');
    //formSelect.addEventListener("change", function () {
    //    setDisplay(this.value);
    //});

    builder.instance.ready.then(onReady);

    ///////////////////////////////////////////////////////////////////////////////////////

    var onForm = function (form) {
        form.on('change', function () {
            //subJSON.innerHTML = '';
            //subJSON.appendChild(document.createTextNode(JSON.stringify(form.submission, null, 4)));
        });
    };

}

function ChangeFormType() {
    var formtype = $("#formtype").val();
    //lert(formtype);

    BindForm();
}

function EditForm(Id, FormName, FormTitle, FormType, IsUse, FormJSON) {
    var jsonElement = document.getElementById('json');
    var formElement = document.getElementById('formio');
    var subJSON = document.getElementById('subjson');

    $("#title").val(FormTitle);
    $("#name").val(FormName);
    $("#formtype").val(FormType);


    console.log(FormJSON);

    FormJSON = htmlDecode(FormJSON);

    FormJSON = FormJSON.replaceAll('">', '\\">');
    FormJSON = FormJSON.replaceAll('class="table', 'class=\\"table');
    FormJSON = FormJSON.replaceAll('style="', 'style=\\"');

    //FormJSON = FormJSON.replaceAll('">', '\\">');
    //FormJSON = FormJSON.replaceAll('class="table"', 'class=\\"table\\"');
    //FormJSON = FormJSON.replaceAll('style="', 'style=\\"');
    

    console.log(FormJSON);


    //var formString = FormJSON.replace(/&quot;/g, '"');

    //console.log(formString);

    var dataToServer = JSON.stringify({ html: FormJSON });
    var dataFromServer = JSON.parse(dataToServer);

    var formObj = JSON.parse(dataFromServer.html);

    console.log(formObj);

    builder = new Formio.FormBuilder(document.getElementById("builder"), {
        display: FormType,
        components: formObj.components,
        settings: {
            pdf: {
                "id": "1ec0f8ee-6685-5d98-a847-26f67b67d6f0",
                "src": "https://files.form.io/pdf/5692b91fd1028f01000407e3/file/1ec0f8ee-6685-5d98-a847-26f67b67d6f0"
            }
        }
    }, {
        baseUrl: 'https://examples.form.io'
    });



    var onForm = function (form) {
        form.on('change', function () {
            //subJSON.innerHTML = '';
            //subJSON.appendChild(document.createTextNode(JSON.stringify(form.submission, null, 4)));
        });
    };

    var onBuild = function (build) {
        //jsonElement.innerHTML = '';
        //formElement.innerHTML = '';
        //jsonElement.appendChild(document.createTextNode(JSON.stringify(builder.instance.schema, null, 4)));
        Formio.createForm(formElement, builder.instance.form).then(onForm);
    };

    var onReady = function () {
        //var jsonElement = document.getElementById('json');
        //var formElement = document.getElementById('formio');
        builder.instance.on('change', onBuild);
    };

    var setDisplay = function (display) {
        builder.setDisplay(display).then(onReady);
    };

    //// Handle the form selection.
    //var formSelect = document.getElementById('form-select');
    //formSelect.addEventListener("change", function () {
    //    setDisplay(this.value);
    //});

    builder.instance.ready.then(onReady);

    ///////////////////////////////////////////////////////////////////////////////////////


    //$.ajax({
    //    type: "GET",
    //    url: "/FormBuilderTest/GetForm",
    //    contentType: "application/json; charset=utf-8",
    //    dataType: "json",

    //    success: function (response) {
    //        alert(response.Components)

    //        Formio.createForm(document.getElementById('formio'), {
    //            components: [response]
    //        }).then(function (form) {
    //            //form.submission = {
    //            //    data: data1
    //            //};
    //        });


    //    }, timeout: 30000

    //});



    //var comp = JSON.parse(JSON.stringify(document.getElementById("component").value));
    //alert(comp);

    //window.onload = function () {
    //    Formio.icons = 'fontawesome';
    //    Formio.createForm(document.getElementById('formio'), comp).then(onForm);
    //};


    var onForm = function (form) {
        form.on('change', function () {
            //subJSON.innerHTML = '';
            //subJSON.appendChild(document.createTextNode(JSON.stringify(form.submission, null, 4)));
        });
    };




    //var data1 = JSON.parse(JSON.stringify(document.getElementById("data").value));

    //alert(comp);
    //alert(data1);

    //Formio.createForm(document.getElementById('formio'), {
    //    components:[ comp]
    //}).then(function (form) {
    //    //form.submission = {
    //    //    data: data1
    //    //};
    //});


    //Formio.createForm(document.getElementById('formio'), {
    //    components: [
    //      {
    //          type: 'textfield',
    //          key: 'firstName',
    //          label: 'First Name',
    //          placeholder: 'Enter your first name.',
    //          input: true
    //      },
    //      {
    //          type: 'textfield',
    //          key: 'lastName',
    //          label: 'Last Name',
    //          placeholder: 'Enter your last name',
    //          input: true
    //      },
    //      {
    //          type: 'button',
    //          action: 'submit',
    //          label: 'Submit',
    //          theme: 'primary'
    //      }
    //    ]
    //}).then(function (form) {
    //    //form.submission = {
    //    //    data: {
    //    //        firstName: 'Joe',
    //    //        lastName: 'Smith',
    //    //        email: 'joe@example.com'
    //    //    }
    //    //};
    //});
}

function htmlDecode(value) {
    return $('<div/>').html(value).text();
}

function htmlEncode(s) {
    return $("<div/>").text(s).html();
}

function ViewForm(formId, FormJSON) {
    var formElement = document.getElementById('formio');


    console.log(FormJSON);

    console.log(unescape(FormJSON));

    FormJSON = htmlDecode(FormJSON);

    FormJSON = FormJSON.replaceAll('">', '\\">');
    FormJSON = FormJSON.replaceAll('class="table', 'class=\\"table');
    FormJSON = FormJSON.replaceAll('style="', 'style=\\"');

    console.log(FormJSON);

    var formString = FormJSON.replace(/&quot;/g, '"');

    var formObj = JSON.parse(formString);

    console.log(formObj);

    //Formio.createForm(formElement, formObj).then(onForm);

    Formio.createForm(formElement, formObj).then(function (form) {
        // Defaults are provided as follows.
        //form.submission = {
        //    data: {
        //        firstName: 'Joe',
        //        lastName: 'Smith'
        //    }
        //};

        // Register for the submit event to get the completed submission.
        form.on('submit', function (submission) {
            console.log('Submission was made!', submission);

            SaveData(formId, submission);
        });

        // Everytime the form changes, this will fire.
        form.on('change', function (changed) {
            console.log('Form was changed', changed);
        });
    });
}

function ViewImage(DataJSON, Key) {
    var dataString = DataJSON.replace(/&quot;/g, '"');
    var dataObj = JSON.parse(dataString);

    console.log(dataObj);

    dataObj.data[Key].forEach(function (file) {
        //row[columns[j].key] = file.url;
        //console.log(file.url);
        if (file.name.indexOf(".pdf") > 0 || file.name.indexOf(".docx") > 0) {
            $("#viewpdf").attr("data", file.url);
        }
        else {
            $("#viewimage").attr("src", file.url);
        }
    });
}

function jsonEscape(str) {
    return str.replace(/\n/g, "\\\\n").replace(/\r/g, "\\\\r").replace(/\t/g, "\\\\t");
}

function ViewEdit(formId, FormJSON, DataJSON, id, PatientId, DoctorId, AppointmentId, Date) {
    var formElement = document.getElementById('formio');


    console.log(FormJSON);

    //console.log(unescape(FormJSON));

    FormJSON = htmlDecode(FormJSON);

    FormJSON = FormJSON.replaceAll('">', '\\">');
    FormJSON = FormJSON.replaceAll('class="table', 'class=\\"table');
    FormJSON = FormJSON.replaceAll('style="', 'style=\\"');

    //FormJSON = FormJSON.replaceAll('class="table"', 'class=\\"table\\"');
    //FormJSON = FormJSON.replaceAll('style="', 'style=\\"');

    var formString = FormJSON.replace(/&quot;/g, '"');
    var formObj = JSON.parse(formString);

    //var aaa = jsonEscape(DataJSON)
    //DataJSON = htmlDecode(DataJSON);
    //var dataString = DataJSON.replace(/&quot;/g, '"');
    
    //var dataObj = JSON.parse(dataString);

    //console.log(formObj);
    //console.log(dataObj);

    $("#patient").val(PatientId);
    $("#doctor").val(DoctorId);
    $("#appointment").val(AppointmentId);
    $("#entrydate").val(Date);


    //Formio.createForm(formElement, formObj).then(onForm);

    $.ajax({
        type: "GET",
        url: "/FormBuilder/GetFormDataById?id=" + id,
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        contentType: 'application/json; charset=utf-8',

        success: function (response) {
            console.log(response);

            Formio.createForm(formElement, formObj).then(function (form) {

                form.submission = {
                    data: JSON.parse(response.DataJSON).data
                };

                // Register for the submit event to get the completed submission.
                form.on('submit', function (submission) {
                    console.log('Submission was made!', submission);

                    UpdateData(id, formId, submission);
                });

                // Everytime the form changes, this will fire.
                form.on('change', function (changed) {
                    console.log('Form was changed', changed);
                });
            });
        }

    });

    
}

function LoadDataGrid(formId, patientId) {
    //var components = [];
    //var rows = []; // Store row data
    //var row = {};
    //var columns = []; //Store column

    selectedkey = "SystemDate";
    sortorder = "first";
    selectedtype = "";
    selectedformId = formId;
    //selectedelement = element;
    //selectedevent = event;

    selectedPatientId = patientId;

    //isColumnBind = false;

    //tablename = table_name;

    $("#loadingmessage").show();

    GetDataGridData(selectedformId, "SystemDate", sortorder, "", "", 1, selectedPatientId, true);





    //$.ajax({
    //    type: "GET",
    //    url: "/FormBuilder/GetDataGrid?formId=" + formId,
    //    contentType: "application/json; charset=utf-8",
    //    dataType: "json",
    //    contentType: 'application/json; charset=utf-8',

    //    success: function (response) {
    //        console.log(response);


    //        ProcessData(response, ele, formId)

    //        $("#loadingmessage").hide();

    //    }

    //});


}

function LoadFormGrid(table_name) {
    //var components = [];
    //var rows = []; // Store row data
    //var row = {};
    //var columns = []; //Store column

    selectedkey = "FormName";
    sortkey = "FormName";
    sortorder = "first";

    selectedtype = "Custom";
    //selectedformId = formId;

    //selectedelement = element;
    //selectedevent = event;

    tablename = table_name;

    $("#loadingmessage").show();

    //GetFormGridData("FormName", "desc", "", "", 1, 0, table_name);

    GetFormGridData(sortkey, "first", filterkey, filterdata, selectedPageNumber, 0, table_name);

}

function SelectPatient(ele, table_name) { //Called when select Patient Dropdown in Data Filter
    var patientId = $(ele).val();

    selectedPatientId = parseInt(patientId);

    tablename = table_name;

    GetFormGridData("FormName", "desc", "", "", selectedPageNumber, selectedPatientId, tablename);
}


function showfilterPopup(key, type, formId, element, event) {  //When click on Header Sort or Filter

    if (filterkey == key) {
        $(".searchinput").val(filterdata);
    }
    else {
        $(".searchinput").val("");
    }
    selectedkey = key;
    selectedtype = type;
    selectedformId = formId;
    selectedelement = element;
    selectedevent = event;

    tablename = $(element).closest("table").attr("id");



    //$(element).closest(".table-header").find(".filter-popup").find(".searchinput").val("");

    //$(element).closest(".table-header").find(".filter-popup").show();

    $(".filter-popup").show();

    //if (($(element).closest(".table-header").width() + 100) < $(element).closest(".table-header").find(".filter-popup").width()) {
    //    $(element).closest(".table-header").find(".filter-popup").css('left', '0px');
    //}

    var offset = $(element).offset();

    $(".filter-popup").css('left', parseInt(offset.left) + "px");
    $(".filter-popup").css('top', (parseInt(offset.top) + 50) + "px");

    

    
    event.stopPropagation();
};

function clicksortascending(ele, event) {

    if (sorttype != "file") {

        sortkey = selectedkey;
        sorttype = "asc";
        sortelement = selectedelement;
        sortorder = "asc";

        //var patientId = 0;
        //if ($("#patient").length > 0) {
        //    patientId = $("#patient").val();
        //}

        //var element = event.currentTarget;

        if (tablename == "data-grid") {
            GetDataGridData(selectedformId, sortkey, "asc", filterkey, filterdata, selectedPageNumber, selectedPatientId, false);
        }
        else {
            GetFormGridData(sortkey, "asc", filterkey, filterdata, selectedPageNumber, selectedPatientId, tablename);
        }
    }
    //event.stopPropagation();
};

function clicksortdescending(ele, event) {

    if (sorttype != "file") {
        //var element = $event.currentTarget;

        sortkey = selectedkey;
        sorttype = selectedtype;
        //sortformId = selectedformId;
        //sortelement = selectedelement;
        //sortevent = selectedevent;
        sortorder = "desc";

        //var patientId = 0;
        //if ($("#patient").length > 0) {
        //    patientId = $("#patient").val();
        //}




        if (selectedformId != 0) {
            GetDataGridData(selectedformId, sortkey, "desc", filterkey, filterdata, selectedPageNumber, selectedPatientId, false);
        }
        else {
            GetFormGridData(sortkey, "desc", filterkey, filterdata, selectedPageNumber, selectedPatientId, tablename);
        }
    }
    event.stopPropagation();
};

function clicksortclear(ele, event) {
    //sortkey = "";
    //sorttype = "";
    //sortorder = "first";

    //var patientId = 0;
    //if ($("#patient").length > 0) {
    //    patientId = $("#patient").val();
    //}

    if (selectedformId != 0) {
        sortkey = "SystemDate";
        sorttype = "";
        sortorder = "first";

        GetDataGridData(selectedformId, sortkey, "first", filterkey, filterdata, selectedPageNumber, selectedPatientId, false);
    }
    else {
        sortkey = "FormName";
        sorttype = "";
        sortorder = "first";

        GetFormGridData(sortkey, "first", filterkey, filterdata, selectedPageNumber, selectedPatientId, tablename);
    }

    event.stopPropagation();
}

function ClearFilterText(ele, event) {
    filterkey = "";
    filtertype = "";
    filterdata = "";

    $(".searchinput").val("");

    if (tablename == "data-grid") {
        GetDataGridData(selectedformId, sortkey, sortorder, filterkey, filterdata, selectedPageNumber, selectedPatientId, false);
    }
    else {
        GetFormGridData(sortkey, "asc", filterkey, filterdata, selectedPageNumber, selectedPatientId, tablename);
    }

    event.stopPropagation();
};

function clickFilterPopup(ele, event) {  //When click on Filter Popup don't hide it.
    event.stopPropagation();
}

function GetDataGridData(formId, key, order, filterKey, filterData, pageNumber, patientId, isLoad) {
    var dataModel = {
        'FormId': formId, 'Key': key, 'Order': order, 'FilterKey': filterKey, 'FilterData': filterData,
        'PageNumber': pageNumber, "PatientId": patientId
    };

    //if (filter == "clearfilter") {
    //    $(".topFilterInput").val("");
    //    $rootScope.selectedtitle = "";
    //}

    $('#loadingmessage').show();

    $.ajax({
        type: "POST",
        url: "/FormBuilder/GetDataGridData",
        data: JSON.stringify(dataModel),
        contentType: "application/json; charset=utf-8",
        dataType: "html",

        success: function (response) {
            console.log(response);

            $("#data-grid-container").html(response);

            //ProcessSortData(response, $(".table-data"), formId, isLoad);

            $("#loadingmessage").hide();

            $(".table-header").removeClass("header-sorted-asc");
            $(".table-header").removeClass("header-sorted-asc");
            $(".table-header").removeClass("header-filtered");

            if (sortorder == "asc")
                $("." + sortkey + "sort" + ".table-header").addClass("header-sorted-asc");
            else if (sortorder == "desc")
                $("." + sortkey + "sort" + ".table-header").addClass("header-sorted-desc");

            if (filterkey != "" && filterdata != "")
                $("." + filterkey + "sort" + ".table-header").addClass("header-filtered");



            if (isLoad) {
                $.ajax({
                    type: "GET",
                    url: "/FormBuilder/GetColumnList?FormId=" + formId,
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",

                    success: function (response) {
                        console.log(response);

                        datagridColumn = ProcessSortDataGridColumns(response.DataHeader, response.FormType);

                        //Add column to table


                        for (var i = 0; i < datagridColumn.length; i++) {

                            if (i > displayColumnNumber) {
                                datagridHideColumn.push(datagridColumn[i]);
                            }
                        }

                        //ProcessSortData(response, $(".table-data"), formId, isLoad);

                        $(".filter-popup").find(".filter-items div").html("");

                        for (var i = 0; i < datagridColumn.length; i++) {
                            if (datagridHideColumn.findIndex(x => x.key == datagridColumn[i].key) != -1) {
                                $(".filter-popup").find(".filter-items div.container")
                                    .append("<div><input type='checkbox' value='" + datagridColumn[i].key + "' onclick=\"HideAndShowColumn('" + datagridColumn[i].key + "', this, event)\"/>" + datagridColumn[i].label + "</div>");
                            }
                            else {
                                $(".filter-popup").find(".filter-items div.container")
                                    .append("<div><input type='checkbox' checked value='" + datagridColumn[i].key + "' onclick=\"HideAndShowColumn('" + datagridColumn[i].key + "', this, event)\"/>" + datagridColumn[i].label + "</div>");
                            }

                        }

                        datagridHideColumn.forEach(function (col) {
                            $("." + col.key + "sort").hide();
                        });

                        //isColumnBind = true;
                    }

                });
                //$.ajax({
                //    type: "GET",
                //    url: "/FormBuilder/GetColumnList?FormId=" + formId,
                //    contentType: "application/json; charset=utf-8",
                //    dataType: "json",

                //    success: function (response) {
                //        console.log(response);

                //        datagridColumn = ProcessSortDataGridColumns(response.DataHeader, response.FormType);

                //        //Add column to table

                //        for (var i = 0; i < datagridColumn.length; i++) {

                //            if (i > displayColumnNumber) {
                //                datagridHideColumn.push(datagridColumn[i]);
                //            }
                //        }

                //        datagridHideColumn.forEach(function (col) {
                //            $("." + col.key + "sort").hide();
                //        });
                //    }
                //});
            }
            else {
                datagridHideColumn.forEach(function (col) {
                    $("." + col.key + "sort").hide();
                });
            }
            
        }

    });


}



function GetFormGridData(key, order, filterKey, filterData, pageNumber, patientId, table_name) { // For Form Grid Table

    tablename = table_name;

    var dataModel = {
        'Key': key, 'Order': order, 'FilterKey': filterKey, 'FilterData': filterData, 'PageNumber': pageNumber, 'PatientId': patientId, 'TableName': table_name
    };

    //if (filter == "clearfilter") {
    //    $(".topFilterInput").val("");
    //    $rootScope.selectedtitle = "";
    //}

    $('#loadingmessage').show();

    $.ajax({
        type: "POST",
        url: "/FormBuilder/GetFormGridData",
        data: JSON.stringify(dataModel),
        contentType: "application/json; charset=utf-8",
        dataType: "html",

        success: function (response) {
            console.log(response);

            $("#form-list-container").html(response);

            //ProcessFormGridSortData(response, $(".table-form"), patientId);

            $("#loadingmessage").hide();

            $(".table-header").removeClass("header-sorted-asc");
            $(".table-header").removeClass("header-sorted-desc");
            $(".table-header").removeClass("header-filtered");

            if (sortorder == "asc")
                $("." + sortkey + "sort" + ".table-header").addClass("header-sorted-asc");
            else if (sortorder == "desc")
                $("." + sortkey + "sort" + ".table-header").addClass("header-sorted-desc");

            if (filterkey != "" && filterdata != "")
                $("." + filterkey + "sort" + ".table-header").addClass("header-filtered");
        }

    });


}




function clickOnPaging(pageNumber, pageStart, pageEnd, event) {
    $(".pagenumber").removeClass("page-selected");

    selectedPageNumber = pageNumber;

    //var patientId = 0;
    //if ($("#patient").length > 0) {
    //    patientId = $("#patient").val();
    //}

    if (selectedformId != 0) {
        //GetDataGridData(selectedformId, "PatientName", "first", filterkey, filterdata, selectedPageNumber, 0, false);
        GetDataGridData(selectedformId, sortkey, sortorder, filterkey, filterdata, pageNumber, selectedPatientId, false);
    }
    else {
        GetFormGridData(sortkey, sortorder, filterkey, filterdata, selectedPageNumber, selectedPatientId, tablename);
    }



    event.stopPropagation();
};

function clickPreviousPage(pageNumber, event) {
    //var patientId = 0;
    //if ($("#patient").length > 0) {
    //    patientId = $("#patient").val();
    //}

    if (selectedPageNumber == 1) {
        return;
    }
    else {
        selectedPageNumber = pageNumber;

        if (selectedformId != 0) {
            GetDataGridData(selectedformId, sortkey, sortorder, filterkey, filterdata, selectedPageNumber, selectedPatientId, false);
        }
        else {
            GetFormGridData(sortkey, sortorder, filterkey, filterdata, selectedPageNumber, selectedPatientId, tablename);
        }
    }
    event.stopPropagation();
};

function clickNextPage(pageNumber, event) {
    //var patientId = 0;
    //if ($("#patient").length > 0) {
    //    patientId = $("#patient").val();
    //}


    if (selectedPageNumber == totalPageCount) {
        return;
    }
    else {
        selectedPageNumber = pageNumber;

        if (selectedformId != 0) {
            GetDataGridData(selectedformId, sortkey, sortorder, filterkey, filterdata, selectedPageNumber, selectedPatientId, false);
        }
        else {
            GetFormGridData(sortkey, sortorder, filterkey, filterdata, selectedPageNumber, selectedPatientId, tablename);
        }
    }

    event.stopPropagation();
};





function StartFilter(element, event) {

    if (selectedtype != "file") {
        //var element = $event.currentTarget;

        filterkey = selectedkey;
        filtertype = selectedtype;
        //filterformId = selectedformId;
        //filterelement = selectedelement;
        //filterevent = selectedevent;



        if (!presslock) {
            presslock = true;

            //btnFilterClick(element, event);

            if (selectedtype != "file") {
                //var element = $event.currentTarget;

                filterdata = $(element).val();

                console.log(filterdata);

                //var patientId = 0;
                //if ($("#patient").length > 0) {
                //    patientId = $("#patient").val();
                //}

                if (selectedformId != 0) {

                    GetDataGridData(selectedformId, sortkey, sortorder, filterkey, filterdata, selectedPageNumber, selectedPatientId, false);

                    //if (filterdata != "") {

                    //    if (sortorder == "asc") {
                    //        GetDataGridData(selectedformId, sortkey, "asc", filterkey, filterdata, selectedPageNumber, 0, false);
                    //    }
                    //    else if (sortorder == "desc") {
                    //        GetDataGridData(selectedformId, sortkey, "desc", filterkey, filterdata, selectedPageNumber, 0, false);
                    //    }
                    //    else if (sortorder == "first") {
                    //        GetDataGridData(selectedformId, "PatientName", "first", selectedkey, filterdata, selectedPageNumber, 0, false);
                    //    }
                    //    else {
                    //        GetDataGridData(selectedformId, "", "", filterkey, filterdata, selectedPageNumber, 0, false);
                    //    }
                    //}
                    //else {
                    //    if (sortorder == "asc") {
                    //        GetDataGridData(selectedformId, sortkey, "asc", "", "", selectedPageNumber, 0, false);
                    //    }
                    //    else if (sortorder == "desc") {
                    //        GetDataGridData(selectedformId, sortkey, "desc", "", "", selectedPageNumber, 0 ,false);
                    //    }
                    //    else if (sortorder == "first") {
                    //        GetDataGridData(selectedformId, "PatientName", "first", "", "", selectedPageNumber, 0, false);
                    //    }
                    //    else {
                    //        GetDataGridData(selectedformId, "", "", "", "", selectedPageNumber, 0, false);
                    //    }
                    //    //GetDataGridData(selectedformId, sortkey, sortorder, "", "", selectedPageNumber);
                    //}
                }
                else {
                    GetFormGridData(sortkey, "desc", filterkey, filterdata, selectedPageNumber, selectedPatientId, tablename);
                }


            }
            event.stopPropagation();

            presslock = false;

        }
    }
};

//function btnFilterClick (element, event) {

//    if (selectedtype != "file") {
//        //var element = $event.currentTarget;

//        filterdata = $(element).val();

//        console.log(filterdata);

//        //var patientId = 0;
//        //if ($("#patient").length > 0) {
//        //    patientId = $("#patient").val();
//        //}

//        if (selectedformId != 0) {
//            if (filterdata != "") {

//                if (sortorder == "asc") {
//                    if (filterdata != "") {
//                        //GetFormSortData(key, key, element, element, filterdata, "asc");

//                        GetDataGridData(selectedformId, sortkey, "asc", filterkey, filterdata, selectedPageNumber, selectedPatientId, false);
//                    }
//                }
//                else if (sortorder == "desc") {
//                    if (filterdata != "") {
//                        GetDataGridData(selectedformId, sortkey, "desc", filterkey, filterdata, selectedPageNumber, selectedPatientId, false);
//                    }
//                }
//                else {
//                    GetDataGridData(selectedformId, "PatientName", "first", selectedkey, filterdata, selectedPageNumber, selectedPatientId, false);
//                }
//            }
//            else {
//                GetDataGridData(selectedformId, sortkey, sortorder, "", "", selectedPageNumber, selectedPatientId, false);
//            }
//        }
//        else {
//            GetFormGridData(sortkey, "desc", filterkey, filterdata, selectedPageNumber, selectedPatientId, tablename);
//        }


//    }
//    event.stopPropagation();
//};

//function GetFormSortFilterData (sortkey, filterkey, filterelement, filterdata, order) {
//    var dataModel = { 'FormItemId': $rootScope.ItemId, 'ModuleId': formModuleId, 'SortKey': sortkey, 'FilterKey': filterkey, 'FilterData': filterdata, 'Order': order };

//    $('#loadingmessage').show();

//    $http({
//        method: 'GET',
//        url: "/DesktopModules/KheyaDNNFormBuilder/API/KheyaDNNFormBuilderApi/GetFormSortFilterData",
//        params: dataModel,
//        headers: { 'Content-Type': 'application/json' }
//    }).then(function successCallback(response) {
//        for (var i = 0; i < response.data.DataBody.length; i++) {
//            var row = response.data.DataBody[i];
//            for (var j = 0; j < row.DataDetailsList.length; j++) {
//                var component = row.DataDetailsList[j];

//                if (component.comtype == "datetime") {
//                    row.DataDetailsList[j].value = new Date(component.value);
//                }
//            }
//        }

//        $scope.dataItemList = response.data;
//        $rootScope.Pages = response.data.Pages;

//        var count = 0;

//        if (response.data.PageSize > 0) {
//            $rootScope.clickOnPaging(0, 0, response.data.PageSize - 1);
//        }

//        $('#loadingmessage').hide();

//        $(filterelement).closest(".table-header").addClass("header-filtered");

//        $(".table-header").removeClass("header-sorted-asc");
//        $(".table-header").removeClass("header-sorted-desc");
//        //if (order == 'asc') {
//        //    $(sortelement).closest(".table-header").addClass("header-sorted-asc");
//        //}
//        //else {
//        //    $(sortelement).closest(".table-header").addClass("header-sorted-desc");
//        //}

//        //$(sortelement).closest(".filter-popup").hide();
//        //$(filterelement).closest(".filter-popup").hide();
//    }, function errorCallback(response) {
//        console.log("error");
//        $('#loadingmessage').hide();
//    });

//}

function HideAndShowColumn(key, ele, event) {
    //alert(key);

    if ($(ele).is(':checked')) {
        $("." + key + "sort").show();

        datagridColumn.forEach(function (col) {
            if (col.key == key) {
                const index = datagridHideColumn.findIndex(x => x.key == col.key);
                if (index > -1) {
                    datagridHideColumn.splice(index, 1);
                }
            }
        });


    }
    else {
        $("." + key + "sort").hide();


        var offset = $(ele).offset();

        //$(".filter-popup").css('left', parseInt(offset.left) + "px");
        //$(".filter-popup").css('top', (parseInt(offset.top) + 50) + "px");

        datagridColumn.forEach(function (col) {
            if (col.key == key) {
                datagridHideColumn.push(col);
            }
        });

        if (filterkey == key && sortkey == key) {
            sortkey = "";
            sorttype = "";
            sortorder = "";

            filterkey = "";
            filtertype = "";
            filterdata = "";

            //$("." + sortkey + "sort" + ".table-header").removeClass("header-sorted-asc");
            //$("." + sortkey + "sort" + ".table-header").removeClass("header-sorted-desc");
            //$("." + filterkey + "sort" + ".table-header").removeClass("header-filtered");

            GetDataGridData(selectedformId, "", "", "", "", selectedPageNumber, 0, false);
        }
        else if (sortkey == key) {
            sortkey = "";
            sorttype = "";
            sortorder = "";

            //$("." + sortkey + "sort" + ".table-header").removeClass("header-sorted-asc");
            //$("." + sortkey + "sort" + ".table-header").removeClass("header-sorted-desc");
            GetDataGridData(selectedformId, "", "", filterkey, filterdata, selectedPageNumber, 0, false);
        }
        else if (filterkey == key) {
            filterkey = "";
            filtertype = "";
            filterdata = "";

            //$("." + filterkey + "sort" + ".table-header").removeClass("header-filtered");
            GetDataGridData(selectedformId, sortkey, sortorder, "", "", selectedPageNumber, 0, false);
        }

        if (selectedkey == key) {
            $(".filter-popup").hide();
        }
    }

    console.log(datagridHideColumn);


    //if($(ele).)



    event.stopPropagation();
}

function ProcessSortDataGridColumns(components, formType) {

    var columns = [];

    //Extra column added
    columns.push({ 'label': 'Id', 'key': 'Id', 'type': 'custom' });
    columns.push({ 'label': 'Date', 'key': 'SystemDate', 'type': 'custom' });
    columns.push({ 'label': 'Patient Name', 'key': 'PatientName', 'type': 'custom' });
    columns.push({ 'label': 'Doctor Name', 'key': 'DoctorName', 'type': 'custom' });
    //columns.push({ 'label': 'Appointment ID', 'key': 'AppointmentID', 'type': 'custom' });

    //Find the column list

    if (formType == "form") {
        for (var i = 0; i < components.length; i++) {
            if (components[i].type != "button") {
                columns.push({ 'label': components[i].label, 'key': components[i].key, 'type': components[i].type });
            }
        }
    }
    else { //If wizard find the column list
        components.forEach(function (component) {
            component.components.forEach(function (componentInner) {
                if (componentInner.type != "button") {
                    columns.push({ 'label': componentInner.label, 'key': componentInner.key, 'type': componentInner.type });
                }
            });
        });
    }

    console.log(components);

    //Extra column add

    
    columns.push({ 'label': 'Create Date', 'key': 'SystemCreateDate', 'type': 'custom' });

    return columns;

}

//function ProcessSortDataGridRows(dataBody, columns) {
//    var rows = []; // Store row data
//    var row = {};

//    //Extract data from Data JSON
//    for (var i = 0; i < dataBody.length; i++) {

//        //var dataJson = JSON.parse(response[i].DataJSON);

//        dataBody[i].DataDetailsList.forEach(function (data) {
//            if (data.comtype != 'file') {
//                row[data.key] = data.value;
//                row["filename"] = "";
//            }
//            else {
//                //dataJson.data[columns[j].key].forEach(function (file) {
//                //    row[data.key] = file.url;
//                //    row["filename"] = file.name;
//                //});

//                if (data.fileBase64 != null) {
//                    row[data.key] = data.fileBase64;
//                    row["filename"] = data.fileName;
//                }
//                else {
//                    row[data.key] = "";
//                    row["filename"] = "";
//                }
//            }
//        });

//        row["Id"] = dataBody[i].id;

//        //Extra Column data Add
//        if (dataBody[i].CreateDate != undefined)
//            row["CreateDate"] = dataBody[i].CreateDate;
//        else
//            row["CreateDate"] = "";

//        if (dataBody[i].Date != undefined)
//            row["Date"] = dataBody[i].Date;
//        else
//            row["Date"] = "";

//        if (dataBody[i].PatientName != "")
//            row["PatientName"] = dataBody[i].patientName;
//        else
//            row["PatientName"] = "";

//        if (dataBody[i].DoctorName != "")
//            row["DoctorName"] = dataBody[i].doctorName;
//        else
//            row["DoctorName"] = "";

//        //if (response[i].AppointmentID != undefined)
//        //    row["AppointmentID"] = response[i].AppointmentID;
//        //else
//        //    row["AppointmentID"] = "";

//        //-----------//

//        rows.push(row);
//        row = {};
//    }

//    return rows;
//}

//function ProcessDataGridRows(response, columns) {
//    var rows = []; // Store row data
//    var row = {};

//    //Extract data from Data JSON
//    for (var i = 0; i < response.length; i++) {

//        var dataJson = JSON.parse(response[i].DataJSON);

//        for (var j = 0; j < columns.length; j++) {

//            if (dataJson.data[columns[j].key] != undefined) {
//                if (columns[j].type != 'file') {
//                    row[columns[j].key] = dataJson.data[columns[j].key];
//                    row["filename"] = "";
//                }
//                else {
//                    dataJson.data[columns[j].key].forEach(function (file) {
//                        row[columns[j].key] = file.url;
//                        row["filename"] = file.name;
//                    });
//                }
//            }
//            else {
//                row[columns[j].key] = "";
//            }

//        }

//        row["Id"] = response[i].Id;

//        //Extra Column data Add
//        if (response[i].CreateDate != undefined)
//            row["CreateDate"] = response[i].CreateDate;
//        else
//            row["CreateDate"] = "";

//        if (response[i].Date != undefined)
//            row["Date"] = response[i].Date;
//        else
//            row["Date"] = "";

//        if (response[i].PatientName != undefined)
//            row["PatientName"] = response[i].PatientName;
//        else
//            row["PatientName"] = "";

//        if (response[i].DoctorName != undefined)
//            row["DoctorName"] = response[i].DoctorName;
//        else
//            row["DoctorName"] = "";

//        //if (response[i].AppointmentID != undefined)
//        //    row["AppointmentID"] = response[i].AppointmentID;
//        //else
//        //    row["AppointmentID"] = "";

//        //-----------//

//        rows.push(row);
//        row = {};
//    }

//    return rows;
//}
//function ProcessDataGridColumns(components, formType) {

//    var columns = [];

//    //Extra column added
//    columns.push({ 'label': 'Id', 'key': 'Id', 'type': 'custom' });
//    columns.push({ 'label': 'Patient Name', 'key': 'PatientName', 'type': 'custom' });
//    columns.push({ 'label': 'Doctor Name', 'key': 'DoctorName', 'type': 'custom' });
//    //columns.push({ 'label': 'Appointment ID', 'key': 'AppointmentID', 'type': 'custom' });

//    //Find the column list

//    if (formType == "form") {
//        for (var i = 0; i < components.length; i++) {
//            if (components[i].type != "button") {
//                columns.push({ 'label': components[i].label, 'key': components[i].key, 'type': components[i].type });
//            }
//        }
//    }
//    else { //If wizard find the column list
//        components.forEach(function (component) {
//            component.components.forEach(function (componentInner) {
//                if (componentInner.type != "button") {
//                    columns.push({ 'label': componentInner.label, 'key': componentInner.key, 'type': componentInner.type });
//                }
//            });
//        });
//    }

//    console.log(components);

//    //Extra column add

//    columns.push({ 'label': 'Date', 'key': 'Date', 'type': 'custom' });
//    columns.push({ 'label': 'Create Date', 'key': 'CreateDate', 'type': 'custom' });

//    return columns;

//}

//function CreateDataGridBody(columns, rows, ele, formId) {
//    //Add row value in table
//    for (var i = 0; i < rows.length; i++) {
//        var tr = "<tr>";
//        for (var j = 0; j < columns.length; j++) {
//            if (columns[j].type != 'file') {
//                tr = tr + "<td class=" + columns[j].key + "sort" + ">" + rows[i][columns[j].key] + "</td>";
//            }
//            else {
//                if (rows[i]["filename"].indexOf(".pdf") == -1) {
//                    tr = tr + "<td class=" + columns[j].key + "sort" + "><a href='/FormBuilder/ViewImage?Id=" + rows[i]['Id']
//                        + "&key=" + columns[j].key + "'><img class='file-img' src=" + rows[i][columns[j].key] + "></img></a></td>";
//                }
//                else {
//                    tr = tr + "<td class=" + columns[j].key + "sort" + "><a href='/FormBuilder/ViewImage?Id=" + rows[i]['Id']
//                        + "&key=" + columns[j].key + "'><img class='file-img' src='/Content/images/file.jpg'/></img></a></td>";
//                }

//            }
//        }

//        tr = tr + "<td><a href='/FormBuilder/ViewEdit?Id=" + rows[i]['Id'] + "' class='btn btn-success'>Edit</a>" + "</td>";

//        ////////
//        tr = tr + "<td>";
//        tr = tr + '<button onclick="DeleteData(' + rows[i]['Id'] + ',' + formId + ')" class="btn btn-success">Delete</button>';
//        tr = tr + "</td>";
//            //////////////



//        tr = tr + "</tr>";
//        $(ele).find(".table-body").append(tr);
//    }

//    datagridHideColumn.forEach(function (col) {
//        $("." + col.key + "sort").hide();
//    });

//}



//function GetDataByFormAndPatient(formId, patientId) {
//    $(".table-form-data").find(".table-header-row").html("");
//    $(".table-form-data").find(".table-body").html("");

//    selectedformId = formId;

//    GetDataGridData(selectedformId, "PatientName", "first", "", "", 1, 0, false);

//    //$.ajax({
//    //    type: "GET",
//    //    url: "/FormBuilder/GetDataByFormAndPatient?formId= " + formId + "&patientId=" + patientId,
//    //    contentType: "application/json; charset=utf-8",
//    //    dataType: "json",
//    //    contentType: 'application/json; charset=utf-8',

//    //    success: function (response) {
//    //        console.log(response);

//    //        ProcessData(response, $(".table-form-data"), formId);
//    //    }

//    //});
//}

function isColumnExist(components, name) {
    for (var i = 0; i < components; i++) {
        if (components[i].key == name) {
            return true;
        }
    }

    return false;
}
var getKeys = function (obj) {
    var keys = [];
    for (var key in obj) {
        keys.push(key);
    }
    return keys;
}

function isValidDate(dateString) {
    // First check for the pattern
    if (!/^\d{1,2}\/\d{1,2}\/\d{4}$/.test(dateString))
        return false;

    // Parse the date parts to integers
    var parts = dateString.split("/");
    var day = parseInt(parts[1], 10);
    var month = parseInt(parts[0], 10);
    var year = parseInt(parts[2], 10);

    // Check the ranges of month and year
    if (year < 1000 || year > 3000 || month == 0 || month > 12)
        return false;

    var monthLength = [31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31];

    // Adjust for leap years
    if (year % 400 == 0 || (year % 100 != 0 && year % 4 == 0))
        monthLength[1] = 29;

    // Check the range of the day
    return day > 0 && day <= monthLength[month - 1];
};
function SaveData(formId, submission) {

    if (!isValidDate($("#entrydate").val())) {
        return;
    }

    var dataModel = {
        'FormId': formId, 'DataJSON': JSON.stringify(submission), 'PatientID': $("#patient").val(), 'DoctorId': $("#doctor").val(),
        'AppointmentID': $("#appointment").val(), 'Date': $("#entrydate").val()
    };

    console.log(dataModel);

    $.ajax({
        type: "POST",
        data: JSON.stringify(dataModel),
        url: "/FormBuilder/SaveData",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        contentType: 'application/json; charset=utf-8',

        success: function (response) {
            console.log(response);

            alert("Data Saved");

            window.location = "/FormBuilder/ViewEdit/" + response.Id;

            $(".alert-success").show();
        }

    });
}

function UpdateData(id, formId, submission) {
    var dataModel = {
        'Id': id, 'FormId': formId, 'DataJSON': JSON.stringify(submission), 'PatientID': $("#patient").val(), 'DoctorId': $("#doctor").val(), 'AppointmentID': $("#appointment").val(), 'Date': $("#entrydate").val()
    };

    if (!isValidDate($("#entrydate").val())) {
        return;
    }

    $.ajax({
        type: "POST",
        data: JSON.stringify(dataModel),
        url: "/FormBuilder/UpdateData",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        contentType: 'application/json; charset=utf-8',

        success: function (response) {
            console.log(response);

            //window.location = "/FormBuilder/Edit/" + response.Id;

            $(".alert-success").show();
        }

    });
}

function SaveForm() {
    var dataModel = {
        'FormName': $("#name").val(), 'FormTitle': $("#title").val(), 'FormType': $("#formtype").val(), 'FormJSON': JSON.stringify(builder.instance.schema), 'IsUse': 0
    };

    if ($("#title").val() == "") {
        return false;
    }
    if ($("#name").val() == "") {
        return false;
    }

    $.ajax({
        type: "POST",
        data: JSON.stringify(dataModel),
        url: "/FormBuilder/SaveForm",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        contentType: 'application/json; charset=utf-8',

        success: function (response) {
            console.log(response);

            if (response != null) {
                alert("Saved");
            }
            else {
                alert("Error");
            }

            window.location = "/FormBuilder/Edit/" + response.Id;


        }

    });
}

function DeleteForm(Id) {

    $.ajax({
        type: "GET",
        url: "/FormBuilder/DeleteForm?Id=" + Id,
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        contentType: 'application/json; charset=utf-8',

        success: function (response) {
            console.log(response);

            if (response == "Ok") {
                window.location = "/FormBuilder/List";
            }
            else {
                alert("Error");
            }
        }

    });
}
function DeleteData(Id, formId) {

    $.ajax({
        type: "GET",
        url: "/FormBuilder/DeleteData?Id=" + Id,
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        contentType: 'application/json; charset=utf-8',

        success: function (response) {
            console.log(response);

            if (response == "Ok") {
                window.location = "/FormBuilder/DataGrid?Id=" + formId;
            }
            else {
                alert("Error");
            }
        }

    });
}
function DisableEnableForm(Id, ele) {
    var value;

    if ($(ele).is(':checked')) {
        value = true;
    }
    else {
        value = false;
    }

    $.ajax({
        type: "GET",
        url: "/FormBuilder/DisableEnableForm?Id=" + Id + "&value=" + value,
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        contentType: 'application/json; charset=utf-8',

        success: function (response) {
            console.log(response);

            if (response == "Ok") {
                window.location = "/FormBuilder/List";
            }
            else {
                alert("Error");
            }
        }

    });
}

function LockUnlockForm(Id, ele) {
    var value;

    if ($(ele).is(':checked')) {
        value = true;
    }
    else {
        value = false;
    }

    $.ajax({
        type: "GET",
        url: "/FormBuilder/LockUnlockForm?Id=" + Id + "&value=" + value,
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        contentType: 'application/json; charset=utf-8',

        success: function (response) {
            console.log(response);

            if (response == "Ok") {
                window.location = "/FormBuilder/List";
            }
            else {
                alert("Error");
            }
        }

    });
}

function UpdateForm(id) {
    var dataModel = {
        'Id': id, 'FormName': $("#name").val(), 'FormTitle': $("#title").val(), 'FormType': $("#formtype").val(), 'FormJSON': JSON.stringify(builder.instance.schema), 'IsUse': 0
    };

    console.log(dataModel);

    $.ajax({
        type: "POST",
        data: JSON.stringify(dataModel),
        url: "/FormBuilder/UpdateForm",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        contentType: 'application/json; charset=utf-8',

        success: function (response) {
            console.log(response);

            if (response == "Ok") {
                alert("Saved");
            }
            else {
                alert("Error");
            }


        }

    });
}

function LoadForm() {
    var mycomponents = [
        {
            type: 'textfield',
            key: 'firstName',
            label: 'First Name',
            placeholder: 'Enter your first name.',
            input: true
        },
        {
            type: 'textfield',
            key: 'lastName',
            label: 'Last Name',
            placeholder: 'Enter your last name',
            input: true
        },
        {
            type: 'button',
            action: 'submit',
            label: 'Submit',
            theme: 'primary'
        }
    ];

    //builder.redraw();

    builder.setForm({ components: mycomponents });

    console.log(builder);
}

$(document).ready(function () {

    $(document).click(function (event) {
        if (!$(event.target).hasClass("filter-popup") && !$(event.target).hasClass("filter-container")
            && !$(event.target).hasClass("filter-item") && !$(event.target).hasClass("searchinput")) {
            $(".filter-popup").hide();

        }
    });
});