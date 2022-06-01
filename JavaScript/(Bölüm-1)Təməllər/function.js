function yas_hesaplama(dogumIli){
    return new Date().getFullYear() - dogumIli;
}

function emekli(dogumIli,ad){
    let yas = yas_hesaplama(dogumIli);
    let qalanil = 65 - yas;
    if(qalanil > 0){
        console.log(`${ad}, ölməyinizə ${qalanil} il qalıb.`);
    }
    else{
        console.log(`${ad}, bekar onsuzda ölmüsən.`)
    }
}
emekli(1990,"isi");