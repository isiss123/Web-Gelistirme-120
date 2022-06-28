import { Component } from "@angular/core";
import { ProductRepository } from "./models/repository.model";


@Component({
    selector:'app',
    templateUrl:'product.component.html',
    styleUrls:['product.component.css']
})
export class ProductComponent{
    // agot($event: any){
    //     if($event.keyCode == 13){
    //         console.log("Enter was pressed")
    //     }
    // }
    agot(a: any){
        console.log(a)
        console.log("Enter was pressed")
    }
}