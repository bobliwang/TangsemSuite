import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';

import { AppComponent } from './app.component';
import { GeneratorTestRepositoryModule } from './auto-gen/generatorTestRepository.module';
import { GeneratorTestRepositoryApiService } from './auto-gen/services/api.service';
import { RouterModule } from '@angular/router';
import { routes } from './auto-gen/generatorTestRepository-routing.module';


@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    GeneratorTestRepositoryModule,
		RouterModule.forRoot(routes),
  ],
  exports: [
    HttpClientModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule {
  constructor(private apiService: GeneratorTestRepositoryApiService) {
    this.apiService.setApiBaseUrl('http://localhost:5000')
  }
}
