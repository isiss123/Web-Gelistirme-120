function optionSelected(option){
    clearInterval(counter);
    clearInterval(counterLine);
    let cavab = option.querySelector("span b").textContent;
    let sual = quiz.sualGetir();
    if(sual.sualCavabYoxlama(cavab) == true){
        console.log("dogru")
        option.classList.add("correct");
        option.insertAdjacentHTML("beforeend",correctIcon);
        quiz.DogruCavabSayi += 1;
    }
    else{        
        option.classList.add("incorrect");
        option.insertAdjacentHTML("beforeend",incorrectIcon);
        
    }
    for(let i = 0 ; i < option_list.children.length; i++){
        option_list.children[i].classList.add("disabled");
    }
    btn_next.classList.add("show");
}


//NOVBETI SUAL
function next_question(){
    clearInterval(counter);
    clearInterval(counterLine);
    if(quiz.suallar.length != quiz.sualIndex + 1){
        quiz.sualIndex +=1;
        sualGoster(quiz.sualGetir());
        btn_next.classList.remove("show");
        sualSayiniGoster(quiz.sualIndex + 1, quiz.suallar.length);
        startTimer(10);
        startTimerLine();
    }else{
        console.log("Sual bitdi");
        document.querySelector(".quiz_box").classList.remove("active");
        document.querySelector(".score_box").classList.add("active");
        score_table(quiz.suallar.length,quiz.DogruCavabSayi);
    }
}


// SUAL SAYINI GOSTERME
function sualSayiniGoster(sualsira,toplamSaul){
    let tag = `<span class="bg-warning badge">${sualsira} / ${toplamSaul}</span>`
    document.querySelector(".quiz_box .card-footer .question_index").innerHTML = tag;
}

//SCORE TABLE
function score_table(toplamSaul,dogruCavab){
    let tag = `Toplam ${toplamSaul} sualdan ${dogruCavab} suala duzgun cavab verdiniz`
    document.querySelector(".score_box .score_text").textContent = tag;
}

//TIMER
let counter;
function startTimer(time){
   counter =  setInterval(timer,1000);
    function timer(){
        timer_second.textContent = time;
        time--;
        if(time<0){
            clearInterval(counter);
            timer_text.textContent = "Vaxt Bitdi";
            let cavab = quiz.sualGetir().sualDogruCavab
            console.log(cavab);
            for(let option of option_list.children){
               if(option.querySelector("span b").textContent == cavab){
                option.classList.add("correct");
                option.insertAdjacentHTML("beforeend",correctIcon);
               }
                option.classList.add("disabled")
                btn_next.classList.add("show")
            }
        }

    } 
}

let counterLine;
function startTimerLine(){
    let line_width = 0;
    counterLine = setInterval(timer,20)
    function timer(){
        line_width += 1;
        timer_line.style.width = line_width +"px";
        if(line_width>548){
            clearInterval(counterLine);
        }
    }
    
}