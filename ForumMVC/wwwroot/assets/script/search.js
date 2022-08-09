var searchBtn = document.getElementById('searchBtn');
var searchArea = document.getElementById('searchArea');

searchBtn.addEventListener("click", function(){
    searchArea.classList.toggle("search-area-opened");
});