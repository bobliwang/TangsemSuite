// tslint:disable
import { Component, OnInit, ViewChild, Input, Output, EventEmitter } from '@angular/core';
import { MatPaginator, MatSort } from '@angular/material';
import { Observable } from 'rxjs';
import { catchError, map, startWith, switchMap } from 'rxjs/operators';
import * as models from '../../models/models';

import { GeneratorTestRepositoryApiService } from '../../services/api.service';

@Component({
  selector: 'product-filter',
  templateUrl: 'product-filter.component.html',
})
export class ProductFilterComponent {
    
    constructor(
		private repoApi: GeneratorTestRepositoryApiService) {	
	}
	
	@Input()
	public filterModel: models.ProductSearchParams;

    @Input()
    public showFilters = false;

    
	@Output('onSearch')
	public onSearch = new EventEmitter<models.ProductSearchParams>();

	public ngOnInit() {
		this.filterModel = this.filterModel || <models.ProductSearchParams> {};

        	}

	public search() {
		this.onSearch.emit(this.filterModel);
	}

}