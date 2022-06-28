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
    product: Product = this.model.getProductById(1);

}