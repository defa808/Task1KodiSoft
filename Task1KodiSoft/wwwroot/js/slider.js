$(document).ready(function () {
    var scroller = {};
    scroller.e = document.getElementById("slider");

    if (scroller.e.addEventListener) {
        scroller.e.addEventListener("mousewheel", MouseWheelHandler, false);
        scroller.e.addEventListener("DOMMouseScroll", MouseWheelHandler, false);
    } else scroller.e.attachEvent("onmousewheel", MouseWheelHandler);

    function MouseWheelHandler(e) {

        // cross-browser wheel delta
        var e = window.event || e;
        var delta = - 20 * (Math.max(-1, Math.min(1, (e.wheelDelta || -e.detail))));

        var pst = $('#slider').scrollLeft() + delta*10;

        if (pst < 0) {
            pst = 0;
        } else if (pst > $('.slide_holder').width()) {
            pst = $('.slide_holder').width();
        }

        $('#slider').scrollLeft(pst);

        return false;
    }
})
