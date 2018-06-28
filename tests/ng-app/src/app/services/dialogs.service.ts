import { Injectable } from '@angular/core';
import { ResultCode, DialogType, DialogModel } from '../components/dialog/dialog.models';
import { Observable } from 'rxjs/Observable';
import "rxjs/add/operator/map";
import { MatDialog } from '@angular/material';

import { DialogComponent } from '../components/dialog/dialog.component';


@Injectable()
export class DialogsService {

  constructor(private dialog: MatDialog) {
  }

  public confirm(title: string, body: string, defaultResultCode: ResultCode = ResultCode.Yes): Observable<boolean> {
    
    const dlgRef = this.dialog.open(DialogComponent, {
      data: <DialogModel>{
        type: DialogType.Confirm,
        title,
        body,
        defaultResultCode
      }
    });

    return dlgRef.afterClosed().map(dlgResult => dlgResult === ResultCode.Yes);
  }

  public alert(title: string, body: string): Observable<any> {
    
    const dlgRef = this.dialog.open(DialogComponent, {
      data: {
        type: DialogType.Alert,
        title,
        body
      }
    });

    return dlgRef.afterClosed();
  }
}