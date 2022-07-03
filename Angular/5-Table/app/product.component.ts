import { Component, ModuleWithComponentFactories } from "@angular/core";
import { Product } from "./models/product.model";
import { ProductRepository } from "./models/repository.model";


@Component({
    selector:'app',
    templateUrl:'product.component.html',
    styleUrls:['product.component.css']
})
export class ProductComponent{
    model: ProductRepository = new ProductRepository();

    newProduct: Product = new Product();

    get jsonProduct(){
        return JSON.stringify(this.newProduct)
    }
    addProduct(p: Product){
        console.log("New Product "+ this.jsonProduct)
    }
    log(x:any){
        console.log(x)
    }

    submitForm(form: any){
        console.log(form)
    }

}