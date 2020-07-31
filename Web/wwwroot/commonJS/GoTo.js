

function GoToTop() {
    document.body.scrollTop = 0;
    document.documentElement.scrollTop = 0;
}

function GoToElement(TagId,Speed=300) {
    $([document.documentElement, document.body]).animate({
        scrollTop: $(TagId).offset().top
    }, Speed);
}

function GoToFooter(Speed=300) {
    var footer = $('footer');
    $([document.documentElement, document.body]).animate({
        scrollTop: $(footer).offset().top
    }, Speed);
}

function ScrollVertically(Value=500) {
    window.scrollTo(0, Value);
}

function ScrollHorizontally(Value=500) {
    window.scrollTo(Value, 0);
}

function Scroll(HorizontalValye=500,VerticalValue=500) {
    window.scrollTo(HorizontalValye, VerticalValue);
}


function Goto(name) {
    var id = '#' + name;
    $([document.documentElement, document.body]).animate({
        scrollTop: $(id).offset().top
    }, 300);
}