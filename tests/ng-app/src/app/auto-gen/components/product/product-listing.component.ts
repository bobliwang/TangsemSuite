import { Component, OnInit, ViewChild, Input } from '@angular/core';
import { Router } from '@angular/router';
import { MatSort, MatSnackBar, MatPaginator } from '@angular/material';
import { Observable } from 'rxjs/Rx';
import { catchError, map, startWith, switchMap } from 'rxjs/operators';

import { GeneratorTestRepositoryApiService } from '../../services/api.service';
import * as models from '../../models/models'


@Component({
  selector: 'product-listing',
  templateUrl: 'product-listing.component.html',
})
export class ProductListingComponent {

	public productList: models.ProductModel[];

	public displayedColumns = [ 'id', 'name', 'unitPrice', 'specsJson', 'createdById', 'createdTime', 'modifiedById', 'modifiedTime', 'active', "actions" ];

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
	public filter: models.ProductSearchParams;

	public ngOnInit() {
		
		this.filter	= this.filter || <models.ProductSearchParams> {};

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

			  return this.repoApi.getProductList(this.filter);
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
		  ).subscribe(data => this.productList = data);
	}

	public search() {
	}

}