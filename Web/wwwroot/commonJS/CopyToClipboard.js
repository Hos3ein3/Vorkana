function CopyToClipboardByValue(Value) {

    var $temp = $("<input type='hidden'> ");
    $("body").append($temp);
    $temp.val(Value).select();
    document.execCommand("copy");
    $temp.remove();
}

function CopyToClipboardByInputTag(Tag) {

    var TagValue = Tag.val();
    var $temp = $("<input type='hidden'> ");
    $("body").append($temp);
    $temp.val(TagValue).select();
    document.execCommand("copy");
    $temp.remove();
}

function CopyToClipboardByTag(Tag) {

    var $temp = $("<input type='hidden'> ");
    $("body").append($temp);
    var Value = Tag.text();
    $temp.val(Value).select();
    document.execCommand("copy");
    $temp.remove();
}