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

import { StoreDetailsDialog
	, StoreSheetComponent
} from '../store/store-editor.component';


@Component({
  selector: 'customer-listing',
  templateUrl: 'customer-listing.component.html',
})
export class CustomerListingComponent {

  public dataSource = [];

	@Input()
	public showLinkedEntityInBottomSheet = false;

  @Input()
  public displayedColumns = [ 'customerId', 'customerName', 'createdById', 'modifiedById', 'createdTime', 'modifiedTime', 'active', 'storeId', "actions" ];

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
  public filterModel: models.CustomerSearchParams;

  public ngOnInit() {
    
    this.filterModel = this.filterModel || <models.CustomerSearchParams> {};

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


    this.repoApi.getCustomerList(this.filterModel).pipe(
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

  public delete(rowData: models.CustomerModel) {
    this.dialogs.confirm('', 'Do you want to delete?', ResultCode.Yes).subscribe(confirmed => {
      if (!confirmed) {
        return;
      }

      this.repoApi.deleteCustomer(rowData.customerId).subscribe(() => {
        
        this.snackBar.open('Deleted successfully', null, { duration: 1000 });
        this.search();
      }, err => {
        this.snackBar.open('Failed to delete', null, { duration: 3000 });
      });
    });
  }

  public edit(rowData: models.CustomerModel) {
    this.router.navigate([`customer/${rowData.customerId}/edit`]);
  }

  public add() {
    this.router.navigate(['customer/create']);
  }



  public showStoreDetails(id: number) {

			const data = {
				id,
				title: `Store Details`
			};

			if (this.showLinkedEntityInBottomSheet) {
				this.matBottomSheet.open(StoreSheetComponent, { data });
			} else {
				this.matDialog.open(StoreDetailsDialog, {
					width: '80vw',
					data
				});
			}
	}


}