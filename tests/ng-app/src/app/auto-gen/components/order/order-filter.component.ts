// tslint:disable
import { Component, OnInit, ViewChild, Input, Output, EventEmitter } from '@angular/core';
import { MatPaginator, MatSort } from '@angular/material';
import { Observable } from 'rxjs';
import { catchError, map, startWith, switchMap } from 'rxjs/operators';
import * as models from '../../models/models';

import { GeneratorTestRepositoryApiService } from '../../services/api.service';

@Component({
  selector: 'order-filter',
  templateUrl: 'order-filter.component.html',
})
export class OrderFilterComponent {
    
    constructor(
		private repoApi: GeneratorTestRepositoryApiService) {	
	}
	
	@Input()
	public filterModel: models.OrderSearchParams;

    @Input()
    public showFilters = false;

    
    //////////////////// Outgoing References BEGINGs ////////////////////////
        
    @Input()
    public customerOptions: models.CustomerModel[];

        
    @Input()
    public productOptions: models.ProductModel[];

        
    //////////////////// Outgoing References ENDs ////////////////////////
    
	@Output('onSearch')
	public onSearch = new EventEmitter<models.OrderSearchParams>();

	public ngOnInit() {
		this.filterModel = this.filterModel || <models.OrderSearchParams> {};

        
        //////////////////// Outgoing References BEGINGs ////////////////////////
            
        this.repoApi.getCustomerList( <models.CustomerSearchParams> { sortFieldName: '', direction: '', pageIndex: 0, pageSize: 1000 }).subscribe(pagingResult => {
            this.customerOptions = pagingResult.pagedData;
        });

            
        this.repoApi.getProductList( <models.ProductSearchParams> { sortFieldName: '', direction: '', pageIndex: 0, pageSize: 1000 }).subscribe(pagingResult => {
            this.productOptions = pagingResult.pagedData;
        });

            
        //////////////////// Outgoing References ENDs ////////////////////////
        	}

	public search() {
		this.onSearch.emit(this.filterModel);
	}

}