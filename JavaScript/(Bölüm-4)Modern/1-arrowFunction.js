// ES5
var salamlaES5 = function(){
    console.log("salamES5");
}
salamlaES5()
function toplaES5(a,b){
    return a+b;
}
console.log(toplaES5(1,2))


// ES6
const salamlaES6 = () => console.log("salamES6")
salamlaES6()

// let toplaES6 = (a,b) => a+b;
                                                // birden cox setr istifade olunursa
let toplaES6 = (a,b) => {return a+b};
console.log(toplaES6(5,10))