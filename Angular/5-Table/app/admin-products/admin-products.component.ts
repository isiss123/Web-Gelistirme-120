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



  ngOnInit(): void {
  }

}
