import { Component } from "@angular/core";
import { FormControl, FormGroup } from "@angular/forms";


@Component({
    selector:'app',
    templateUrl:'product.component.html',
    styleUrls:['product.component.css']
})
export class ProductComponent{
    productForm = new FormGroup({
        name: new FormControl('Axot 1'),
        description: new FormControl('Bekar 1'),
        image: new FormControl('1.png'),
        price: new FormControl(1000)
    });
   
    onSubmit(){
        console.log(this.productForm.value)
    }
    updateProduct(){
        this.productForm.patchValue({
            name: "Axot 111",
            price: 22200
        })
    }

}