import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { CustomerListingComponent } from './components/customer/customer-listing.component';
import { CustomerEditorComponent } from './components/customer/customer-editor.component';

import { StoreListingComponent } from './components/store/store-listing.component';
import { StoreEditorComponent } from './components/store/store-editor.component';

import { OrderListingComponent } from './components/order/order-listing.component';
import { OrderEditorComponent } from './components/order/order-editor.component';

import { ProductListingComponent } from './components/product/product-listing.component';
import { ProductEditorComponent } from './components/product/product-editor.component';

import { PosListingComponent } from './components/pos/pos-listing.component';
import { PosEditorComponent } from './components/pos/pos-editor.component';


import { ExtendedRoute } from '../models/extended-route';

export const routes: ExtendedRoute[] = [

	{ path: 'customer/:customerId/:action', component: CustomerEditorComponent, hideFromMenuItem: true },
	{ path: 'customer/listing', component: CustomerListingComponent },
	{ path: 'customer/create', component: CustomerEditorComponent },

	{ path: 'store/:id/:action', component: StoreEditorComponent, hideFromMenuItem: true },
	{ path: 'store/listing', component: StoreListingComponent },
	{ path: 'store/create', component: StoreEditorComponent },

	{ path: 'order/:id/:action', component: OrderEditorComponent, hideFromMenuItem: true },
	{ path: 'order/listing', component: OrderListingComponent },
	{ path: 'order/create', component: OrderEditorComponent },

	{ path: 'product/:id/:action', component: ProductEditorComponent, hideFromMenuItem: true },
	{ path: 'product/listing', component: ProductListingComponent },
	{ path: 'product/create', component: ProductEditorComponent },

	{ path: 'pos/:id/:action', component: PosEditorComponent, hideFromMenuItem: true },
	{ path: 'pos/listing', component: PosListingComponent },
	{ path: 'pos/create', component: PosEditorComponent },


]


@NgModule({
  imports: [RouterModule.forChild(routes)],
  declarations: [
  ],
  exports: [RouterModule]
})
export class GeneratorTestRepositoryRoutingModule {
}