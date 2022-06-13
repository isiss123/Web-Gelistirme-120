/*
var p = new Promise(function(resolve, reject){
    if(false){
        resolve("success")
    }else{
        reject("error")
    }
})
p.then((a)=>{
    console.log(a)
}).catch((a)=>{
    console.log(a)
})
*/
/*
new Promise(function(resolve){
    setTimeout(function(){
        resolve(5)
    } ,1000)
    
}).then((a)=>{
    console.log(a)
    return a*a
}).then((a)=>{
    console.log(a)
    return a*a
}).then((a)=>{console.log(a)})
*/


let karne = true;
var a = new Promise(function(resolve,reject){
    if(karne == true){
        var tel = {
            "ad":"IPhone 14 Pro Max",
            "qiymet":"2800",
            "reng":"qara"
        }
        resolve(tel)
    }else{
        let error = new Error('Hecne yoxdur')
        reject(error)
    }
})
var tanitma = (phone) =>{
    mesagge = "Menim yeni telefonum " + phone.ad
    return Promise.resolve(mesagge)
}
var sual = () =>{
    a.then(tanitma)
    .then(i=>{console.log(i)})
    .catch((i)=>{console.log(i)})
}
sual()