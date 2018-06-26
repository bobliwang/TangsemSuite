import { Component, OnInit, ViewChild, Input, Output, EventEmitter } from '@angular/core';
import { MatPaginator, MatSort } from '@angular/material';
import { Observable } from 'rxjs/Observable';
import { catchError, map, startWith, switchMap } from 'rxjs/operators';
import * as models from '../../models/models';

@Component({
  selector: 'order-filter',
  templateUrl: 'order-filter.html',
})
export class OrderFilterComponent {
	
	@Input()
	public filterModel: models.OrderSearchParams;

	@Output('onSearch')
	public onSearch = new EventEmitter<models.OrderSearchParams>();

	public ngOnInit() {
		this.filterModel = this.filterModel || <models.OrderSearchParams> {};
	}

	public search() {
		this.onSearch.emit(this.filterModel);
	}

}