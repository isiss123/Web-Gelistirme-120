import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';
import { ProductComponent } from './product.component';
import { SummaryPipe } from './summary.pipe';
import { InputTextDirective } from './input-text.directive';
import { AdminProductsComponent } from './admin-products/admin-products.component';



@NgModule({
  declarations: [
    ProductComponent,
    SummaryPipe,
    InputTextDirective,
    AdminProductsComponent
  ],
  imports: [
    BrowserModule,
    FormsModule
  ],
  providers: [],
  bootstrap: [ ProductComponent ]
})
export class AppModule { }
