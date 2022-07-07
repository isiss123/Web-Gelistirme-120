import { Component } from "@angular/core";
import { FormControl, FormGroup, Validators } from "@angular/forms";
import { ImageValidators } from "./image.validators";


@Component({
    selector:'app',
    templateUrl:'product.component.html',
    styleUrls:['product.component.css']
})
export class ProductComponent{
    productForm = new FormGroup({
        name: new FormControl('',
        [Validators.required, Validators.minLength(5),Validators.maxLength(10)]),
        description: new FormControl('',
        Validators.required),
        image: new FormControl('',
        [Validators.required, ImageValidators.isValidExtention]),
        price: new FormControl(Number(''),
        Validators.required)
    });
    get name(){
        return this.productForm.get('name');
    }
    get image(){
        return this.productForm.get('image');
    }
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