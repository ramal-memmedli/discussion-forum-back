var switchBtn = document.getElementById("switch");
var switchBox = document.querySelector("#switch input");

switchBtn.addEventListener("change", () => {
    enableDarkMode();
});

if (window.matchMedia && window.matchMedia('(prefers-color-scheme: dark)').matches) {
    enableDarkMode();
    switchBox.checked = true;
}

function enableDarkMode() {
    document.body.classList.toggle('dark-mode');
}