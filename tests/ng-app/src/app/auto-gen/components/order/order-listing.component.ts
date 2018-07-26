import { Component, OnInit, AfterViewInit, ViewChild, Input } from '@angular/core';
import { Router } from '@angular/router';
import { MatSort, MatSnackBar, MatPaginator, MatTableDataSource, MatDialog } from '@angular/material';
import { Observable } from 'rxjs/Rx';
import { merge } from 'rxjs/observable/merge';

import { GeneratorTestRepositoryApiService } from '../../services/api.service';
import * as models from '../../models/models';

import { DialogsService } from '../../../services/dialogs.service';
import { ResultCode } from '../../../components/dialog/dialog.models';
import { ProductDetailsDialog } from '../product/product-editor.component';


@Component({
  selector: 'order-listing',
  templateUrl: 'order-listing.component.html',
})
export class OrderListingComponent {

	public dataSource = [];

	@Input()
	public displayedColumns = [ 'id', 'customerName', 'productId', 'orderTotal', 'createdById', 'modifiedById', 'createdTime', 'modifiedTime', 'active', "actions" ];

	public resultsLength = 0;
	public isLoadingResults = true;

	@ViewChild(MatPaginator)
	public paginator: MatPaginator;

	@ViewChild(MatSort)
	public sort: MatSort;

	@Input()
	public templates = {};

	constructor(
		private router: Router,
		private snackBar: MatSnackBar,
		private magDialog: MatDialog,
		private dialogs: DialogsService,
		private repoApi: GeneratorTestRepositoryApiService) {
	
	}

	@Input()
	public filterModel: models.OrderSearchParams;

	public ngOnInit() {
		
		this.filterModel = this.filterModel || <models.OrderSearchParams> {};

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


		this.repoApi.getOrderList(this.filterModel).map(data => {
			// Flip flag to show that loading has finished.
			this.isLoadingResults = false;
			this.resultsLength = data.rowsCount;

			return data.pagedData;
		}).catch(() => {
			this.isLoadingResults = false;

			return Observable.of([]);
		}).subscribe(pagedData => this.dataSource = pagedData);
	}

	public delete(rowData: models.OrderModel) {
		this.dialogs.confirm('', 'Do you want to delete?', ResultCode.Yes).subscribe(confirmed => {
			if (!confirmed) {
				return;
			}

			this.repoApi.deleteOrder(rowData.id).subscribe(() => {
				
				this.snackBar.open('Deleted successfully', null, { duration: 1000 });
				this.search();
			}, err => {
				this.snackBar.open('Failed to delete', null, { duration: 3000 });
			});
		});
	}

	public edit(rowData: models.OrderModel) {
		this.router.navigate([`order/${rowData.id}/edit`]);
	}

	public add() {
		this.router.navigate(['order/create']);
	}

	public showProductDetails(productId: number) {
		this.magDialog.open(ProductDetailsDialog, {
			width: '80vw',
			data: { id: productId }
		 });
	}

}