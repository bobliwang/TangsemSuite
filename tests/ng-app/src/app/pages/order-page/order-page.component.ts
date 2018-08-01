import { Component, OnInit, Inject } from '@angular/core';

import { MatBottomSheet } from '@angular/material';
import { OrderModel } from '../../auto-gen/models/models';
import { ProductSheetComponent } from '../../auto-gen/components/product/product-editor.component';


@Component({
  selector: 'order-page',
  templateUrl: './order-page.component.html',
  styleUrls: ['./order-page.component.css']
})
export class OrderPageComponent implements OnInit {

  constructor(private bottomSheet: MatBottomSheet) { }

  ngOnInit() {
  }
}

