var addCommentBtn = document.querySelectorAll('.add-comment-btn');
var commentBox = document.querySelectorAll('.add-comment-box');
var closeCommentBtn = document.querySelectorAll(".close-comment-box");


for (const btn of addCommentBtn) {

    btn.addEventListener("click", function () {
        var btnId = btn.getAttribute("data-id");

        for (const box of commentBox) {
            var boxId = box.getAttribute("data-target");

            if (btnId == boxId) {
                box.classList.add("comment-box-opened")
            }
        }
    });
}

for (const closeBtn of closeCommentBtn) {

    closeBtn.addEventListener("click", function () {
        for (const box of commentBox) {
            if (box.classList.contains("comment-box-opened")) {
                box.classList.remove("comment-box-opened")
            }
        }
    });
}

