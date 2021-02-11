// <reference path="../_references.js" />



var app = app || {};

(function () {

    app.ErrorMessage = function (msg) {

        $.alert({
            //theme: 'material',
            //icon: 'glyphicon glyphicon-exclamation-sign',
            title: 'رسالة خطأ',
            content: msg,
            confirmButton: 'موافق',
            cancelButton: 'إلغاء',
            //confirmButtonClass: 'btn-danger',
            //closeIcon: true, // close icon will be moved to left if RTL is set to true.
            rtl: true,
            keyboardEnabled: true,
            columnClass: 'col-md-6 col-md-offset-3',
            //confirm: function () {
            //    alert('تایید شد.');
            //}
        });

    };

    app.InfoMessage = function (msg) {

        $.alert({
            //theme: 'material',
            //icon: 'glyphicon glyphicon-exclamation-sign',
            title: 'رسالة',
            content: msg,
            confirmButton: 'موافق',
            cancelButton: 'إلغاء',
            //confirmButtonClass: 'btn-danger',
            //closeIcon: true, // close icon will be moved to left if RTL is set to true.
            rtl: true,
            keyboardEnabled: true,
            columnClass: 'col-md-6 col-md-offset-3',
            //confirm: function () {
            //    alert('تایید شد.');
            //}
        });

    };

    app.DeleteConfirm = function () {
        var cult = kendo.culture().name;
        if (cult == "ar-SY") {

            $('.DeleteConfirm').confirm({

                title: 'تأكيد الحذف',
                content: 'هل تريد حذف البيانات؟',
                confirmButton: 'موافق',
                cancelButton: 'إلغاء',
                rtl: true,
                keyboardEnabled: true,
                columnClass: 'col-md-6 col-md-offset-3',
            });
        }
        else
        {

                $('.DeleteConfirm').confirm({

                    title: 'Delete Confirmation',
                    content: 'Do you want to delete record',
                    confirmButton: 'OK',
                    cancelButton: 'Cancel',
                    rtl: false,
                    keyboardEnabled: true,
                    columnClass: 'col-md-6 col-md-offset-3',
                });
            
        }
    };



    app.filterCities = function () {
        return {
            SelectedCountryId: $("#CountryID").val()
        };
    }


    app.RebindCombo = function (id, prop) {
        $('#' + id).data('kendoComboBox').dataSource.read(prop);
    }
    app.ReturnData = function (prop) {
        return prop
    }

    app.RebindGrid = function (id, prop) {
        $('#' + id).data('kendoGrid').dataSource.read(prop);
    }
    //app.UpdateAttachmentFolderAfterUpload = function (e) {
    
    //    var response = e.response.data;
    //    $("#Attachment").val(response);
        
    //}

    app.UplaodAttachmentFolderName = function (e) {

        e.data = { FolderName: $("#Attachment").val() };
       
    }

    


    //app.IsArabic = function () {
    //    var culture = $.cookie("Erpculture");
    //    if (culture.toString().indexOf("ar") != -1) {
    //        return true;
    //    }
    //    else
    //        return false;
    //}
})();


/***********************************************************************************************/


$(function () {

    $('[data-toggle="tooltip"]').tooltip();

    $(document).ajaxStart(function (e, xhr, opts) {
        

    }).ajaxComplete(function (e, xhr, opts) {
        $('[data-toggle="tooltip"]').tooltip();
    });
    $('.DeleteConfirm').confirm({
        //title: 'تأكيد الحذف',
        //content: 'هل تريد حذف البيانات؟',
        //confirmButton: 'موافق',
        //cancelButton: 'إلغاء',
        //rtl: true,
        //keyboardEnabled: true,
    });

    $('.CustomValKendo').kendoValidator();

    Array.prototype.contains = function(obj) {
    var i = this.length;
    while (i--) {
        if (this[i] === obj) {
            return true;
        }
    }
    return false;
}
});
