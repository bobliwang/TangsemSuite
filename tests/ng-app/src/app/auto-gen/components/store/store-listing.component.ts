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



@Component({
  selector: 'store-listing',
  templateUrl: 'store-listing.component.html',
})
export class StoreListingComponent {

  public dataSource = [];

	@Input()
	public showLinkedEntityInBottomSheet = false;

  @Input()
  public displayedColumns = [ 'id', 'storeName', 'storePhoto', 'createdById', 'createdTime', 'modifiedById', 'modifiedTime', 'active', "actions" ];

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
  public filterModel: models.StoreSearchParams;

  public ngOnInit() {
    
    this.filterModel = this.filterModel || <models.StoreSearchParams> {};

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


    this.repoApi.getStoreList(this.filterModel).pipe(
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

  public delete(rowData: models.StoreModel) {
    this.dialogs.confirm('', 'Do you want to delete?', ResultCode.Yes).subscribe(confirmed => {
      if (!confirmed) {
        return;
      }

      this.repoApi.deleteStore(rowData.id).subscribe(() => {
        
        this.snackBar.open('Deleted successfully', null, { duration: 1000 });
        this.search();
      }, err => {
        this.snackBar.open('Failed to delete', null, { duration: 3000 });
      });
    });
  }

  public edit(rowData: models.StoreModel) {
    this.router.navigate([`store/${rowData.id}/edit`]);
  }

  public add() {
    this.router.navigate(['store/create']);
  }



}