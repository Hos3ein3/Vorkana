// این تایع پس از فشردن دکمه ی Save
//آن را Disable میکند
//ورودی آن نیز ID یا Class آن دکمه است


//$(function () {
//    $(window).on('beforeunload', function () {
//        $(".btn-save").prop("disabled", "disabled");
//        $("#btn-save").prop("disabled", "disabled");
//    });
//});

$(function () {
    $(".btn-save").click(function () {
        $(window).on('beforeunload', function () {
            $(".btn-save").prop("disabled", "disabled");
            $("#btn-save").prop("disabled", "disabled");
        });
    });
});

function ButtonSavePrevent(saveBtn) {
    $(window).on('beforeunload', function () {
        $(saveBtn).prop("disabled", "disabled");
    });
}