import { Data } from "./data";
import { Product } from "./product";
import { productService } from "./productSecvice";

export class Service implements productService{
    private data: Data;
    private products: Array<Product>;
    constructor(){
        this.data = new Data();
        this.products = new Array<Product>();
        this.data.getProduct().forEach(p=>{this.products.push(p)})
    }
    getById(id: number): Product {
        return this.products.filter(p=>p.id===id)[0];
    }
    getProduct(): Product[] {
        return this.products
    }
    addProduct(product: Product): void {
        if(product.id == 0 || product.id == null){
            product.id = this.generateId()
            this.products.push(product)
        }else{
            let index;
            for(let i =0; i<this.products.length; i++){
                if(this.products[i].id==product.id){
                    index = i
                }
            }
            this.products.splice(index,1,product)
        }
    }
    removeProduct(product: Product): void {
        let index = this.products.indexOf(product)
        if(index>0){
            this.products.splice(index,1)
        }
    }

    private generateId(): number{
        let key = 1;
        while(this.getById(key) != null){
            key += 1;
        }
        return key
    }

}