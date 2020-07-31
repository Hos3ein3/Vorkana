//ورودی از  نوع عدد صحیح است
//خروجی لیستی از جنس جیسون است 
//برای استفاده کافی است یک  آیدی  را به عنوان ورودی به این تابع ارسال نمایید و برای نمایش نتیجه،به تگ سِلِکت خود یک آیدی به اسم City بدهید

function GetCitiesByStateId(stateSelectTag, citySelectTag) {

    $(state).change(function () {
        GetCities(stateSelectTag, citySelectTag);
    });
}

function GetCities(stateSelectTag, citySelectTag) {
    var stateId = $(stateSelectTag).val();
    $.ajax({
        data: { stateId: stateId },
        url: '/Home/GetCitiesByStateId',
        type: 'GET',
        datatype: 'application/json',
        contentType: 'application/json',
        success: function (result) {
            $(citySelectTag).html("");
            $(citySelectTag).append($('<option></option>').val(null).html("---شهر را انتخاب کنید---"));
            $.each(result, function (i, value) {
                var html = '<option value="' + value.value + '">' + value.text + '</option>';
                $(citySelectTag).append(html);
            });
        },
        error: function () { alert("متاسفانه خطایی رخ داده است.."); }
    });
}