// let toplam = 0;

// for(let i = 0; i <=10;i++){
//     toplam += i;
// }
// console.log("Toplam : " +toplam);

let sayilar = [1,0,6,9,20,31,45];
let axot = 0;
// for(let i = 0; i < sayilar.length; i++){
//     axot += sayilar[i];
// }
// console.log("Axot : " + axot);

// for(let a in sayilar){
//     console.log(a);
    
// }
// for(let a of sayilar){
//     axot += a;
// }
// console.log(axot);

let user = {
    "name" :"Istiqlal",
    "age"  : 16,
    "birth_year" : 2005
}
console.log(user.name);
for (let i in user){
    console.log(i);
    console.log(user[i]);
}