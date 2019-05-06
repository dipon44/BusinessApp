

$(document.body).on("keyup", "#Name", function () {

    var value = $(this).val();

    if (value !== "") {

        $(this).css("background-color", "burlywood");
       
    } else {
        $(this).css("background-color", "white");
    }

});

$(document.body).on("keyup", "#Code", function () {

    var value = $(this).val();

    if (value !== "") {

        $(this).css("background-color", "burlywood");
    } else {
        $(this).css("background-color", "white");
    }

});

