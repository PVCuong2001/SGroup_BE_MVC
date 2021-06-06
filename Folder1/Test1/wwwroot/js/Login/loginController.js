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