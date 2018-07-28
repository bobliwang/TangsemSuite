import { Component, OnInit, ViewChild, Input, Output, EventEmitter } from '@angular/core';
import { MatPaginator, MatSort } from '@angular/material';
import { Observable } from 'rxjs/Observable';
import { catchError, map, startWith, switchMap } from 'rxjs/operators';
import * as models from '../../models/models';

import { GeneratorTestRepositoryApiService } from '../../services/api.service';

@Component({
  selector: 'store-filter',
  templateUrl: 'store-filter.component.html',
})
export class StoreFilterComponent {
    
    constructor(
		private repoApi: GeneratorTestRepositoryApiService) {	
	}
	
	@Input()
	public filterModel: models.StoreSearchParams;

    @Input()
    public showFilters = false;

    
	@Output('onSearch')
	public onSearch = new EventEmitter<models.StoreSearchParams>();

	public ngOnInit() {
		this.filterModel = this.filterModel || <models.StoreSearchParams> {};

        	}

	public search() {
		this.onSearch.emit(this.filterModel);
	}

}