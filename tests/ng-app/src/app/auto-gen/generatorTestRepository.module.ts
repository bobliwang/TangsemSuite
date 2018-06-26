import { HttpClient, HttpParams, HttpClientModule } from '@angular/common/http';
import { Observable } from 'rxjs/Observable';
import * as models from './models/models';

import { CommonModule } from '@angular/common';
import { ErrorHandler, ModuleWithProviders, NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import {
	MatStepperModule,
	MatTabsModule,
	MatFormFieldModule,
	MatSelectModule,
	MatTableModule,
	MatSortModule,
	MatButtonModule,
	MatInputModule,
	MatAutocompleteModule,
	MatCheckboxModule,
	MatIconModule,
	MatTableDataSource
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
		FormsModule,
		ReactiveFormsModule,
		HttpClientModule,

		MatIconModule,
		MatStepperModule,
		MatTabsModule,
		MatFormFieldModule,
		MatSelectModule,
		MatTableModule,
		MatSortModule,
		MatButtonModule,
		MatInputModule,
		MatAutocompleteModule,
		MatCheckboxModule,	
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
		CommonModule,
		FormsModule,
		ReactiveFormsModule,
		HttpClientModule,

		MatIconModule,
		MatStepperModule,
		MatTabsModule,
		MatFormFieldModule,
		MatSelectModule,
		MatTableModule,
		MatSortModule,
		MatButtonModule,
		MatInputModule,
		MatAutocompleteModule,
		MatCheckboxModule
	]

})
export class GeneratorTestRepositoryModule {
}