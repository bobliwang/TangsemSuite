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

  public selectedCustomer = '';

  public selectedCustomers = [];

  constructor(private bottomSheet: MatBottomSheet) { }

  ngOnInit() {
  }

  public log(obj) {
    console.log(obj);
  }

}

