import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-order-prod-info',
  templateUrl: './order-prod-info.component.html',
  styleUrls: ['./order-prod-info.component.scss']
})
export class OrderProdInfoComponent implements OnInit {

  public orderId: string;

  constructor(private activatedRoute: ActivatedRoute) { }

  ngOnInit() {
    this.activatedRoute.parent.params.subscribe(params => {
      this.orderId = params.orderId;
    });
  }

}
