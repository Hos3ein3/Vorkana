//این تابع در ورودی یک آیدی از نوع تگ A میگیرد
//اتربیوت href آن را پیدا میکند
//سپس دنبال آن آدرس میگردد
//حتما باید پسوند فایل ها مشخص شده باشد
//اگر در مسیر مورد نظر فایل با پسنود و نام مورد نظر پیدا شود، صحیح را برمیگرداند

function CheckFileExistServerSide(path) {
    //var path = '';
    $.ajax({
        url: "/Home/CheckImageExist",
        data: { "path": path },
        dataType: 'json',
        contextType: "application/json",
        traditional: true,
        success: function (data) {
            return data.result;
        },
        error: function () {
            alert("خطایی رخ داده است");
        }
    });
}


function CheckFileExistClientSide(idOfTagA) {
    var isExist = false;
    //idOfTagA = "#" + idOfTagA;
    var src = $(idOfTagA).attr("href");
    $.ajax({
        url: src,
        type: 'HEAD',
        error: function () {
            isExist = false;
        },
        success: function () {
            isExist = true;
        }
    }).done(function (response) {
        
    });
    return isExist;
}