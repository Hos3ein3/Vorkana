//ورودی این تابع یک آیدی از یک تگ است
//این تابع براساس  تعدا حروف آن تگ،فونت آن را کوچک میکند

function ChangeFontSizeByTextLenght(tagId) {

    $quote = $(tagId);
    //var $quote = $(".title");

    var $numWords = $quote.text().split(" ").length;

    if (($numWords >= 1) && ($numWords < 4)) {
        $quote.css("font-size", "14px");
    }
    else if (($numWords >= 4) && ($numWords < 7)) {
        $quote.css("font-size", "12px");
    }
    else if (($numWords >= 7) && ($numWords < 9)) {
        $quote.css("font-size", "10px");
    }
    else {
        $quote.css("font-size", "8px");
    } 
}