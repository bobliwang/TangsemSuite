import { Component, OnInit, Input } from '@angular/core';


@Component({
  // tslint:disable-next-line:component-selector
  selector: 'ebay-order-cell',
  templateUrl: './ebay-order-cell.component.html',
  styleUrls: ['./ebay-order-cell.component.scss']
})
export class EbayOrderCellComponent implements OnInit {
  flipped = false;

  @Input()
  public order: any;

  constructor() { }

  ngOnInit() {
  }

}
