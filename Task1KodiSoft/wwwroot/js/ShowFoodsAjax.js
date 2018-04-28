$.ajax({
    type: 'GET',
    url: '/Home/ShowFoods',
    success: function (data) {
        if (data != '') {
            $("#content_slide2").html("");
            $("#content_slide2").append(data);
        }

    }
});
