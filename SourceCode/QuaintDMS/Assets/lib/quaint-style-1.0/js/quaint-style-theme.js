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



/*--- User Greeting ---*/

function getGreeting() {
    // the greeting pitcher (variable)
    var greeting;

    // get time
    var date = new Date();
    var hours = date.getHours();

    // check the part of day
    if (hours >= 4 && hours < 12) {
        greeting = "Good Morning!";
    }
    else if (hours >= 12 && hours < 16) {
        greeting = "Good Noon!";
    }
    else if (hours >= 16 && hours < 18) {
        greeting = "Good Afternoon!";
    }
    else if (hours >= 18 && hours < 20) {
        greeting = "Good Evening!";
    }
    else {
        greeting = "Good Night!";
    }

    // return the greeting
    return greeting;
}

function getDefaultGreeting(userName) {
    // get greetings
    var greeting = getGreeting();

    // show the greeting with normal js alert
    alert("Hey\n" + userName + ".\n" + greeting);
}

function getSweetAlertGreeting(userNameSwal) {
    // get greetings
    var greeting = getGreeting();

    // show the greeting with sweet alert
    swal({
        customClass: 'swal-greeting',
        title: 'Hey<br />' + userNameSwal,
        text: '<span style="font-weight: bold;">' + greeting + '</span>',
        html: true
    });
}

jQuery(function($) {    

    $(window).load(function () {
        // get the user name by the class called: "user-name"
        var userName = $('.user-name').text();

        // get the user name with sweet alert flag by the class called: "user-name-swal"
        var userNameSwal = $('.user-name-swal').text();

        if (userName != "") {
            getDefaultGreeting(userName);
        }
        else if (userNameSwal != "") {
            getSweetAlertGreeting(userNameSwal);
        }
    });

});



/*--- FINISH ---*/
