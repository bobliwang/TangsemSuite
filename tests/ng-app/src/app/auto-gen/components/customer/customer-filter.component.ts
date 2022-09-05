// tslint:disable
import { Component, OnInit, ViewChild, Input, Output, EventEmitter } from '@angular/core';
import { MatPaginator, MatSort } from '@angular/material';
import { Observable } from 'rxjs';
import { catchError, map, startWith, switchMap } from 'rxjs/operators';
import * as models from '../../models/models';

import { GeneratorTestRepositoryApiService } from '../../services/api.service';

@Component({
  selector: 'customer-filter',
  templateUrl: 'customer-filter.component.html',
})
export class CustomerFilterComponent {
    
    constructor(
		private repoApi: GeneratorTestRepositoryApiService) {	
	}
	
	@Input()
	public filterModel: models.CustomerSearchParams;

    @Input()
    public showFilters = false;

    
    //////////////////// Outgoing References BEGINGs ////////////////////////
        
    @Input()
    public storeOptions: models.StoreModel[];

        
    //////////////////// Outgoing References ENDs ////////////////////////
    
	@Output('onSearch')
	public onSearch = new EventEmitter<models.CustomerSearchParams>();

	public ngOnInit() {
		this.filterModel = this.filterModel || <models.CustomerSearchParams> {};

        
        //////////////////// Outgoing References BEGINGs ////////////////////////
            
        this.repoApi.getStoreList( <models.StoreSearchParams> { sortFieldName: '', direction: '', pageIndex: 0, pageSize: 1000 }).subscribe(pagingResult => {
            this.storeOptions = pagingResult.pagedData;
        });

            
        //////////////////// Outgoing References ENDs ////////////////////////
        	}

	public search() {
		this.onSearch.emit(this.filterModel);
	}

}