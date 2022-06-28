import { Component } from "@angular/core";
import { ProductRepository } from "./models/repository.model";


@Component({
    selector:'app',
    templateUrl:'product.component.html',
    styleUrls:['product.component.css']
})
export class ProductComponent{
    model: ProductRepository = new ProductRepository();
    onSubmit($event: any){
        $event.stopPropagation(); // basqa click eventi gerceklestirme
        console.log($event)
        console.log("Button was clicked")
    }
    onDiv(){
        console.log("Div was clicked")
    }
}