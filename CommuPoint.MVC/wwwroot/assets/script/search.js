$(document).ready(function () {
    var searchBtn = $('#searchBar');
    var searchArea = $('#searchResult');

    searchBtn.on("focusin", function() {
        searchArea.addClass("search-area-opened")
    })

    searchBtn.on("focusout", function() {
        searchArea.removeClass("search-area-opened")
    })
})