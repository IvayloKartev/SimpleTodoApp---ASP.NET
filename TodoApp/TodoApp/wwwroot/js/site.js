document.addEventListener("DOMContentLoaded", function(){
    const date = new Date();
    const day = date.getDay();
    const month = date.getMonth();
    const year = date.getFullYear();
    let curDate = String(day)+"/"+String(month)+"/"+String(year);
    const dateInp = document.getElementById("dateInp");
    function assignDate(){
        dateInp.value = curDate;
    }
    const submitbtn = document.getElementById("sbmt");
    submitbtn.addEventListener("click", assignDate);
});