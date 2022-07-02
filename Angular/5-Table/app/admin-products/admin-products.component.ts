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
  a:any
  model: ProductRepository;
  selectedProduct: any;

  constructor() {
    this.model = new ProductRepository();
    this.products = this.model.getProducts()
  }
  getSelected(product: Product){
    return this.selectedProduct == product.name
  }
  axot(value: any){
    return value.target.value
  }
  ngOnInit(): void {
  }

}
