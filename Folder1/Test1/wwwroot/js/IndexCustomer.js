window.onbeforeunload = function() {
    let Ele_search = document.getElementById("idSearch");
    let Ele_orderBy =document.getElementById("idOrder");
    sessionStorage.setItem("search",Ele_search.value);
    sessionStorage.setItem("orderBy",Ele_orderBy.value);
}

window.onload = function() {
    let Ele_search = document.getElementById("idSearch");
    let Ele_orderBy =document.getElementById("idOrder");
    let search = sessionStorage.getItem("search");
    let orderBy = sessionStorage.getItem("orderBy");
    if(search!=null ) Ele_search.value =search;
    if(orderBy!=null) Ele_orderBy.value =orderBy;
    // ...
}

function Delete(tag)
{
    let id = $(tag).data("id");
    let tr = $(tag).closest("td").parent();

    fetch('/Customer/Delete', {
        method: "POST",
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(id)
    })
        .then(respon => respon.text())
        .then(result => {
            if(result == 1)
            {
                tr.remove();
            }
            else
            {
                alert("Xoa del dc !!!");
            }
        })
        .catch(error => {
            alert("Loi duong truyen");
        });
}
