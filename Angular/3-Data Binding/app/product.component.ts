import { Component } from "@angular/core";
import { ProductRepository } from "./models/repository.model";


@Component({
    selector:'app',
    templateUrl:'product.component.html',
    styleUrls:['product.component.css']
})
export class ProductComponent{
    axot = "Axot Bekar";
    today: number =  Date.now();
    n: number  = 123456
    p: number = 395.956
    c: number = 0.26
}