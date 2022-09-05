import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';

@Component({
  selector: 'app-ebay-orders',
  templateUrl: './ebay-orders.component.html',
  styleUrls: ['./ebay-orders.component.scss']
})
export class EbayOrdersComponent implements OnInit {

  public orders = [];

  public isLoading = false;

  constructor(private httpClient: HttpClient) { }

  ngOnInit() {
    this.loadOrders();
  }

  loadOrders() {
    this.isLoading = true;
    this.httpClient.get<any>('/api/ebay/orders').subscribe(data => {
      this.orders = data.orders;
      this.isLoading = false;
    }, err => {
      this.isLoading = false;
    });
  }

}
