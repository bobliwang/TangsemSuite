import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-order-cust-info',
  templateUrl: './order-cust-info.component.html',
  styleUrls: ['./order-cust-info.component.scss']
})
export class OrderCustInfoComponent implements OnInit {

  public orderId: string;

  constructor(private activatedRoute: ActivatedRoute) { }

  ngOnInit() {
    this.activatedRoute.parent.params.subscribe(params => {
      this.orderId = params.orderId;
    });
  }

}
