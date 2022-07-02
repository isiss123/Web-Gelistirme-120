import { Component, OnInit } from '@angular/core';
import { Product } from '../models/product.model';
import { ProductRepository } from '../models/repository.model';


@Component({
  selector: 'admin-products',
  templateUrl: './admin-products.component.html',
  styleUrls: ['./admin-products.component.css']
})

export class AdminProductsComponent implements OnInit {
  products;
  model: ProductRepository;
  selectedProduct: any;

  constructor() {
    this.model = new ProductRepository();
    this.products = this.model.getProducts()
  }
  getSelected(product: Product){
    return product == this.selectedProduct 
  }
  setProduct(product: Product){
    this.selectedProduct = product;
  }
  axot(value: any){
    return value.target.value
  }
  ekle( pName: any,pDescription: any,pUrl: any,pPrice: any){
    // this.selectedProduct.name = pName
    // this.selectedProduct.description = pDescription
    // this.selectedProduct.imageUrl = pUrl
    // this.selectedProduct.price = pPrice
    const p = this.model.getProductById(this.selectedProduct.id)
    p.name = pName;
    p.description = pDescription;
    p.imageUrl = pUrl;
    p.price = pPrice;
    this.selectedProduct = null;
  }


  ngOnInit(): void {
  }

}
