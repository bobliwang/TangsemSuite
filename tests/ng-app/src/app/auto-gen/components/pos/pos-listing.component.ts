import { Component, OnInit, AfterViewInit, ViewChild, Input } from '@angular/core';
import { Router } from '@angular/router';
import { MatSort, MatSnackBar, MatPaginator, MatTableDataSource } from '@angular/material';
import { Observable } from 'rxjs/Rx';
import { merge } from 'rxjs/observable/merge';

import { GeneratorTestRepositoryApiService } from '../../services/api.service';
import * as models from '../../models/models'


@Component({
  selector: 'pos-listing',
  templateUrl: 'pos-listing.component.html',
})
export class PosListingComponent {

	public dataSource = [];

	public displayedColumns = [ 'id', 'name', 'createdById', 'modifiedById', 'createdTime', 'modifiedTime', 'active', "actions" ];

	public resultsLength = 0;
	public isLoadingResults = true;

	@ViewChild(MatPaginator)
	public paginator: MatPaginator;

	@ViewChild(MatSort)
	public sort: MatSort;

	constructor(
		private router: Router,
		private snackBar: MatSnackBar,
		private repoApi: GeneratorTestRepositoryApiService) {
	
	}

	@Input()
	public filterModel: models.PosSearchParams;

	public ngOnInit() {
		
		this.filterModel = this.filterModel || <models.PosSearchParams> {};

		this.sort.sortChange.subscribe(() => this.paginator.pageIndex = 0);

		Observable.merge(this.sort.sortChange, this.paginator.page).subscribe(() => {
			this.search();
		});
	}

	public ngAfterViewInit() {
		this.search();
	}

	public search() {

		this.filterModel.pageIndex = this.paginator.pageIndex || 0;
		this.filterModel.pageSize = this.paginator.pageSize || 100;
		this.filterModel.sortFieldName = this.sort.active || '';
		this.filterModel.direction = this.sort.direction || 'desc';


		this.repoApi.getPosList(this.filterModel).map(data => {
			// Flip flag to show that loading has finished.
			this.isLoadingResults = false;
			this.resultsLength = data.rowsCount;

			return data.pagedData;
		}).catch(() => {
			this.isLoadingResults = false;

			return Observable.of([]);
		}).subscribe(pagedData => this.dataSource = pagedData);
	}

	public delete(rowData: models.PosModel) {
		this.repoApi.deletePos(rowData.id)
			.subscribe(() => {
				
				this.snackBar.open('deleted successfully', null, { duration: 1000 });
				this.search();
			}, err => {
				this.snackBar.open('failed to delete', null, { duration: 3000 });
			});
	}


	public add() {
		this.router.navigate(['pos/create']);
	}

}