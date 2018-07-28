import { HttpClient, HttpParams } from '@angular/common/http';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { Observable } from 'rxjs/Observable';
import * as models from './models/models';

import { CommonModule } from '@angular/common';
import { ErrorHandler, ModuleWithProviders, NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';


import {
	MatSnackBarModule, MatStepperModule, MatTabsModule, MatFormFieldModule, MatSelectModule, MatTableModule, MatSortModule, MatButtonModule, MatInputModule, MatAutocompleteModule, MatCheckboxModule, MatIconModule, MatPaginatorModule, MatDatepickerModule, MatNativeDateModule
} from '@angular/material';
import { GeneratorTestRepositoryApiService } from './services/api.service';

/************ AUTO GEN COMPONENTS **************/
import { CustomerFilterComponent } from './components/customer/customer-filter.component';
import { CustomerListingComponent } from './components/customer/customer-listing.component';
import { CustomerEditorComponent, CustomerDetailsDialog } from './components/customer/customer-editor.component';

import { StoreFilterComponent } from './components/store/store-filter.component';
import { StoreListingComponent } from './components/store/store-listing.component';
import { StoreEditorComponent, StoreDetailsDialog } from './components/store/store-editor.component';

import { OrderFilterComponent } from './components/order/order-filter.component';
import { OrderListingComponent } from './components/order/order-listing.component';
import { OrderEditorComponent, OrderDetailsDialog } from './components/order/order-editor.component';

import { ProductFilterComponent } from './components/product/product-filter.component';
import { ProductListingComponent } from './components/product/product-listing.component';
import { ProductEditorComponent, ProductDetailsDialog } from './components/product/product-editor.component';

import { PosFilterComponent } from './components/pos/pos-filter.component';
import { PosListingComponent } from './components/pos/pos-listing.component';
import { PosEditorComponent, PosDetailsDialog } from './components/pos/pos-editor.component';



import { GeneratorTestRepositoryRoutingModule } from './generatorTestRepository-routing.module';

@NgModule({
	imports: [
		CommonModule,
		ReactiveFormsModule,
		FormsModule,
		BrowserAnimationsModule,
        GeneratorTestRepositoryRoutingModule,

		MatSnackBarModule, MatStepperModule, MatTabsModule, MatFormFieldModule, MatSelectModule, MatTableModule, MatSortModule, MatButtonModule, MatInputModule, MatAutocompleteModule, MatCheckboxModule, MatIconModule, MatPaginatorModule, MatDatepickerModule, MatNativeDateModule,
	],
	declarations: [
		
		CustomerFilterComponent,
		CustomerEditorComponent,
		CustomerListingComponent,
        CustomerDetailsDialog,

		
		StoreFilterComponent,
		StoreEditorComponent,
		StoreListingComponent,
        StoreDetailsDialog,

		
		OrderFilterComponent,
		OrderEditorComponent,
		OrderListingComponent,
        OrderDetailsDialog,

		
		ProductFilterComponent,
		ProductEditorComponent,
		ProductListingComponent,
        ProductDetailsDialog,

		
		PosFilterComponent,
		PosEditorComponent,
		PosListingComponent,
        PosDetailsDialog,

		
	],
	
	providers: [
		GeneratorTestRepositoryApiService
	],

    entryComponents: [
        
        CustomerDetailsDialog,

		
        StoreDetailsDialog,

		
        OrderDetailsDialog,

		
        ProductDetailsDialog,

		
        PosDetailsDialog,

		    ],

	exports: [
		BrowserAnimationsModule,
		MatSnackBarModule, MatStepperModule, MatTabsModule, MatFormFieldModule, MatSelectModule, MatTableModule, MatSortModule, MatButtonModule, MatInputModule, MatAutocompleteModule, MatCheckboxModule, MatIconModule, MatPaginatorModule, MatDatepickerModule, MatNativeDateModule,


		
		CustomerFilterComponent,
		CustomerEditorComponent,
		CustomerListingComponent,

		
		StoreFilterComponent,
		StoreEditorComponent,
		StoreListingComponent,

		
		OrderFilterComponent,
		OrderEditorComponent,
		OrderListingComponent,

		
		ProductFilterComponent,
		ProductEditorComponent,
		ProductListingComponent,

		
		PosFilterComponent,
		PosEditorComponent,
		PosListingComponent,

			]

})
export class GeneratorTestRepositoryModule {
}