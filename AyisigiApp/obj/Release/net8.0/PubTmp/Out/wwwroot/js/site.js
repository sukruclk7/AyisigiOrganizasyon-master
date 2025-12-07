//Look out for this as a JQuery plugin => coming soon. 
//Writing it for fun, so comments & suggestions welcome.

//See plugin version at https://cdpn.io/fzAHq
$(document).ready(function($) {

    var full = $('#fullscreen');
    $(full).data('state', 'open');
    $('button').click(function() {
        if ($(full).data('state') == 'open') {
            $(full).fadeIn(300);
            $(full).data('state', 'close');
            //console.log($(full).data('state') );
        }
    });
    $('.close').click(function() {
        if ($(full).data('state') == 'close') {
            $(full).fadeOut();
            $(full).data('state', 'open');
            //console.log($(full).data('state') );
        }
    });
});