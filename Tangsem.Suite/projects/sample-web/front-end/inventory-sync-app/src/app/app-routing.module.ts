import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { StoreFrontComponent } from './pages/store-front/store-front.component';
import { AdminComponent } from './pages/admin/admin.component';
import { OrderListComponent } from './components/shopping-cart/order-list.component';
import { OrderDetailsComponent } from './components/shopping-cart/order-details.component';
import { OrderCustInfoComponent } from './components/shopping-cart/order-cust-info.component';
import { OrderProdInfoComponent } from './components/shopping-cart/order-prod-info.component';
import { DndDemoComponent } from './components/dnd-demo/dnd-demo.component';
import { EbayOrdersComponent } from './components/ebay-orders/ebay-orders.component';

const routes: Routes = [
  { path: '', pathMatch: 'full', redirectTo: 'store-front'},
  { path: 'dnd-demo', component: DndDemoComponent },
  { path: 'ebay-orders', component: EbayOrdersComponent },
  {
    path: 'store-front', component: StoreFrontComponent,
    children: [
      { path: '', redirectTo: 'order-list', pathMatch: 'full' },
      { path: 'order-list', component: OrderListComponent },
      { path: 'order-list/:orderId', component: OrderDetailsComponent,
        children: [
          {
            path: '', redirectTo: 'cust', pathMatch: 'full'
          },
          {
            path: 'cust', component: OrderCustInfoComponent
          },
          {
            path: 'prod', component: OrderProdInfoComponent
          }
        ]
      },

    ]
  },
  { path: 'admin', component: AdminComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
