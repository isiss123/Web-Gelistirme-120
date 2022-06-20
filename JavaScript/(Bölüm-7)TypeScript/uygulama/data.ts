import { Product } from "./product";

export class Data{
    products: Array<Product>;
    constructor(){
        this.products = Array<Product>(
            new Product(1,"Axot 1","Bekar 1",1000),
            new Product(2,"Axot 2","Bekar 2",2000),
            new Product(3,"Axot 3","Bekar 3",3000),
            new Product(4,"Axot 4","Bekar 4",4000),
        )
    }
    getProduct(): Product[]{
        return this.products
    }
}