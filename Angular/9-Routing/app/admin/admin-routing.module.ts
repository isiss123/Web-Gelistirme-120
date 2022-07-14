import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AurhGuard } from '../auth-guard.service';

import { AdminCategoriesComponent } from './admin-categories/admin-categories.component';
import { AdminProductsComponent } from './admin-products/admin-products.component';
import { AdminComponent } from './admin/admin.component';

const routes: Routes = [
  {path:'admin', component: AdminComponent,
    canActivate: [AurhGuard],
    children:[{
    path:'',children:[
      {path:'products',component: AdminProductsComponent},
      {path:'categories', component: AdminCategoriesComponent}
    ]
  }]
}
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class AdminRoutingModule { }
