
// 10 - 50 arasinda
var sayi_1 = 20;
if((sayi_1 > 10) && (sayi_1 < 50)){
    console.log("10-50 arasindadir");
}
else{
    console.log("10-50 arasinda deyil");
}

// Cut veya Tek oldugu  Math.abs menfi cavabi musbete cevirir
var sayi_2 = 25;
if(Math.abs(sayi_2%2) == 0){
    console.log("Sayi cutdur");
}
else{
    console.log("Sayi tekdir");
}