/*
 * Author               : Quaint Park
 * Copyright            : © 2017 Quaint Park.
 * Official Website     : www.quaintpark.com
 * ------------------------------------------------------------------------------
 * Developed By         : Jeshad Khan
 * Profile              : https://github.com/JeshadKhan
 * ------------------------------------------------------------------------------
 * Title                : Quaint Style
 * Version              : 1.0
 * License              : Licensed under MIT <http://opensource.org/licenses/MIT>
*/



/*--- BEGIN ---*/



jQuery(function($) {

    /*--- QuaintPark Title ---*/

    $(window).load(function () {
        var words = $('#text-quaintpark-title').text().split(' ');
        var html = '';
        $.each(words, function () {
            html += '<span style="font-family: \''+'Algerian'+'\', arial;">' + this.substring(0, 1) + '</span>' + this.substring(1) + ' ';
        });
        $('#text-quaintpark-title').html(html);
    });



    /*--- Go Back To Top Button ---*/

    // show or hide the sticky footer
    $(window).scroll(function () {
        if ($(this).scrollTop() > 20) {
            $('.back-to-top').fadeIn(500);
        }
        else {
            $('.back-to-top').fadeOut(700);
        }
    });
    // animate the scroll to top
    $('.back-to-top').click(function (event) {
        event.preventDefault();
        $('HTML, body').animate({ scrollTop: 0 }, 800);
    });



    /*--- Date & Time ---*/

    function getTwoDigitNumber(num) {
        // make the number two digit number if single
        if (num < 10) {
            num = "0" + num;
        }

        return num;
    }
        
    setInterval(function () {
        var date = new Date();

        // get the current hours, minutes and seconds
        var hours = date.getHours();
        var minutes = date.getMinutes();
        var seconds = date.getSeconds();

        // set the am, pm value
        var ampm = "AM";
        if (hours > 11) {
            ampm = "PM";
        }

        // make the time 12 hour format
        if (hours == 00) {
            hours = 12;
        }
        else if (hours > 12) {
            hours -= 12;
        }

        // get two digit number if the number is single
        hours = getTwoDigitNumber(hours);
        minutes = getTwoDigitNumber(minutes);
        seconds = getTwoDigitNumber(seconds);

        // set the current time to the control
        var currentTime = hours + ":" + minutes + ":" + seconds + " " + ampm;
        $('.current-time').text(currentTime);

        // set the current date to the control
        var currentDate = date.toDateString();
        $('.current-date').text(currentDate);

        // set the current local date to the control
        var currentDateLocal = date.toLocaleDateString();
        $('.current-date-local').text(currentDateLocal);
    }, 1000);
        
});



/*--- FINISH ---*/
