import { Router, ActivatedRoute } from '@angular/router';
import { Component, OnInit, ViewChild, Input, Output, EventEmitter, Inject } from '@angular/core';
import { MatPaginator, MatSort, MatSnackBar, MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';
import * as models from '../../models/models';

import { GeneratorTestRepositoryApiService } from '../../services/api.service';

import { DialogsService } from '../../../services/dialogs.service';
import { ResultCode } from '../../../components/dialog/dialog.models';

@Component({
  selector: 'order-editor',
  templateUrl: 'order-editor.component.html',
})
export class OrderEditorComponent implements OnInit {

    @Input()
    public subscribeToRoutingParams = true;

    @Input()
    public entityId = null;

    @Input()
    public loadOutgoingRefOptions = true;

	@Input()
	public model: models.OrderModel;

	@Input()
	public mode: models.EditorMode = 'create';

	@Input()
	public redirectToRoute = 'order/listing';

    
    //////////////////// Outgoing References BEGINGs ////////////////////////
        
    @Input()
    public productOptions: models.ProductModel[];

        
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
			    const id = params['id'];

			    console.log(JSON.stringify({action, id}));

			    this.mode = action || this.mode;

			    if (this.mode === 'edit' || this.mode === 'view') {
				    this.loadData(id);
			    }
		    });
        } else if (this.entityId != null && !this.model) {
            this.loadData(this.entityId);
        }

		this.model = this.model || {};

        if (this.loadOutgoingRefOptions) {

            
            //////////////////// Outgoing References BEGINGs ////////////////////////
                
            this.repoApi.getProductList( <models.ProductSearchParams> { sortFieldName: '', direction: '', pageIndex: 0, pageSize: 1000 }).subscribe(pagingResult => {
                this.productOptions = pagingResult.pagedData;
            });

                
            //////////////////// Outgoing References ENDs ////////////////////////
            
        }
	}

    public loadData(id: number | string) {
        this.repoApi.getOrderById(id).subscribe(result => {
			this.model = result;
		}, err => {
            console.error(`unable to load Order by id ${id}`, err);
            this.onLoadDataError.emit({ error: err, id: id});
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

		this.repoApi.createOrder(this.model).subscribe(result => {
			if (result && result.id) {
				this.model.id = result.id;
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

		this.repoApi.updateOrder(this.model.id, this.model).subscribe(result => {
			if (result && result.id) {
				this.model.id = result.id;
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
  selector: 'order-details-dialog',
  template: `    
    <div mat-dialog-content>      
      <order-editor [entityId]="data.id" [subscribeToRoutingParams]="false" ></order-editor>
    </div>
    <div mat-dialog-actions align="end">
      <button mat-button (click)="close()">Close</button>      
    </div>
  `,
})
export class OrderDetailsDialog {

  constructor(
    public dialogRef: MatDialogRef<OrderDetailsDialog>,
    @Inject(MAT_DIALOG_DATA) public data: any) {
  }

  close(): void {
    this.dialogRef.close();
  }
}