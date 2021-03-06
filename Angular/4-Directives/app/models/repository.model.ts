import { SimpleDataSource } from "./datasource.model";
import { Product } from "./product.model";

export class ProductRepository{
    private dataSource: SimpleDataSource
    private products: Product[]
    constructor(){
        this.dataSource = new SimpleDataSource();
        this.products = new Array<Product>();
        this.dataSource.getProducts().forEach(p=>this.products.push(p))
    }

    getProducts(): Product[]{ 
        return this.products
    } 
    getProductById(id: number): any{
        return this.products.find(p=>p.id == id)
    }
    getLength():number{
        return this.products.length
    }

    addProduct(p: Product){
        this.products.push(p);
    }
    deleteProduct(product: Product){
        let index = this.products.indexOf(product);
        this.products.splice(index,1)
    }
}