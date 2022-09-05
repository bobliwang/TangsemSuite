import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  // tslint:disable-next-line:component-selector
  selector: 'admin-product-list',
  templateUrl: './product-list.component.html',
  styleUrls: ['./product-list.component.scss']
})
export class ProductListComponent implements OnInit {


  public items: any[];

  public itemDetails: { [key: string]: any } = {};

  constructor(private httpClient: HttpClient) { }

  ngOnInit() {
    this.downloadShopeeItems();
  }

  public downloadShopeeItems() {
    this.httpClient.get<any>('/api/shopee/items').subscribe(
      x => this.items = x.items,
      err => {
        console.error(err);
        if (err.name === 'HttpErrorResponse' && err.url) {
          window.location.replace(err.url);
        }
      });
  }

  // tslint:disable-next-line:variable-name
  public showDetails(item_id: string) {
    this.httpClient.get<any>(`/api/shopee/item/${item_id}`).subscribe(x => {
      this.itemDetails[item_id] = x;
    });
  }

  public pushProductToQuickbook(item: any) {
    const details = this.itemDetails[item.item_id].item;

    if (details) {
      // TODO
    }

    this.httpClient.put<any>(`/api/shopee/item/${item.item_id}`, details).subscribe(payload => {
      console.log(payload);
    });
  }
}
