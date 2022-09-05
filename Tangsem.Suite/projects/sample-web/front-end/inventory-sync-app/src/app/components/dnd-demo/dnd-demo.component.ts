import { Component, OnInit } from '@angular/core';
import * as uuid from 'uuid';
import { CdkDragDrop, copyArrayItem, moveItemInArray, transferArrayItem } from '@angular/cdk/drag-drop';
import { BehaviorSubject, Observable } from 'rxjs';
import { map } from 'rxjs/operators';

@Component({
  selector: 'app-dnd-demo',
  templateUrl: './dnd-demo.component.html',
  styleUrls: ['./dnd-demo.component.scss']
})
export class DndDemoComponent implements OnInit {

  public toolboxItems = [
    {
      title: 'Text',
      type: 'text'
    },

    {
      title: 'Image',
      type: 'image'
    },

    {
      title: 'Address',
      type: 'address'
    },

    {
      title: 'Number',
      type: 'number'
    },

    {
      title: 'Checkbox',
      type: 'boolean'
    }
  ];

  public rows: { id: string, items: any[] }[];

  public dragListIds$ = new BehaviorSubject<string[]>([]);

  public counter = 1;

  constructor() { }

  ngOnInit() {

    this.rows = [{
      id: uuid.v4(),
      items: [{
        title: `Text ${this.counter++}`,
        type: 'text',
        id: uuid.v4()
      }]
    }];

    this.dragListIds$.next(this.dragListIds);
  }

  public dragListIdsWithout(id: string): Observable<string[]> {
    return this.dragListIds$.pipe(map(x => x.filter(y => y !== id && y !== 'rows-ctn')));
  }

  public get dragListIds(): string[] {
    return this.rows.map(r => 'row_items_' + r.id).concat('rows-ctn');
  }

  public dropRow(evt: CdkDragDrop<any[]>) {
    console.log('dropRow', evt);

    if (evt.previousContainer === evt.container) {
      moveItemInArray(this.rows, evt.previousIndex, evt.currentIndex);
      this.dragListIds$.next(this.dragListIds);
    } else if (evt.previousContainer.id === 'toolbox') {
      const item = JSON.parse(JSON.stringify(this.toolboxItems[evt.previousIndex]));
      item.id = uuid.v4();
      item.title += (' ' + this.counter++);
      const newRow = {
        id: uuid.v4(), items: [
          item
        ]
      };
      this.rows.splice(evt.currentIndex, 0, newRow);
      this.dragListIds$.next(this.dragListIds);
    } else {
      const item = evt.previousContainer.data[evt.previousIndex];
      evt.previousContainer.data.splice(evt.previousIndex, 1);
      const newRow = {
        id: uuid.v4(), items: [
          item
        ]
      };
      this.rows.splice(evt.currentIndex, 0, newRow);
      this.dragListIds$.next(this.dragListIds);
    }
  }

  public dropColumn(row: any, evt: CdkDragDrop<any[]>) {
    console.log('dropColumn', evt);

    if (evt.previousContainer === evt.container) {
      moveItemInArray(row.items, evt.previousIndex, evt.currentIndex);
    } else if (evt.previousContainer.id === 'toolbox') {
      const item = JSON.parse(JSON.stringify(this.toolboxItems[evt.previousIndex]));
      item.id = uuid.v4();
      item.title += (' ' + this.counter++);
      row.items.splice(evt.currentIndex, 0, item);
    } else {
      transferArrayItem(evt.previousContainer.data, row.items, evt.previousIndex, evt.currentIndex);
    }
  }

  removeRow(row) {
    this.rows.splice(this.rows.indexOf(row), 1);
  }
}
