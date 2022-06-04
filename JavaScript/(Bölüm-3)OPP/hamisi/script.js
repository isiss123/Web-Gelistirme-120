btn_start.addEventListener("click", function(){
    document.querySelector(".quiz_box").classList.add("active");
    sualGoster(quiz.sualGetir())
    btn_next.classList.remove("show");
    clearInterval(counter);
    clearInterval(counterLine);
    startTimer(10);
    startTimerLine()
});

btn_quit.addEventListener("click", function(){
    window.location.reload();
});

btn_reload.addEventListener("click", function(){
    quiz.sualIndex = 0;
    quiz.DogruCavabSayi = 0;
    btn_start.click();
    document.querySelector(".score_box").classList.remove("active");    
})
