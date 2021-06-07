﻿// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

showInPopUp = (url,title) =>{
    $.ajax({
        type : "GET",
        url : url ,
        success : function (res){
            console.log("oke");
            $("#form_modal .modal-body").html(res);
            $("#form_modal .modal-title").html(title);
            $("#form_modal").modal("show");
        }
    })
}

jQueryAjaxPost = form => {
    console.log(form.action)
    $.ajax({
        type: "POST",
        contentType: false,
        data: new FormData(form),
        url: form.action,
        processData: false,
        success: function (res) {
            if (res.isValid) {
                console.log("asdasd");
                $("#view-all").html(res.html);
                $("#form_modal .modal-body").html('');
                $("#form_modal .modal-title").html('');
                $("#form_modal").modal("hide");
            } else {
                $("#form_modal .modal-body").html(res.html);
            }
        },
        error: function (err) {
            console.log(err);
        }
    })
    return false;
}