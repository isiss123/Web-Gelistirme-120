import { keyframes } from "@angular/animations";
import { Component } from "@angular/core";
import { NgForm } from "@angular/forms";
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


    formSumbited: boolean = false;
    submitForm(form: NgForm){
        console.log(form)
        this.formSumbited = true;
        if(form.valid == true){
            this.addProduct(this.newProduct);
            this.newProduct = new Product();
            form.reset();
            this.formSumbited = false;
        }
    }

    // getFormValidationErrors(form: NgForm): string[]{
    //     let messages: any;
    //     Object.keys(form.controls).forEach(k=>{
    //         console.log(k); 
    //         console.log(form.controls[k].errors);
    //         messages.push(form.controls[k].errors)
    //     })
    //     return messages
    // }

}