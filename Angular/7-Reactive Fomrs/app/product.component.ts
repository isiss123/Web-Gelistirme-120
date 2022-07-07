import { Component } from "@angular/core";
import { FormControl } from "@angular/forms";


@Component({
    selector:'app',
    templateUrl:'product.component.html',
    styleUrls:['product.component.css']
})
export class ProductComponent{
    name = new FormControl('Axot 1');
    description = new FormControl('Bekar 1');
    image = new FormControl('1.png');
    price = new FormControl(1000)


    updateName(){
        this.name.setValue('Axot 111')
    }
}