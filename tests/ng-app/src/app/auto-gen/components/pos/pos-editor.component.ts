import { Router } from '@angular/router';
import { Component, OnInit, ViewChild, Input } from '@angular/core';
import { MatPaginator, MatSort, MatSnackBar } from '@angular/material';
import * as models from '../../models/models';

import { GeneratorTestRepositoryApiService } from '../../services/api.service';

@Component({
  selector: 'pos-editor',
  templateUrl: 'pos-editor.component.html',
})
export class PosEditorComponent {
	
	@Input()
	public model: models.PosModel;

	@Input()
	public mode: models.EditorMode = 'view';

	
	constructor(
		private router: Router,
		private snackBar: MatSnackBar,
		private repoApi: GeneratorTestRepositoryApiService) {
	
	}

	public ngOnInit() {
		this.model = this.model || {};
	}

	public save() {
		if (this.mode === 'create') {
			this.create();
		} else if (this.mode === 'edit') {
			this.update();
		}
	}

	public cancel() {
		this.router.navigate(['listing']);
	}

	protected create() {

		this.repoApi.createPos(this.model).subscribe(result => {
			if (result && result.id) {
				this.model.id = result.id;
			}

			this.snackBar.open('created successfully', null, { duration: 1000 });
			this.router.navigate(['listing']);
		}, err => {
			this.snackBar.open('failed to create', null, { duration: 3000 });
		});
	}

	protected update() {

		this.repoApi.updatePos(this.model.id, this.model).subscribe(result => {
			if (result && result.id) {
				this.model.id = result.id;
			}

			this.snackBar.open('updated successfully', null, { duration: 1000 });
			this.router.navigate(['listing']);
		}, err => {
			this.snackBar.open('failed to updade', null, { duration: 3000 });
		});
	}

}