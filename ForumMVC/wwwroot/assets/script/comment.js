var addCommentBtn = document.getElementById('addComment');
var closeCommentBoxBtn = document.getElementById('closeCommentBox');
var commentBox = document.getElementById('addCommentBox');

addCommentBtn.addEventListener("click", function(){
    commentBox.classList.toggle('comment-box-opened');
});

closeCommentBoxBtn.addEventListener("click", function(){
    if(commentBox.classList.contains('comment-box-opened')){
        commentBox.classList.remove('comment-box-opened');
    }
});