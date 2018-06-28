import { Component, OnInit, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';
import { DialogModel, DialogType, ResultCode } from './dialog.models';

@Component({
  selector: 'app-dialog',
  templateUrl: './dialog.component.html'
})
export class DialogComponent implements OnInit {

  public buttons = [];

  constructor(
    public dialogRef: MatDialogRef<DialogComponent>,
    @Inject(MAT_DIALOG_DATA) public model: DialogModel) {
  }

  ngOnInit() {
    if (this.model && this.model.buttons) {
      this.buttons = this.model.buttons;
    } else {
      switch (this.model.type) {
        case DialogType.Alert:
          this.buttons.push({ text: 'OK', resultCode: ResultCode.OK });
          break;
        case DialogType.Confirm:
          this.buttons.push({ text: 'No', resultCode: ResultCode.No });
          this.buttons.push({ text: 'Yes', resultCode: ResultCode.Yes });
          break;
        default:
          this.buttons.push({ text: 'OK', resultCode: ResultCode.OK });
          break;
      }
    }

    this.buttons.forEach(btn => btn.default = this.model.defaultResultCode === btn.resultCode);
  }
}
