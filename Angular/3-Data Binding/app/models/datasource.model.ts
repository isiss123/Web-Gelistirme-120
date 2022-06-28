import { Product } from "./product.model";

export class SimpleDataSource{
    private products: Product[];
    constructor(){
        this.products = new Array<Product>(
            new Product(1,"Axot 1","Bekar 1","1.jpg",1000),
            new Product(2,"Axot 2","Bekar 2","2.jpg",2000),
            new Product(3,"Axot 3","Bekar 3","3.jpg",3000),
            new Product(4,"Axot 4","Bekar 4","4.jpg",4000),
            new Product(5,"Axot 5","Bekar 5","5.jpg",5000)
        )
    }
    getProducts(): Product[]{
        return this.products
    }

}