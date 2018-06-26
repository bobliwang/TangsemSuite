import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ProductListingComponent } from './components/product/product-listing.component';
import { ProductEditorComponent } from './components/product/product-editor.component';

import { OrderListingComponent } from './components/order/order-listing.component';
import { OrderEditorComponent } from './components/order/order-editor.component';

import { PosListingComponent } from './components/pos/pos-listing.component';
import { PosEditorComponent } from './components/pos/pos-editor.component';


export const routes: Routes = [

	{ path: 'product/:id/:action', component: ProductEditorComponent },
	{ path: 'product/listing', component: ProductListingComponent },
	{ path: 'product/create', component: ProductEditorComponent },

	{ path: 'order/:id/:action', component: OrderEditorComponent },
	{ path: 'order/listing', component: OrderListingComponent },
	{ path: 'order/create', component: OrderEditorComponent },

	{ path: 'pos/:id/:action', component: PosEditorComponent },
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