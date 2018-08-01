import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';

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
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    GeneratorTestRepositoryModule,
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
  constructor(private apiService: GeneratorTestRepositoryApiService) {
    this.apiService.setApiBaseUrl('http://localhost:5000');
  }
}
