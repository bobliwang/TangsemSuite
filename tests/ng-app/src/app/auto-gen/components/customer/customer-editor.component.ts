import { Router, ActivatedRoute } from '@angular/router';
import { Component, OnInit, ViewChild, Input, Output, EventEmitter, Inject } from '@angular/core';
import { MatPaginator, MatSort, MatSnackBar, MatDialogRef, MAT_DIALOG_DATA, MatBottomSheetRef, MAT_BOTTOM_SHEET_DATA } from '@angular/material';
import * as models from '../../models/models';

import { GeneratorTestRepositoryApiService } from '../../services/api.service';

import { DialogsService } from '../../../services/dialogs.service';
import { ResultCode } from '../../../components/dialog/dialog.models';

@Component({
  selector: 'customer-editor',
  templateUrl: 'customer-editor.component.html',
})
export class CustomerEditorComponent implements OnInit {

    @Input()
    public subscribeToRoutingParams = true;

    @Input()
    public customerId = null;

    @Input()
    public loadOutgoingRefOptions = true;

    @Input()
    public isDialog = false;

    @Input()
    public hideActionBar = false;

	@Input()
	public model: models.CustomerModel;

	@Input()
	public mode: models.EditorMode = 'create';

	@Input()
	public redirectToRoute = 'customer/listing';

    
    //////////////////// Outgoing References BEGINGs ////////////////////////
        
    @Input()
    public storeOptions: models.StoreModel[];

        
    //////////////////// Outgoing References ENDs ////////////////////////
    
    @Output()
    public onLoadDataError = new EventEmitter<any>();

    @Output()
    public onSaveSuccess = new EventEmitter<any>();

    @Output()
    public onSaveError = new EventEmitter<any>();
	
	constructor(
		private router: Router,
		private activatedRoute: ActivatedRoute,
		private snackBar: MatSnackBar,
		private dialogs: DialogsService,
		private repoApi: GeneratorTestRepositoryApiService) {
	
	}

	public ngOnInit() {

        if (this.subscribeToRoutingParams) {
            this.activatedRoute.params.subscribe(params => {
			    const action = params['action'];
			    const customerId = params['customerId'];

			    console.log(JSON.stringify({action, customerId}));

			    this.mode = action || this.mode;

			    if (this.mode === 'edit' || this.mode === 'view') {
				    this.loadData(customerId);
			    }
		    });
        } else if (this.customerId != null && !this.model) {
            this.loadData(this.customerId);
        }

		this.model = this.model || {};

        if (this.loadOutgoingRefOptions) {

            
            //////////////////// Outgoing References BEGINGs ////////////////////////
                
            this.repoApi.getStoreList( <models.StoreSearchParams> { sortFieldName: '', direction: '', pageIndex: 0, pageSize: 1000 }).subscribe(pagingResult => {
                this.storeOptions = pagingResult.pagedData;
            });

                
            //////////////////// Outgoing References ENDs ////////////////////////
            
        }
	}

    public loadData(customerId: number | string) {
        this.repoApi.getCustomerByCustomerId(customerId).subscribe(result => {
			this.model = result;
		}, err => {
            console.error(`unable to load Customer by customerId ${customerId}`, err);
            this.onLoadDataError.emit({ error: err, customerId: customerId});
        });
    }

	public save() {
		if (this.mode === 'create') {
			this.create();
		} else if (this.mode === 'edit') {
			this.update();
		}
	}

	protected create() {

		this.repoApi.createCustomer(this.model).subscribe(result => {
			if (result && result.customerId) {
				this.model.customerId = result.customerId;
			}

			this.snackBar.open('created successfully', null, { duration: 1000 });

			if (this.redirectToRoute) {
				this.router.navigate([this.redirectToRoute]);	
			}
			
		}, err => {
			this.snackBar.open('failed to create', null, { duration: 3000 });
		});
	}

	protected update() {

		this.repoApi.updateCustomer(this.model.customerId, this.model).subscribe(result => {
			if (result && result.customerId) {
				this.model.customerId = result.customerId;
			}

			this.snackBar.open('updated successfully', null, { duration: 1000 });
			this.onSaveSuccess.emit({ model: this.model });

			if (this.redirectToRoute) {
				this.router.navigate([this.redirectToRoute]);	
			}
		}, err => {
			this.snackBar.open('failed to updade', null, { duration: 3000 });
            this.onSaveError.emit({ error: err, model: this.model });
		});
	}

	protected cancel() {
		if (this.redirectToRoute) {
			this.dialogs.confirm('', 'Do you want to cancel?', ResultCode.Yes).subscribe(confirmed => {
				if (confirmed) {
					this.router.navigate([this.redirectToRoute]);
				}
			});			
		}
	}
}

@Component({
  selector: 'customer-details-dialog',
  template: `
    <h4 mat-dialog-title *ngIf="!!data.title">
        {{ data.title }}
    </h4>
    <div mat-dialog-content>
      <customer-editor
        [customerId]="data.customerId" [subscribeToRoutingParams]="false" [isDialog]="true"></customer-editor>
    </div>
    <div mat-dialog-actions align="end">
      <button mat-button (click)="close()">Close</button>      
    </div>
  `,
})
export class CustomerDetailsDialog {

  constructor(
    public dialogRef: MatDialogRef<CustomerDetailsDialog>,
    @Inject(MAT_DIALOG_DATA) public data: { customerId: string, title?: string }) {
  }

  public close(): void {
    this.dialogRef.close();
  }
}


@Component({
	selector: 'customer-sheet',
	template: `
		<div class="flex-columns">
			<div></div>
			<button mat-button (click)="close($event)">
				<mat-icon>close</mat-icon>
			</button>
		</div>
		<div class="sheet-container">
			<customer-editor
				[subscribeToRoutingParams]="false"
				[isDialog]="true"
				[customerId]="data.customerId"
				></customer-editor>
		</div>
	`,
})
export class CustomerSheetComponent {
	constructor(private bottomSheetRef: MatBottomSheetRef<CustomerSheetComponent>,
		@Inject(MAT_BOTTOM_SHEET_DATA) public data: { customerId: string, title?: string }) { }

	public close(event: MouseEvent): void {
		this.bottomSheetRef.dismiss();
		event.preventDefault();
	}
}