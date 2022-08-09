var hamburgerBtn = document.getElementById('hamburgerMenuBtn');
var hamburgerSpan = document.getElementsByClassName('hamburgerSpan');
var mobileNavbar = document.getElementById('mobileNavbar');
var darkLayer = document.getElementById('darkLayer');
var searchArea = document.getElementById('searchArea');
var userNav = document.getElementById('userNav');

hamburgerBtn.addEventListener("click", function(){
    for (let i = 0; i < hamburgerSpan.length; i++) {
        hamburgerSpan[i].classList.toggle('hamburgerSpanAnimated');
    }

    mobileNavbar.classList.toggle('mobile-navbar-open');
    darkLayer.classList.toggle('dark-layer-opened');
    if(searchArea.classList.contains('search-area-opened')){
        searchArea.classList.remove('search-area-opened');
    }

    if(userNav.classList.contains('user-nav-opened')){
        userNav.classList.remove('user-nav-opened');
    }
});

darkLayer.addEventListener("click", function(){
    if(mobileNavbar.classList.contains('mobile-navbar-open')){
        mobileNavbar.classList.remove('mobile-navbar-open');
        darkLayer.classList.remove('dark-layer-opened');
        for (let i = 0; i < hamburgerSpan.length; i++) {
            if(hamburgerSpan[i].classList.contains('hamburgerSpanAnimated')){
                hamburgerSpan[i].classList.remove('hamburgerSpanAnimated');
            }
        }
    }

    if(searchArea.classList.contains('search-area-opened')){
        searchArea.classList.remove('search-area-opened');
    }

    if(userNav.classList.contains('user-nav-opened')){
        userNav.classList.remove('user-nav-opened');
    }
});