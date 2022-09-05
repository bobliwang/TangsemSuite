// tslint:disable
import { Component, OnInit, AfterViewInit, ViewChild, Input } from '@angular/core';
import { Router } from '@angular/router';
import { MatSort, MatSnackBar, MatPaginator, MatTableDataSource, MatDialog, MatBottomSheet } from '@angular/material';
import { merge, Observable, of } from 'rxjs';
import { catchError, map } from 'rxjs/operators';

import { GeneratorTestRepositoryApiService } from '../../services/api.service';
import * as models from '../../models/models';

import { DialogsService } from '../../../services/dialogs.service';
import { ResultCode } from '../../../components/dialog/dialog.models';

import { CustomerDetailsDialog
	, CustomerSheetComponent
} from '../customer/customer-editor.component';
import { ProductDetailsDialog
	, ProductSheetComponent
} from '../product/product-editor.component';


@Component({
  selector: 'order-listing',
  templateUrl: 'order-listing.component.html',
})
export class OrderListingComponent {

  public dataSource = [];

	@Input()
	public showLinkedEntityInBottomSheet = false;

  @Input()
  public displayedColumns = [ 'id', 'customerName', 'orderTotal', 'createdById', 'modifiedById', 'createdTime', 'modifiedTime', 'active', 'customerId', 'productId', "actions" ];

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
    private matDialog: MatDialog,
		private matBottomSheet: MatBottomSheet,
    private dialogs: DialogsService,
    private repoApi: GeneratorTestRepositoryApiService) {
  
  }

  @Input()
  public filterModel: models.OrderSearchParams;

  public ngOnInit() {
    
    this.filterModel = this.filterModel || <models.OrderSearchParams> {};

    this.sort.sortChange.subscribe(() => this.paginator.pageIndex = 0);

    merge(this.sort.sortChange, this.paginator.page).subscribe(() => {
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


    this.repoApi.getOrderList(this.filterModel).pipe(
      map(data => {
        // Flip flag to show that loading has finished.
        this.isLoadingResults = false;
        this.resultsLength = data.rowsCount;

        return data.pagedData;
      }),
      catchError(() => {
        this.isLoadingResults = false;

        return of([]);
      })
    ).subscribe(pagedData => this.dataSource = pagedData);
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



  public showCustomerDetails(customerId: string) {

			const data = {
				customerId,
				title: `Customer Details`
			};

			if (this.showLinkedEntityInBottomSheet) {
				this.matBottomSheet.open(CustomerSheetComponent, { data });
			} else {
				this.matDialog.open(CustomerDetailsDialog, {
					width: '80vw',
					data
				});
			}
	}


  public showProductDetails(id: number) {

			const data = {
				id,
				title: `Product Details`
			};

			if (this.showLinkedEntityInBottomSheet) {
				this.matBottomSheet.open(ProductSheetComponent, { data });
			} else {
				this.matDialog.open(ProductDetailsDialog, {
					width: '80vw',
					data
				});
			}
	}


}