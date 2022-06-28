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
    disabled = true;
    getClasses(id: number): string{
        let product = this.model.getProductById(id);
        return (product.price <=2000 ? "bg-warning" : "bg-danger") + " p-2 m-2 text-white text-center"
    }
    getClassMap(id: number): Object{
        let product = this.model.getProductById(id);
        return {
            "bg-primary": product.price<=1000,
            "bg-black text-white": product.price>= 5000,
            "text-center text-primary": product.name == "Axot 4"
        }
    }

}