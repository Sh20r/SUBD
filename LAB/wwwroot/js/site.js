// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


function changeCurr(elem) {
    if (elem.value == 'Доллар') {
        document.getElementById("currency").innerHTML = parseFloat(document.getElementById("currency").innerHTML) / 93;
        elem.value = "Сомы";
    }
    else {
        document.getElementById("currency").innerHTML = parseFloat(document.getElementById("currency").innerHTML) * 93;
        elem.value = "Доллар";
    }

}