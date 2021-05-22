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

/*
window.onunload = () => {
    // Clear the local storage
    localStorage.clear()
}*/
