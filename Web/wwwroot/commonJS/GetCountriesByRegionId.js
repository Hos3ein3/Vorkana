//پارامتر های ورودی:
//آیدی تگ های region و  state


function GetCountriesByRegionId(regionSelectTag, countriesSelectTag) {
    
    $(regionSelectTag).change(function () {
        GetCountries(regionSelectTag, countriesSelectTag);
    });
}
function GetCountries(regionSelectTag, countriesSelectTag) {
    regionValue = $(regionSelectTag).val();
    $.ajax({
        data: { countryRegions: regionValue },
        url: '/Home/GetCountriesByRegion',
        type: 'GET',
        datatype: 'application/json',
        contentType: 'application/json',
        success: function (result) {
            $(countriesSelectTag).html("");
            $(countriesSelectTag).append($('<option></option>').val(null).html("-- کشور را انتخاب کنید --"));
            $.each(result, function (i, value) {
                var html = '<option value="' + value.value + '">' + value.text + '</option>';
                $(countriesSelectTag).append(html);
            });
        },
        error: function () { alert("خطایی رخ داده است"); }
    });
}