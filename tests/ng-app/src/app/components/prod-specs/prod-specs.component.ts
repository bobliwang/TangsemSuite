import { Component, OnInit, Input } from '@angular/core';

@Component({
  selector: 'prod-specs',
  templateUrl: './prod-specs.component.html',
  styleUrls: ['./prod-specs.component.css']
})
export class ProdSpecsComponent implements OnInit {

  @Input()
  public specs: { name: string, value: any }[] = [];

  constructor() { }

  ngOnInit() {
  }

}
