import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { UsersComponent } from './users/users.component';
import { ProductsComponent } from './products/products.component';
import { HomeComponent } from './home/home.component';
import { NotfoundComponent } from './notfound/notfound.component';
import { ProductComponent } from './products/product/product.component';
import { EditProductComponent } from './products/edit-product/edit-product.component';
import { UserComponent } from './users/user/user.component';
import { LoginComponent } from './login/login.component';

const appRoutes: Routes = [
    {path:'',component: HomeComponent},
    {path: 'home', component: HomeComponent},
    {path: 'login', component: LoginComponent},
    {path: 'products', component: ProductsComponent, children:[
      {path: ':id', component: ProductComponent},
      {path: ':id/edit', component: EditProductComponent},
    ]},
  
    {path: 'users', component: UsersComponent, children:[
      {path: ':name', component: UserComponent},
    ]},
  
    {path:'**', component: NotfoundComponent}
  ]

@NgModule({
    imports:[
        RouterModule.forRoot(appRoutes)
    ],
    exports:[
        RouterModule
    ]
})
export class AppRoutingModule{}
