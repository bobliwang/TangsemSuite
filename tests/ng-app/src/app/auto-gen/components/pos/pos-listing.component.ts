import { Component, OnInit, ViewChild, Input } from '@angular/core';
import { Router } from '@angular/router';
import { MatSort, MatSnackBar, MatPaginator } from '@angular/material';
import { Observable } from 'rxjs/Observable';
import { catchError, map, startWith, switchMap } from 'rxjs/operators';

import { GeneratorTestRepositoryApiService } from '../../services/api.service';
import * as models from '../../models/models'


@Component({
  selector: 'Pos-listing',
  templateUrl: 'Pos-listing.html',
})
export class PosListingComponent {

	public posList: models.PosModel[];

	public displayedColumns = [ 'id', 'name', 'createdById', 'modifiedById', 'createdTime', 'modifiedTime', 'active', "actions" ];

	public resultsLength = 0;
	public isLoadingResults = true;

	@ViewChild(MatPaginator)
	public paginator: MatPaginator;

	@ViewChild(MatSort)
	public sort: MatSort;

	constructor(
		private router: Router,
		private repoApi: GeneratorTestRepositoryApiService) {
	
	}

	@Input()
	public filter: models.PosSearchParams;

	public ngOnInit() {
		
		this.filter	= this.filter || <models.PosSearchParams> {};

		this.sort.sortChange.subscribe(() => this.paginator.pageIndex = 0);

		Observable.merge(this.sort.sortChange, this.paginator.page).pipe(
			startWith({}),
			switchMap(() => {
			  this.isLoadingResults = true;

			  Object.assign(this.filter, {
			  	sortFieldName: this.sort.active,
			  	direction: this.sort.direction,
			  	pageIndex: this.paginator.pageIndex
			  });

			  return this.repoApi.getPosList(this.filter);
			}),
			map(data => {
			  // Flip flag to show that loading has finished.
			  this.isLoadingResults = false;
			  this.resultsLength = data.rowsCount;

			  return data.pagedData;
			}),
			catchError(() => {
			  this.isLoadingResults = false;
			  // Catch if the GitHub API has reached its rate limit. Return empty data.

			  return Observable.of([]);
			})
		  ).subscribe(data => this.posList = data);
	}

	public search() {
	}

}