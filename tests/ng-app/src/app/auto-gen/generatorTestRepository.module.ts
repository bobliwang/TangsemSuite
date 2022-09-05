// tslint:disable
import { HttpClient, HttpParams } from '@angular/common/http';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { Observable } from 'rxjs';
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
import { CustomerEditorComponent, CustomerDetailsDialog, CustomerSheetComponent } from './components/customer/customer-editor.component';

import { StoreFilterComponent } from './components/store/store-filter.component';
import { StoreListingComponent } from './components/store/store-listing.component';
import { StoreEditorComponent, StoreDetailsDialog, StoreSheetComponent } from './components/store/store-editor.component';

import { OrderFilterComponent } from './components/order/order-filter.component';
import { OrderListingComponent } from './components/order/order-listing.component';
import { OrderEditorComponent, OrderDetailsDialog, OrderSheetComponent } from './components/order/order-editor.component';

import { ProductFilterComponent } from './components/product/product-filter.component';
import { ProductListingComponent } from './components/product/product-listing.component';
import { ProductEditorComponent, ProductDetailsDialog, ProductSheetComponent } from './components/product/product-editor.component';

import { PosFilterComponent } from './components/pos/pos-filter.component';
import { PosListingComponent } from './components/pos/pos-listing.component';
import { PosEditorComponent, PosDetailsDialog, PosSheetComponent } from './components/pos/pos-editor.component';



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
    CustomerSheetComponent,

		
		StoreFilterComponent,
		StoreEditorComponent,
		StoreListingComponent,
    StoreDetailsDialog,
    StoreSheetComponent,

		
		OrderFilterComponent,
		OrderEditorComponent,
		OrderListingComponent,
    OrderDetailsDialog,
    OrderSheetComponent,

		
		ProductFilterComponent,
		ProductEditorComponent,
		ProductListingComponent,
    ProductDetailsDialog,
    ProductSheetComponent,

		
		PosFilterComponent,
		PosEditorComponent,
		PosListingComponent,
    PosDetailsDialog,
    PosSheetComponent,

		
	],
	
	providers: [
		GeneratorTestRepositoryApiService
	],

    entryComponents: [
        
        CustomerDetailsDialog,
				CustomerSheetComponent,

		
        StoreDetailsDialog,
				StoreSheetComponent,

		
        OrderDetailsDialog,
				OrderSheetComponent,

		
        ProductDetailsDialog,
				ProductSheetComponent,

		
        PosDetailsDialog,
				PosSheetComponent,

		    ],

	exports: [
		BrowserAnimationsModule,
		MatSnackBarModule, MatStepperModule, MatTabsModule, MatFormFieldModule, MatSelectModule, MatTableModule, MatSortModule, MatButtonModule, MatInputModule, MatAutocompleteModule, MatCheckboxModule, MatIconModule, MatPaginatorModule, MatDatepickerModule, MatNativeDateModule,


		
		CustomerFilterComponent,
		CustomerEditorComponent,
		CustomerListingComponent,
    CustomerDetailsDialog,
    CustomerSheetComponent,

		
		StoreFilterComponent,
		StoreEditorComponent,
		StoreListingComponent,
    StoreDetailsDialog,
    StoreSheetComponent,

		
		OrderFilterComponent,
		OrderEditorComponent,
		OrderListingComponent,
    OrderDetailsDialog,
    OrderSheetComponent,

		
		ProductFilterComponent,
		ProductEditorComponent,
		ProductListingComponent,
    ProductDetailsDialog,
    ProductSheetComponent,

		
		PosFilterComponent,
		PosEditorComponent,
		PosListingComponent,
    PosDetailsDialog,
    PosSheetComponent,

			]

})
export class GeneratorTestRepositoryModule {
}