import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { StoreFrontComponent } from './pages/store-front/store-front.component';
import { AdminComponent } from './pages/admin/admin.component';
import { ProductListComponent } from './components/products/product-list.component';
import { ProductDetailsComponent } from './components/products/product-details.component';
import { OrderListComponent } from './components/shopping-cart/order-list.component';
import { OrderDetailsComponent } from './components/shopping-cart/order-details.component';
import { OrderCustInfoComponent } from './components/shopping-cart/order-cust-info.component';
import { OrderProdInfoComponent } from './components/shopping-cart/order-prod-info.component';
import {BrowserAnimationsModule} from '@angular/platform-browser/animations';
import { MaterialModule } from './material-module';
import { HttpClientModule } from '@angular/common/http';
import { DndDemoComponent } from './components/dnd-demo/dnd-demo.component';
import { EbayOrdersComponent } from './components/ebay-orders/ebay-orders.component';
import { EbayOrderCellComponent } from './components/ebay-orders/ebay-order-cell.component';

@NgModule({
  declarations: [
    AppComponent,
    StoreFrontComponent,
    AdminComponent,
    ProductListComponent,
    ProductDetailsComponent,
    OrderListComponent,
    OrderDetailsComponent,
    OrderCustInfoComponent,
    OrderProdInfoComponent,
    DndDemoComponent,
    EbayOrdersComponent,
    EbayOrderCellComponent,
  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    MaterialModule,
    AppRoutingModule,

    HttpClientModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule {
  constructor() {
  }
}
