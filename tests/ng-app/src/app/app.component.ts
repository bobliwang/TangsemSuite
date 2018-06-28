import { Component, OnInit } from '@angular/core';
import { routes } from './auto-gen/generatorTestRepository-routing.module';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {

  menuItems = [];

  ngOnInit(): void {
    this.menuItems = routes.filter(r => !r.hideFromMenuItem).map(r => r);
  }
  
}
