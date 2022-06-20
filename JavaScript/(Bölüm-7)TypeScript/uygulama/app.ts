import { Product } from './product';
import { Service } from './service'

let _service = new Service()

let result;

let p = new Product();
// p.id= 2
// p.name = 'Axot 6';
// p.category = 'Bekar 6'
// p.price = 6000;
// _service.addProduct(p)


// result = _service.getProduct()

result = _service.getById(2)

console.log(result)