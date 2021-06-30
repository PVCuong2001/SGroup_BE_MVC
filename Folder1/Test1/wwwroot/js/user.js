jQueryAjaxPostUser = form => {
    $.ajax({
        type: "POST",
        contentType: false,
        data: new FormData(form),
        url: form.action,
        processData: false,
        success: function (res) {
            if(res.success == true){
                alert(res.responseText);
                let tID = setTimeout(function () {
                    window.location.href = "/";
                    window.clearTimeout(tID);		// clear time out.
                }, 3000);
                
            }else{
                alert(res.responseText);
            }
        },
        error: function (err) {
            console.log(err);
        }
    })
    return false;
}