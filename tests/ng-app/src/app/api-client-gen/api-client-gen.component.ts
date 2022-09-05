import { Component, OnInit } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Swagger, TypeInfo, PropertyInfo } from '../models/swagger-models';
import { getEnumDescriptions, genType, genEnum } from './types-gen';
import { genApiClient } from './api-gen';
import { MatSnackBar } from '@angular/material';
import { ApiClient } from '../services/api-client/api-client';
import { Property } from '../services/api-client/models';
import * as uuid from 'uuid';

@Component({
  selector: 'app-api-client-gen',
  templateUrl: './api-client-gen.component.html',
  styleUrls: ['./api-client-gen.component.css']
})
export class ApiClientGenComponent implements OnInit {

  constructor(private httpClient: HttpClient, private snackBar: MatSnackBar, private apiClient: ApiClient) { }

  public swaggerContents: string;

  public generatedModelsCode: string;

  public generatedApiClientCode: string;

  public apiResult: string;

  public codeMirrorOptions = {
    lineNumbers: true,
    theme: 'material',
    mode: 'javascript',
    tabSize: 2,
    indentWithTabs: false,
  };

  ngOnInit() {

    // this.httpClient.get<Swagger>('', { params: })
    this.generate();
  }

  generate() {

    this.httpClient.get<Swagger>('http://localhost:5000/swagger/v1/swagger.json')
      .subscribe(swagger => {

        this.swaggerContents = JSON.stringify(swagger, null, 4);
        this.generatedModelsCode = swagger['generatedModelsCode'];
        this.generatedApiClientCode = swagger['generatedApiClientCode'];

        this.snackBar.open('Successfully Generated.', null, { duration: 1000 });
      }, err => {
        this.snackBar.open('ERROR. Unable to generate code', null, { duration: 3000 });
      });
  }

  testApiGetProperties() {
    this.apiClient.getProperties('3150').subscribe(props => {
      this.apiResult = JSON.stringify(props, null, 4);
      this.snackBar.open('testApiGetProperties is a success.', null, { duration: 1000 });
    }, err => {
      this.snackBar.open('ERROR. testApiGetProperties is a failure.', null, { duration: 3000 });
    });
  }

  testApiUpdateProperty() {
    const propertyId = Math.ceil(Math.random() * 100);
    const propertyGuidId = uuid.v4();
    const suburb = 'Melbourne';

    const payload = {
      extraInfo: 'this is extra info', property: {
        suburb: suburb
      }
    };

    this.apiClient.updateProperty(propertyId, payload, { propertyGuidId }).subscribe(response => {

      response['expected_propertyGuidId'] = propertyGuidId;
      response['expected_propertyId'] = propertyId;
      response['expected_suburb'] = suburb;

      this.apiResult = JSON.stringify(response, null, 4);

      if (response.propertyGuidId !== propertyGuidId || response.propertyId !== propertyId || response.suburb !== suburb) {
        this.snackBar.open('testApiUpdateProperty partially success. Response contains unexpected values.', null, { duration: 3000 });
      } else {
        this.snackBar.open('testApiUpdateProperty is a success.', null, { duration: 1000 });
      }
    }, err => {
      this.snackBar.open('ERROR. testApiUpdateProperty is a failure.', null, { duration: 3000 });
    });
  }

}
