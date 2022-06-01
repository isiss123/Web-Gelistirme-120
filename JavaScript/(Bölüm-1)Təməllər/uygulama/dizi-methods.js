let fruits = ["apple","pear","banana","strawberry"];
let result;

// Kac elemanli
console.log(fruits.length);

// ilk ve son eleman
console.log(fruits[0]);
console.log(fruits[fruits.length-1]);

// Apple elemanmi
console.log(fruits.includes("apple"));

// cherry son elemana ekle
fruits.push("cherry");
console.log(fruits);

// son 2 elemani sil
result = fruits.splice(fruits.length-2,2);


let sg_1 = ["Bekar","Axot",2010,[70,60,80]];
let sg_2 = ["Bekar","Axot",2012,[80,80,90]];
let sg_3 = ["Bekar","Axot",2009,[60,60,70]];

let indi = new Date();
let il = indi.getFullYear();

cavab_1 = il - sg_1[2];
let cavab_1_ort = (sg_1[3][0] + sg_1[3][1] + sg_1[3][2])/3;

cavab_2 = il - sg_2[2];
let cavab_2_ort =parseInt((sg_2[3][0] + sg_2[3][1] + sg_2[3][2])/3);

cavab_3 = il - sg_3[2];
let cavab_3_ort =parseInt((sg_3[3][0] + sg_3[3][1] + sg_3[3][2])/3);


console.log(`yas : ${cavab_1}, ort: ${cavab_1_ort}`);
console.log(`yas : ${cavab_2}, ort: ${cavab_2_ort}`);
console.log(`yas : ${cavab_3}, ort: ${cavab_3_ort}`);

console.log(result);
console.log(fruits);