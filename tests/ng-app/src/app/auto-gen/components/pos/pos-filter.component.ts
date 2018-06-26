import { Component, OnInit, ViewChild, Input, Output, EventEmitter } from '@angular/core';
import { MatPaginator, MatSort } from '@angular/material';
import { Observable } from 'rxjs/Observable';
import { catchError, map, startWith, switchMap } from 'rxjs/operators';
import * as models from '../../models/models';

@Component({
  selector: 'pos-filter',
  templateUrl: 'pos-filter.html',
})
export class PosFilterComponent {
	
	@Input()
	public filterModel: models.PosSearchParams;

	@Output('onSearch')
	public onSearch = new EventEmitter<models.PosSearchParams>();

	public ngOnInit() {
		this.filterModel = this.filterModel || <models.PosSearchParams> {};
	}

	public search() {
		this.onSearch.emit(this.filterModel);
	}

}