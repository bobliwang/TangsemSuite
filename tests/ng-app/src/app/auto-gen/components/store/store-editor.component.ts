import { Router, ActivatedRoute } from '@angular/router';
import { Component, OnInit, ViewChild, Input, Output, EventEmitter, Inject } from '@angular/core';
import { MatPaginator, MatSort, MatSnackBar, MatDialogRef, MAT_DIALOG_DATA, MatBottomSheetRef, MAT_BOTTOM_SHEET_DATA } from '@angular/material';
import * as models from '../../models/models';

import { GeneratorTestRepositoryApiService } from '../../services/api.service';

import { DialogsService } from '../../../services/dialogs.service';
import { ResultCode } from '../../../components/dialog/dialog.models';

@Component({
  selector: 'store-editor',
  templateUrl: 'store-editor.component.html',
})
export class StoreEditorComponent implements OnInit {

    @Input()
    public subscribeToRoutingParams = true;

    @Input()
    public id = null;

    @Input()
    public loadOutgoingRefOptions = true;

    @Input()
    public isDialog = false;

    @Input()
    public hideActionBar = false;

	@Input()
	public model: models.StoreModel;

	@Input()
	public mode: models.EditorMode = 'create';

	@Input()
	public redirectToRoute = 'store/listing';

    
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
        } else if (this.id != null && !this.model) {
            this.loadData(this.id);
        }

		this.model = this.model || {};

        if (this.loadOutgoingRefOptions) {

            
        }
	}

    public loadData(id: number | string) {
        this.repoApi.getStoreById(id).subscribe(result => {
			this.model = result;
		}, err => {
            console.error(`unable to load Store by id ${id}`, err);
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

		this.repoApi.createStore(this.model).subscribe(result => {
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

		this.repoApi.updateStore(this.model.id, this.model).subscribe(result => {
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
  selector: 'store-details-dialog',
  template: `
    <h4 mat-dialog-title *ngIf="!!data.title">
        {{ data.title }}
    </h4>
    <div mat-dialog-content>
      <store-editor
        [id]="data.id" [subscribeToRoutingParams]="false" [isDialog]="true"></store-editor>
    </div>
    <div mat-dialog-actions align="end">
      <button mat-button (click)="close()">Close</button>      
    </div>
  `,
})
export class StoreDetailsDialog {

  constructor(
    public dialogRef: MatDialogRef<StoreDetailsDialog>,
    @Inject(MAT_DIALOG_DATA) public data: { id: number, title?: string }) {
  }

  public close(): void {
    this.dialogRef.close();
  }
}


@Component({
	selector: 'store-sheet',
	template: `
		<div class="flex-columns">
			<div></div>
			<button mat-button (click)="close($event)">
				<mat-icon>close</mat-icon>
			</button>
		</div>
		<div class="sheet-container">
			<store-editor
				[subscribeToRoutingParams]="false"
				[isDialog]="true"
				[id]="data.id"
				></store-editor>
		</div>
	`,
})
export class StoreSheetComponent {
	constructor(private bottomSheetRef: MatBottomSheetRef<StoreSheetComponent>,
		@Inject(MAT_BOTTOM_SHEET_DATA) public data: { id: number, title?: string }) { }

	public close(event: MouseEvent): void {
		this.bottomSheetRef.dismiss();
		event.preventDefault();
	}
}