
function filterProducts(filterText) {
    var rows = document.getElementsByClassName("product-item");
    for (var i = 0; i < rows.length; i++) {
        var row = rows[i];
        var email = row.getAttribute("data-name");
        if (email.toLowerCase().indexOf(filterText.toLowerCase()) > -1) {
            row.style.display = "";
        } else {
            row.style.display = "none";
        }
    }
}