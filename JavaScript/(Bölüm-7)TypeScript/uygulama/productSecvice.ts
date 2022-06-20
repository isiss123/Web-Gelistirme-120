import { Product } from "./product";
export interface productService{
    getById(id: number): Product,
    getProduct(): Array<Product>,
    addProduct(product: Product): void,
    removeProduct(product: Product): void
}