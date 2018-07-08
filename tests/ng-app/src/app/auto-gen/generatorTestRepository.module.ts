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
import { ProductFilterComponent } from './components/product/product-filter.component';
import { ProductListingComponent } from './components/product/product-listing.component';
import { ProductEditorComponent } from './components/product/product-editor.component';

import { OrderFilterComponent } from './components/order/order-filter.component';
import { OrderListingComponent } from './components/order/order-listing.component';
import { OrderEditorComponent } from './components/order/order-editor.component';

import { PosFilterComponent } from './components/pos/pos-filter.component';
import { PosListingComponent } from './components/pos/pos-listing.component';
import { PosEditorComponent } from './components/pos/pos-editor.component';


@NgModule({
	imports: [
		CommonModule,
		ReactiveFormsModule,
		FormsModule,
		BrowserAnimationsModule,

		MatSnackBarModule, MatStepperModule, MatTabsModule, MatFormFieldModule, MatSelectModule, MatTableModule, MatSortModule, MatButtonModule, MatInputModule, MatAutocompleteModule, MatCheckboxModule, MatIconModule, MatPaginatorModule, MatDatepickerModule, MatNativeDateModule,
	],
	declarations: [
		
		ProductFilterComponent,
		ProductEditorComponent,
		ProductListingComponent,

		
		OrderFilterComponent,
		OrderEditorComponent,
		OrderListingComponent,

		
		PosFilterComponent,
		PosEditorComponent,
		PosListingComponent,

		
	],
	
	providers: [
		GeneratorTestRepositoryApiService
	],

	exports: [
		BrowserAnimationsModule,
		MatSnackBarModule, MatStepperModule, MatTabsModule, MatFormFieldModule, MatSelectModule, MatTableModule, MatSortModule, MatButtonModule, MatInputModule, MatAutocompleteModule, MatCheckboxModule, MatIconModule, MatPaginatorModule, MatDatepickerModule, MatNativeDateModule,


		
		ProductFilterComponent,
		ProductEditorComponent,
		ProductListingComponent,

		
		OrderFilterComponent,
		OrderEditorComponent,
		OrderListingComponent,

		
		PosFilterComponent,
		PosEditorComponent,
		PosListingComponent,

			]

})
export class GeneratorTestRepositoryModule {
}