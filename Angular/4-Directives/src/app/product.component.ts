import { Component } from "@angular/core";
import { Product } from "./models/product.model";
import { ProductRepository } from "./models/repository.model";


@Component({
    selector:'app',
    templateUrl:'product.component.html',
    styleUrls:['product.component.css']
})
export class ProductComponent{
    model: ProductRepository = new ProductRepository();
    addProduct(){
        this.model.addProduct(new Product(6,"Axot 6","Bekar 6","5.jpg",6000))
    }

    deleteProduct(product: Product){
        this.model.deleteProduct(product)
    }
    updateProduct(product: Product){
        product.name = 'updated'
    }
}