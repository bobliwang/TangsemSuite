import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';

import { AppComponent } from './app.component';
import { GeneratorTestRepositoryModule } from './auto-gen/generatorTestRepository.module';
import { GeneratorTestRepositoryApiService } from './auto-gen/services/api.service';
import { RouterModule } from '@angular/router';
import { routes } from './auto-gen/generatorTestRepository-routing.module';
import {  
  MatAutocompleteModule,
  MatBadgeModule,
  MatBottomSheetModule,
  MatButtonModule,
  MatButtonToggleModule,
  MatCardModule,
  MatCheckboxModule,
  MatChipsModule,
  MatDatepickerModule,
  MatDialogModule,
  MatDividerModule,
  MatExpansionModule,
  MatGridListModule,
  MatIconModule,
  MatInputModule,
  MatListModule,
  MatMenuModule,
  MatNativeDateModule,
  MatPaginatorModule,
  MatProgressBarModule,
  MatProgressSpinnerModule,
  MatRadioModule,
  MatRippleModule,
  MatSelectModule,
  MatSidenavModule,
  MatSliderModule,
  MatSlideToggleModule,
  MatSnackBarModule,
  MatSortModule,
  MatStepperModule,
  MatTableModule,
  MatTabsModule,
  MatToolbarModule,
  MatTooltipModule,
  MatTreeModule, } from '@angular/material';
import { DialogsService } from './services/dialogs.service';
import { DialogComponent } from './components/dialog/dialog.component';
import { ProductPageComponent } from './pages/product-page/product-page.component';
import { ProdSpecsComponent } from './components/prod-specs/prod-specs.component';
import { OrderPageComponent } from './pages/order-page/order-page.component';

import { MultipleEntitySelectorComponent } from './components/multiple-entity-selector/multiple-entity-selector.component';
import { SingleEntitySelectorComponent } from './components/single-entity-selector/single-entity-selector.component';
import { ApiClientGenComponent } from './api-client-gen/api-client-gen.component';
import { ApiClient } from './services/api-client/api-client';

import { CodemirrorModule } from '@ctrl/ngx-codemirror';

routes.unshift(...[
	{ path: '', redirectTo: 'app-api-client-gen', pathMatch: 'full', hideFromMenuItem: true },
	{ path: 'app-api-client-gen', component: ApiClientGenComponent },
]);

routes.push(...[
  { path: 'my-product/listing', component: ProductPageComponent },
  { path: 'my-order/listing', component: OrderPageComponent }
]);

@NgModule({
  declarations: [
    AppComponent,
    DialogComponent,
    ProdSpecsComponent,
    ProductPageComponent,
    OrderPageComponent,
    SingleEntitySelectorComponent,
    MultipleEntitySelectorComponent,
    ApiClientGenComponent,
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    FormsModule,
    GeneratorTestRepositoryModule,
    CodemirrorModule,
    RouterModule.forRoot(routes),
    MatAutocompleteModule,
    MatBadgeModule,
    MatBottomSheetModule,
    MatButtonModule,
    MatButtonToggleModule,
    MatCardModule,
    MatCheckboxModule,
    MatChipsModule,
    MatDatepickerModule,
    MatDialogModule,
    MatDividerModule,
    MatExpansionModule,
    MatGridListModule,
    MatIconModule,
    MatInputModule,
    MatListModule,
    MatMenuModule,
    MatNativeDateModule,
    MatPaginatorModule,
    MatProgressBarModule,
    MatProgressSpinnerModule,
    MatRadioModule,
    MatRippleModule,
    MatSelectModule,
    MatSidenavModule,
    MatSliderModule,
    MatSlideToggleModule,
    MatSnackBarModule,
    MatSortModule,
    MatStepperModule,
    MatTableModule,
    MatTabsModule,
    MatToolbarModule,
    MatTooltipModule,
    MatTreeModule,
    
  ],
  entryComponents: [
    DialogComponent
  ],
  exports: [
    HttpClientModule
  ],
  providers: [
    DialogsService
  ],
  bootstrap: [AppComponent]
})
export class AppModule {
  constructor(private apiService: GeneratorTestRepositoryApiService, private apiClient: ApiClient) {
    this.apiService.setApiBaseUrl('http://localhost:5000');
    
    
    this.apiClient.apiUrlBase = 'http://localhost:5000';
  }
}
