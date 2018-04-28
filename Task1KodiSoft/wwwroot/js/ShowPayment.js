$.ajax({
    type: 'GET',
    url: '/Home/ShowPayments',
    success: function (data) {
        if (data != '') {
            $("#content_slide3").html("");
            $("#content_slide3").append(data);
        }

    }
});
