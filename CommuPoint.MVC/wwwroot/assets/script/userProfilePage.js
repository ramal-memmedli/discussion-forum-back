$(document).ready(function () {

    var profileCard = $(".profile-card");
    var userProfileHeader = $("#userProfileHeader")

    profileCard.css("display", "flex")
        .hide();

    $(window).scroll(function () {
        if ($(this).scrollTop() <= 360) {
            profileCard.slideUp('fast');
            userProfileHeader.fadeTo(0, 1)
        }

        if ($(this).scrollTop() > 360) {
            profileCard.slideDown('fast');
            userProfileHeader.fadeTo(0, 0)
        }

    });
})

