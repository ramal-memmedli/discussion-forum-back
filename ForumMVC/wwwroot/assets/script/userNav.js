var headerUsers = document.querySelectorAll('.header-user');
var userNav = document.getElementById('userNav');

for (const headerUser of headerUsers) {
    headerUser.addEventListener("click", function(){
        userNav.classList.toggle('user-nav-opened');
    });
}
