reqemler = [2,3,4,5,6,7,8,9];
tekreqemlerES5 = [];
mehsulES5 = []

mehsullar = [
    {ad:"Axot 1",sinif:1},
    {ad:"Axot 2",sinif:2},
    {ad:"Axot 3",sinif:3},
    {ad:"Axot 4",sinif:4},
    {ad:"Axot 5",sinif:5}
]

// ES5
for(let reqemES5 of reqemler){
    if(reqemES5 %2 ==1){
        tekreqemlerES5.push(reqemES5)
    }
}
console.log(tekreqemlerES5)
for(let mehsul of mehsullar){
    if(mehsul.sinif >2){
        mehsulES5.push(mehsul.ad)
    }
}
console.log(mehsulES5)


                // ES6
// const tekreqemlerES6 = reqemler.filter(reqemES6=>reqemES6%2==1)
// const tekreqemlerES6 = reqemler.map(reqemES6=>reqemES6%2==1)
// console.log(tekreqemlerES6)

var cavab;
// cavab = mehsullar.map((mehsul) => mehsul.ad)

// cavab = mehsullar.filter(mehsul => mehsul.sinif >2)
// cavab = cavab.map(mehsul => mehsul.ad)
// cavab = mehsullar.filter(mehsul => mehsul.sinif >2).map(mehsul => mehsul.ad)

// tek bir elementi secmek ucun
// cavab = mehsullar.find(mehsul => mehsul.sinif >2)
// cavab = mehsullar.findIndex(mehsul =>mehsul.sinif >3)

console.log(cavab)

