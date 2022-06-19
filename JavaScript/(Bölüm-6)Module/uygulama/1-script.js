pros = [
    {ad:"Axot 1"},
    {ad:"Axot 2"},
    {ad:"Axot 3"},
    {ad:"Axot 4"},
]

var Module = (function(data){
    const products =data || [];
    var addProduct = (product) =>{
        products.push(product)
    }
    var removeProduct = (product) =>{
        let index = products.indexOf(product)
        if(index>=0){
            products.splice(index,1)
        }
    }
    var getProduct = () =>{
        return products;
    }
    return{
        removeProduct,
        addProduct,
        getProduct
    }
})(pros)

Module.addProduct(pros[0]);
Module.addProduct(pros[1]);
Module.addProduct(pros[2]);
Module.removeProduct(pros[1])
console.log(Module.getProduct());


// Module extenting (Module genisletme)

var  extented = (function(m){
    m.sa=()=>{
        console.log('Salam')
    }

    return m
})(Module)
extented.sa()
console.log(extented.getProduct())