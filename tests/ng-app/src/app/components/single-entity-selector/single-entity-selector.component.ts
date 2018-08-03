import { Component, OnInit, Input, ViewChild, ElementRef, forwardRef } from '@angular/core';
import { ControlValueAccessor, NG_VALUE_ACCESSOR } from '@angular/forms';
import { Observable } from 'rxjs/Observable';
import { HttpClient } from '@angular/common/http';
import { MatSelect } from '@angular/material';

@Component({
  selector: 'single-entity-selector',
  templateUrl: './single-entity-selector.component.html',
  styleUrls: ['./single-entity-selector.component.css'],
  providers: [{
    provide: NG_VALUE_ACCESSOR,
    useExisting: forwardRef(() => SingleEntitySelectorComponent),
    multi: true
  }]
})
export class SingleEntitySelectorComponent implements OnInit, ControlValueAccessor {

  @Input()
  public value: any;

  @Input()
  public endpoint = 'DEFAULT_URL';

  @Input()
  public httpParams: { [keyName: string]: any };

  @Input()
  public method = 'GET';

  @Input()
  public valueField = 'id';

  @Input()
  public displayField = 'name';

  @Input()
  public options$: Observable<any[]>;

  @Input()
  public isDisabled = false;

  @Input()
  public useNgMaterial = false;

  @Input()
  public cssClass = '';
  
  @ViewChild('select')
  public selectRef: ElementRef;

  @ViewChild('matSelect')
  public matSelect: MatSelect;

  public onChange = _ => {};

  public onTouched = () => {};

  constructor(private httpClient: HttpClient) { }

  ngOnInit() {
    
    if (this.options$) {
      return;
    }

    const params: { [keyName: string]: string } = {};

    if (this.httpParams) {        
      Object.keys(this.httpParams).forEach(keyName => {
        params[keyName] = `${this.httpParams[keyName]}`;
      });
    }

    this.options$ = this.httpClient.request<{pagedData: any[]}>(this.method, this.endpoint, { params }).map(x => x.pagedData);
    
  }

  public updateValue($event) {
    console.log('updateValue', $event);

    if (this.selectRef) {
      const select = this.selectRef.nativeElement as HTMLSelectElement;    
      this.onChange(select.value);
    } else if (this.matSelect) {
      this.onChange(this.matSelect.value);
    }
    
    this.onTouched();
  }

  writeValue(value: any): void {
    console.log('writeValue', value);

    if (this.selectRef) {
      (this.selectRef.nativeElement as HTMLSelectElement).value = value;
    } else if (this.matSelect) {
      this.matSelect.value = value;
    }
    
  }

  registerOnChange(fn: any): void {
    this.onChange = fn;
  }

  registerOnTouched(fn: any): void {
    this.onTouched = fn;
  }

  setDisabledState?(isDisabled: boolean): void {
    this.isDisabled = isDisabled;
  }

}
