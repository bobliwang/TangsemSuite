// tslint:disable
import { Component, OnInit, ViewChild, Input, Output, EventEmitter } from '@angular/core';
import { MatPaginator, MatSort } from '@angular/material';
import { Observable } from 'rxjs';
import { catchError, map, startWith, switchMap } from 'rxjs/operators';
import * as models from '../../models/models';

import { GeneratorTestRepositoryApiService } from '../../services/api.service';

@Component({
  selector: 'pos-filter',
  templateUrl: 'pos-filter.component.html',
})
export class PosFilterComponent {
    
    constructor(
		private repoApi: GeneratorTestRepositoryApiService) {	
	}
	
	@Input()
	public filterModel: models.PosSearchParams;

    @Input()
    public showFilters = false;

    
	@Output('onSearch')
	public onSearch = new EventEmitter<models.PosSearchParams>();

	public ngOnInit() {
		this.filterModel = this.filterModel || <models.PosSearchParams> {};

        	}

	public search() {
		this.onSearch.emit(this.filterModel);
	}

}