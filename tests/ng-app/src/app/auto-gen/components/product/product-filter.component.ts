import { Component, OnInit, ViewChild, Input, Output, EventEmitter } from '@angular/core';
import { MatPaginator, MatSort } from '@angular/material';
import { Observable } from 'rxjs/Observable';
import { catchError, map, startWith, switchMap } from 'rxjs/operators';
import * as models from '../../models/models';

@Component({
  selector: 'product-filter',
  templateUrl: 'product-filter.html',
})
export class ProductFilterComponent {
	
	@Input()
	public filterModel: models.ProductSearchParams;

	@Output('onSearch')
	public onSearch = new EventEmitter<models.ProductSearchParams>();

	public ngOnInit() {
		this.filterModel = this.filterModel || <models.ProductSearchParams> {};
	}

	public search() {
		this.onSearch.emit(this.filterModel);
	}

}