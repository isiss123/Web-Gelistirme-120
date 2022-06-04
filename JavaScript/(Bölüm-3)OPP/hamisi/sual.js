function Sual(sualMetn,sualCavablar,sualDogruCavab){
    this.sualMetn = sualMetn,
    this.sualCavablar = sualCavablar,
    this.sualDogruCavab = sualDogruCavab
}
Sual.prototype.sualCavabYoxlama = function(sualVerilenCavab){
    return sualVerilenCavab == this.sualDogruCavab;
}

var suallar = [
    new Sual("1-Axot Yoxdu?",{a:"Var",b:"Yoxdu",c:"Belədə",d:"Heç nə"},"b"),new Sual("2-Axot Yoxdu?",{a:"a",b:"b",c:"c",d:"d"},"d"),new Sual("3-Axot Yoxdu?",{a:"Var",b:"Yoxdu",c:"Belədə",d:"Heç nə"},"c"),new Sual("4-Axot Yoxdu?",{a:"a",b:"b",c:"c"},"a"),
];
function Quiz(suallar){
    this.suallar = suallar,
    this.sualIndex = 0,
    this.DogruCavabSayi = 0
}
Quiz.prototype.sualGetir = function(){
    return this.suallar[this.sualIndex]
}
const quiz = new Quiz(suallar);
function sualGoster(sual){
    sualSayiniGoster(quiz.sualIndex + 1, quiz.suallar.length);
    let question = `<span>${sual.sualMetn}`
    let options = ''
    for(let cavab in sual.sualCavablar){
        options += `<div class="option"><span><b>${cavab}</b>) ${sual.sualCavablar[cavab]} </span></div>`
    }
    document.querySelector(".question_text").innerHTML = question;
    
    option_list.innerHTML = options
    const option = option_list.querySelectorAll(".option");
    for(let opt of option){
        opt.setAttribute("onclick","optionSelected(this)")
    }
}