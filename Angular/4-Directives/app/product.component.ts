import { Component } from "@angular/core";
import { ProductRepository } from "./models/repository.model";


@Component({
    selector:'app',
    templateUrl:'product.component.html',
    styleUrls:['product.component.css']
})
export class ProductComponent{
    axot = 'adjkajdkajdksjfkajfkajxcm,xmckfjajfajflkjowroiusfkljfl'
    model: ProductRepository = new ProductRepository();
}