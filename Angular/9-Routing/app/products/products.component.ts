import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { products } from '../products';

@Component({
  selector: 'app-products',
  templateUrl: './products.component.html',
  styleUrls: ['./products.component.css']
})
export class ProductsComponent implements OnInit {
  products = products
  constructor(private router: Router, private route: ActivatedRoute) { }

  ngOnInit(): void {
    // query paramps
    this.route.queryParamMap.subscribe(prem=>{
      console.log(prem)
    })
    let page = this.route.snapshot.queryParamMap.get('page')
  }
  loadProducts(){
    this.router.navigate(['products'],{
      queryParams:{
        page: 1
      }
    })
  }

}
