// 1)global variable naming conflicts(qlobal degisken adlandirmalari)
// var name = 'Axot 1';

// var name = 'Axot 2'
// // console.log(name)

// // 2)encapsulation (kapsulleme)
// var numbers = {
//     number : 0,
//     artir : function(){
//         return ++this.number
//     },
//     azalt : function(){
//         return --this.number 
//     }
// }
// console.log(numbers.artir())
// numbers.number = 10;
// console.log(numbers.azalt())

// IIFE
// 1)
(function(){
    var name = 'Axot 1'
    console.log(name)
})();
(function(){
    var name = 'Axot 2'
    console.log(name)
})();

// 2)
var Module = (function(){
    // private
    var number = 0;
    artirma =()=>{
        return ++number;
    }
    azaltma =()=>{
        return --number;
    }
    goster=()=>{
        return number
    }
    
    return{
        // global
        artirma,
        azaltma,
        goster
    }
})();
console.log(Module.artirma())
Module.artirma()
console.log(Module.artirma())