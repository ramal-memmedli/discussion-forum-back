var switchBtn = document.getElementById("switch");
var switchBox = document.querySelector("#switch input");

var darkMode = localStorage.getItem('darkMode');

if(darkMode === null) {
    if (window.matchMedia && window.matchMedia('(prefers-color-scheme: dark)').matches) {
        document.body.classList.add('dark-mode');
        switchBox.checked = true;
    }
}

if(darkMode == '1'){
    document.body.classList.add('dark-mode');
    switchBox.checked = true;
}

switchBtn.addEventListener("change", () => {
    changeInterfaceMode();
});

function changeInterfaceMode() {
    if(document.body.classList.contains('dark-mode')){
        localStorage.setItem('darkMode', '0');
        document.body.classList.remove('dark-mode');
    }else {
        localStorage.setItem('darkMode', '1');
        document.body.classList.add('dark-mode');
    }
}