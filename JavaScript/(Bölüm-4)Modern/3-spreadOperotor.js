let msg = ["Axotsuz","Bekar","Axot","Yoxdu"]
let e1 = ["bir","iki"]
let e2 = ["uc","dort"]

// ES5
// msgES5 = "";
// for(let x of msg ){
//     msgES5 += x +" ";
// }
// console.log(msgES5)
// let e3ES5 = [e1,e2]
// console.log(e3ES5)


// ES6 
// console.log(...msg)

// let e3ES6 = [...e1,...e2]
// console.log(e3ES6)



////////////////////////////////
// let sa1 = [1,2,3,4,5]
// // let sa2 = sa1   //REFERANS kopyalama :: SA1 de reqem deyisende SA2 dede deyisir
// let sa2 = [...sa1] //VALUE kopyalama   :: SA1 de reqem deyisende SA2 dede deyismir

// sa1[0] = 10
// console.log(sa1,sa2)



////////////////////////////////
// const user = {
//     username: "axot",
//     email:"axotsuzBekar@gmail"
// }
// const address = {
//     username: "behar",
//     city: "Baki"
// }
// console.log({...user,...address})   //ikinci gelen USERNAME 1.-i ezdi


//rest parametres

const toplaES6 = (...args) =>{
    let cavab = 0;
    for(let reqem of args){
        cavab += reqem
    }return cavab;
}


console.log(toplaES6(1,2,3,4,5))
console.log(toplaES6(10,20,30,40))