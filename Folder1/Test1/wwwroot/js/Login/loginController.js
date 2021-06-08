$("#facebook").click(function (){
    let gmail = $("#gmail").val().trim();
   let pass = $("#password").val().trim();
   let url = "/Login/JustTest?gmail="+gmail+"&password="+pass;
   
   $.ajax({
       url : url ,
       type : "get",
       dataType :"json",
       success : function (response){
           if(response.check != ""){
               alert(response.check);
           }else{
               window.location.href="/Home/Index";
           }
       },
       error: function () {
           alert('error');
       }
   })
});




function Logout()
{
    fetch('/Login/Logout', {
        method: "GET",
        headers: {
            'Content-Type': 'application/json'
        },
    })
        .then(respon => respon.text())
        .then(result => {
            if(result == 1)
            {
                $("#loginOrlogout").load(window.location.href+" #loginOrlogout");
            }
            else
            {
                alert("Logout deo dc !!!");
            }
        })
        .catch(error => {
            alert("Loi duong truyen");
        });
}