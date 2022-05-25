// 1 - sozu bildirilen qeder ekrana yazan 
function axot(soz,eded){
    for(let i=0; i<eded;i++){
        console.log(i+1 +". "+ soz);
    };
};
// axot("salam",4);


// 2 - duzbucaqlinin sahesini ve perimetrini hesapla
function duzbucaq(teref_1,teref_2){
    let p = (teref_1 + teref_2) *2;
    let s = teref_1 * teref_2
    console.log("Perimetr : " +p);
    console.log("Sahe : " +s);
};
// duzbucaq(3,5);


// 3 - girilen ededin tam bolenlerini list tipinde gonderen
function bolenSayi(reqem){
    let list =[];
    for(let i=2 ; i<reqem;i++){
        if(reqem%i==0){
            list.push(i);
        }
    }
    return list;
}
// console.log(bolenSayi(35));


// 4 - yazi sekil 
function yazi_sekil(){
    let rand = Math.round(Math.random()*5)+1;
    if(rand > 3){
        console.log("yazi");
    }else{
        console.log("sekil");
    }
    console.log(rand);
}
// yazi_sekil();


// 5 - muxtelif sayida parametr alan 
function toplam(){
    let cavab = 0;
    for(let i=0; i<arguments.length; i++){
        cavab += arguments[i];
    }
    return cavab;
}
console.log(toplam(1,2,3,4));
console.log(toplam(1,2,3,4,5,6));