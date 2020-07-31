


function ImagePreview(InputImageTag, ImgTag, CheckSize = false) {
    var ImgSize = 0;
    $(InputImageTag).change(function () {
        ImgSize = readURL(this, ImgTag, CheckSize);
    });
    return ImgSize;
}

function readURL(input, ImgTag, CheckSize) {
    var ImgSize = 0;
    if (input.files.length == 0) {
        $(ImgTag).attr('src', "");
    }

    if (input.files && input.files[0]) {
        var reader = new FileReader();

        reader.onload = function (e) {
            $(ImgTag).attr('src', e.target.result);
            if (CheckSize == true) {
                var File = input.files;
                ImgSize = CheckImgSize(File[0]);
            }
        }
        reader.readAsDataURL(input.files[0]);
    }
    return ImgSize;
}

function CheckImgSize(file) {
    var size = ~~(file.size / 1024);
    return size;
}
