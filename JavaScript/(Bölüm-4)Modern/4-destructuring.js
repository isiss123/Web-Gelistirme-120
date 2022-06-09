// Array  destructuring

// const user = ["Axotsuz","Bekar","Baki","Ehmedli"]
// const user1 = "Axotsuz Bekar"
// let [a,b] = user1.split(" ");
// // let [a,b,...c] = user;

// console.log(a,b)
// // console.log(a,b,c)


//Object destructuring

let axot = {
    a:"Axot",
    b:"Bekar",
    d:true
    
}
// // // //   = ... DEFAULT deyer eger nesneden deyer gelmese istifade olunur
// let{a,b,c,d=false}= axot
// console.log(a,b,c,d)
let axots = (obj) =>{
    let{a,b,c=0,d=false}= obj
    console.log(a,b,c,d)
}
axots(axot)

