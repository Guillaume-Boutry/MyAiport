// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your Javascript code.
$("#SearchString").keyup(function () {
    const searchString = $(this).val().toLowerCase();
    $("table tr").each(function (results) {
        if (results !== 0) {
            const text = $(this).find("td:nth-child(1)").text().toLowerCase();
            if(text.includes(searchString)) {
                $(this).show();
            } else {
                $(this).hide();
            }
        }
    });
});