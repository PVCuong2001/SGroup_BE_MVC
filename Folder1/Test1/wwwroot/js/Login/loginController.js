$("#facebook").click(function (){
    let gmail = $("#gmail").val();
   let pass = $("#password").val();
   let url = "/Login/JustTest?gmail="+gmail+"&password="+pass;
   $.ajax({
       url : url ,
       type : "get",
       dataType :"json",
       success : function (response){
           console.log(response.check +"adasd");
           if(response.check == false){
               console.log(response.check +"a111111");
               alert("failed")
           }
       }
   })
/*
       ?searchName=un&orderBy=Name+Desc
*/
    
});